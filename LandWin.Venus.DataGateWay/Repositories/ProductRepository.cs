
using Dapper;
using LandWin.Venus.DataGateWay.Models;
using System.Collections.Generic;
using System.Data;
namespace LandWin.Venus.DataGateWay.Repositories
{
    public class ProductRepository : DapperRepository, IProductRepository 
    {
        public ProductRepository(IUnitOfWork unitOfWork) : base(unitOfWork) { }


        //public void InsertProduct(Product product)
        //{
        //    var p = new DynamicParameters(new
        //    {
        //        PartNumber = product.part_number,
        //        ProductName = product.name,
        //        Brand = product.brand,
        //        Merchant  = product.merchant,
        //        Merchant_id = product.merchant_id,
        //        Description = product.description,
        //        URL = product.url,
        //        Reatil_price = product.reatil_price,
        //        Sale_price = product.sale_price,         
        //        Price = product.price,
        //        On_sale = product.on_sale,
        //        OnSale = product.onSale,
        //        Shipping_charge = product.shipping_charge,
        //        Ship_flat_rate = product.ship_flat_rate

        //    });

        //    p.Add("@newId", DbType.Int64, direction: ParameterDirection.Output);

        //    SqlExecute("InsertProduct", p, true);

        //    var result = p.Get<dynamic>("newId");


        //    if (product.category != null)
        //    {
        //        foreach (var item in product.category)
        //        {
        //            p = new DynamicParameters(new
        //            {
        //                Category = item.Replace(">", "/"),
        //                ProductId = result
        //            });

        //            SqlExecute("InsertCategory", p, true);
        //        }
        //    }

        //    if (product.colors != null)
        //    {
        //        foreach (var item in product.colors)
        //        {
        //            p = new DynamicParameters(new
        //            {
        //                Color = item.color,
        //                Retail_Price = item.retail_price,
        //                ImageUrl = item.image[0] == null ? product.image[0] : item.image[0],
        //                ProductId = result
        //            });

        //            p.Add("@newId", DbType.Int64, direction: ParameterDirection.Output);

        //            SqlExecute("InsertColor", p, true);

        //            var colorId = p.Get<dynamic>("newId");
        //            foreach (var size in item.sizes)
        //            {
        //                p = new DynamicParameters(new
        //                {
        //                    Size = size.size,
        //                    ProductId = result,
        //                    ColorId = colorId,
        //                    UPC = size.upc,
        //                    SKU = size.sku,
        //                    OnSale = size.active
        //                });

        //                SqlExecute("InsertSize", p, true);

        //            }
        //        }
        //    }
        //}


        //public IEnumerable<MagentoProduct> GetProductData(string merchant)
        //{
        //    return Connection.Query<MagentoProduct>("GetProductData", new { Merchant = merchant}, commandType: CommandType.StoredProcedure);

        //}

        //public IEnumerable<ImageUrl> GetImageUrl(int Offset, int rows)
        //{
        //    return Connection.Query<ImageUrl>("GetImageUrl", new { Offset = Offset, Rows = rows }, commandType: CommandType.StoredProcedure);
        //}

        //public int GetTotalCount()
        //{
        //    return Connection.ExecuteScalar<int>("GetCount", commandType: CommandType.StoredProcedure);
        //}


        //public IEnumerable<ProductInfo> GetProductInfo()
        //{
        //    return Connection.Query<ProductInfo>("GetProducts", commandType: CommandType.StoredProcedure);
        //}


        //public IEnumerable<MagentoCategory> GetMagentoCategory()
        //{
        //    return Connection.Query<MagentoCategory>("GetMagentoCategory", commandType: CommandType.StoredProcedure);
        //}


        //public void InsertCategroy(string merchant, string Category)
        //{
        //     var p = new DynamicParameters(new
        //    {
        //        merchant = merchant,
        //        category = Category
        //    });

        //     SqlExecute("InsertMagentoCategory", p, true);
        //}
    }
}
