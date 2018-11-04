using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Transactions;
using Dapper;
using LandWin.Venues.Domain.Dapper.Entities;

namespace LandWin.Venues.Domain.Dapper.Repositories
{
    public class VenueProductRepository : DapperRepository,  IVenueProductRepository
    {
      

        public VenueProductRepository(IDbTransaction unitOfWork) :base(unitOfWork)
        {
       
            
        }

        public void DeleteColor(long colorId)
        {
           
                var p = new DynamicParameters(new
                {
                    ColorId = colorId
                });

                Connection.Execute("DeleteProductColor", p, commandType: CommandType.StoredProcedure);

        }

        public void DeleteSize(long colorId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CatalogLog> GetCatalogs(string groupId)
        {
          

                return Connection.Query<CatalogLog>("GetCatalogs", new { GroupId = groupId }, commandType: CommandType.StoredProcedure);

        }

        public IEnumerable<Category> GetCategories(string merchant)
        {
            
                return Connection.Query<Category>("GetCategoryMapping", new { Merchant = merchant }, commandType: CommandType.StoredProcedure);
           
        }

        public VenueProduct GetProduct(string partNumber)
        {
           
                return Connection.Query<VenueProduct>("GetProductByPartNo", new { PartNumber = partNumber }, commandType: CommandType.StoredProcedure).FirstOrDefault();
           
        }

        public IEnumerable<VenueProductColor> GetProductColors(long id)
        {
            
                return Connection.Query<VenueProductColor>("GetProductColors", new { Id = id }, commandType: CommandType.StoredProcedure);
          
        }

        public IEnumerable<VenueProductColorSize> GetProductColorSizes(long id)
        {
           
                return Connection.Query<VenueProductColorSize>("GetProductColorSizes", new { Id = id }, commandType: CommandType.StoredProcedure);
           
        }

        public long InsertColor(VenueProductColor color)
        {
           

                var p = new DynamicParameters(new
                {
                    Color = color.ColorName,
                    RetailPrice = color.RetailPrice,
                    ImageUrl = color.ImageUrl,
                    ProductId = color.ProductId
                });

                p.Add("@newId", DbType.Int64, direction: ParameterDirection.Output);

              
                Connection.Execute("InsertProductColor", p, commandType: CommandType.StoredProcedure);
                return p.Get<dynamic>("newId");
          
        }

        public long InsertProduct(VenueProduct product)
        {
           
                var p = new DynamicParameters(new
                {
                    PartNumber = product.PartNumber,
                    ProductName = product.ProductName,
                    Brand = product.Brand,
                    Merchant = product.Merchant,
                    Merchantid = product.MerchantId,
                    Description = product.Description,
                    URL = product.ProductURL,
                    Reatil_price = product.ReatilPrice,
                    Saleprice = product.SalePrice,
                    Price = product.Price,
                    OnSale = product.OnSale,
                    ShippingCharge = product.ShippingCharge,
                    ShipFlatRate = product.ShipFlatRate,
                    CategoryId = product.CategoryId,
                    CatalogId = product.CatalogId
                });

                p.Add("@newId", DbType.Int64, direction: ParameterDirection.Output);

                Connection.Execute("InsertProduct", p, commandType: CommandType.StoredProcedure);
                return p.Get<dynamic>("newId");
            
        }

        public void InsertSize(VenueProductColorSize size)
        {
         
                var p = new DynamicParameters(new
                {
                    SizeName = size.SizeName,
                    UPC = size.UPC,
                    SKU = size.SKU,
                    ColorId = size.ColorId,
                    MerchantSKU = size.MerchantSKU,
                    OnSale = size.OnSale
                });


                Connection.Execute("InsertProductColorSize", p, commandType: CommandType.StoredProcedure);
           
          

        }

        public void UpdateColor(VenueProductColor color)
        {
            
                var p = new DynamicParameters(new
                {
                    RetailPrice = color.RetailPrice,
                    Id = color.Id
                });

                Connection.Execute("UpdateProductColor", p, commandType: CommandType.StoredProcedure);
         
            
        }

        public void UpdateProduct(VenueProduct product)
        {
         
           
                    var p = new DynamicParameters(new
                    {
                        Description = product.Description,
                        URL = product.ProductURL,
                        Reatil_price = product.ReatilPrice,
                        Saleprice = product.SalePrice,
                        Price = product.Price,
                        OnSale = product.OnSale,
                        ShippingCharge = product.ShippingCharge,
                        ShipFlatRate = product.ShipFlatRate,
                        CatalogId = product.CatalogId,
                        Id = product.Id
                    });
                    Connection.Execute("UpdateProduct", p, commandType: CommandType.StoredProcedure);
             

             
        }
    }
}
