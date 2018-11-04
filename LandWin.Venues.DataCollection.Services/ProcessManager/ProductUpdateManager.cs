using LandWin.Venues.DataCollection.Entities;
using LandWin.Venues.Domain.Dapper.Entities;
using LandWin.Venues.Domain.Dapper.Repositories;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LandWin.Venues.DataCollection.Services.ProcessManager
{
    public class ProductUpdateManager : IProductUpdateManager
    {
        private IVenueProductRepository _productRepository;


        private static readonly ILog _log = LogManager.GetLogger(typeof(ProductUpdateManager));

        public ProductUpdateManager(IVenueProductRepository productRepository)
        {
            if (productRepository == null) throw new ArgumentNullException("productRepository");

            _productRepository = productRepository;
        }

        private void InsertProduct(Product product, string catalogId)
        {
            _log.DebugFormat("Insert product : {0}", product.part_number);

            long categoryId = GetCategoryId(product.merchant, product.category);

            long id = _productRepository.InsertProduct(new VenueProduct()
            {
                PartNumber = product.part_number,
                Brand = product.brand,
                CategoryId = categoryId,
                CatalogId = catalogId,
                MerchantId = product.merchant_id,
                Merchant = product.merchant,
                Description = product.description,
                OnSale = product.onSale,
                Price = product.price,
                ProductURL = product.url,
                ProductName = product.name,
                ReatilPrice = product.reatil_price,
                SalePrice = product.sale_price,
                ShipFlatRate = product.ship_flat_rate,
                ShippingCharge = product.shipping_charge,
                LastUpdated = DateTime.Now
            });

            foreach (var color in product.colors)
            {
                string imageUrl = color.image.Length == 0 ? product.image[0] : color.image[0];

                InsertProductColor(color, id, imageUrl);
            }
        }

        private void InsertProductColor(Color color, long productId, string imageUrl)
        {

            var colorId = _productRepository.InsertColor(new VenueProductColor()
            {
                ColorName = color.color,
                RetailPrice = color.retail_price,
                ImageUrl = imageUrl,
                ProductId = productId
            });

            foreach (var size in color.sizes)
            {
                _productRepository.InsertSize(new VenueProductColorSize()
                {
                    ColorId = colorId,
                    MerchantSKU = size.merchant_sku,
                    SizeName = size.size,
                    SKU = size.sku,
                    UPC = size.upc,
                    OnSale = size.active
                });
            }
        }

        private void UpdateProduct(Product product, VenueProduct orginal, string catalogId)
        {


            _log.DebugFormat("Update Product : ID {0}", orginal.Id);

            long categoryId = GetCategoryId(product.merchant, product.category);

            orginal.OnSale = product.onSale;
            orginal.Price = product.price;
            orginal.CatalogId = catalogId;
            orginal.Description = product.description;
            orginal.ReatilPrice = product.reatil_price;
            orginal.SalePrice = product.sale_price;
            orginal.ShipFlatRate = product.ship_flat_rate;
            orginal.ShippingCharge = product.shipping_charge;
            orginal.CategoryId = categoryId;

            _productRepository.UpdateProduct(orginal);

            var orgColors = _productRepository.GetProductColors(orginal.Id);

            foreach (var color in product.colors)
            {
                var item = orgColors.FirstOrDefault(x => x.ColorName == color.color);

                if (item == null)
                {
                    string imageUrl = color.image.Length == 0 ? product.image[0] : color.image[0];

                    InsertProductColor(color, orginal.Id, imageUrl);
                }
                else
                {
                    item.RetailPrice = color.retail_price;

                    _productRepository.UpdateColor(item);

                    UpdateSize(color, item.Id);

                }
            }

            foreach (var color in orgColors)
            {
                var item = product.colors.Find(x => x.color == color.ColorName);
                if (item == null)
                {
                    _productRepository.DeleteColor(color.Id);
                }

            }
        }

        private void UpdateSize(Color color, long colorId)
        {
            var origSize = _productRepository.GetProductColorSizes(colorId);

            foreach (var size in color.sizes)
            {
                var item = origSize.FirstOrDefault(x => x.SizeName == size.size);
                if (item == null)
                {
                    _productRepository.InsertSize(new VenueProductColorSize()
                    {
                        ColorId = colorId,
                        MerchantSKU = size.merchant_sku,
                        SizeName = size.size,
                        SKU = size.sku,
                        UPC = size.upc,
                        OnSale = size.active
                    });
                }

            }

        }

        private long GetCategoryId(string merchant, string[] categories)
        {
            var list = _productRepository.GetCategories(merchant);

            foreach (var category in categories)
            {
                var entity = list.FirstOrDefault(x => x.CategoryName == category);
                if (entity != null)
                {
                    return entity.Id;
                }
            }
            return 0;
        }

        public void InsertOrUpdate(Product product, string groupId)
        {
            var venue = _productRepository.GetProduct(product.part_number);

            if(venue == null)
            {
                InsertProduct(product, groupId);
            }
            else
            {
                UpdateProduct(product, venue, groupId);

            }
        }
    }
}