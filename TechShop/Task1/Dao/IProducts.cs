using System;
using System.Data.Common;
using TechShop.Model;
using TechShop.Util;


namespace TechShop.Dao {
    internal interface IProducts {
        public void GetProductDetails(DBConnection connection);
        public void UpdateProductInfo();
        //public bool IsProductInStock(DBConnection connection,int productId);
    }
}
