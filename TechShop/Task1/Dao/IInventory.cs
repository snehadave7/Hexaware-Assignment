using System;
using TechShop.Model;
using TechShop.Util;

namespace TechShop.Dao {
    internal interface IInventory {
        public void GetProduct();
        public int GetQuantityInStock(DBConnection dBConnection, int productId);
        public void AddToInventory(int quantity);
        public void RemoveFromInventory(int quantity);
        public void UpdateStockQuantity(DBConnection dBConnection,int newQuantity,int productId);
        public bool isProductInStock(DBConnection dBConnection,int productId);
        public void GetInventoryValue();
        public void ListLowStockProducts(int threshold);
        public void ListOutOfStockProducts();
        public void ListAllProducts();
    }
}
