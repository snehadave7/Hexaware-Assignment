using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechShop.Dao;

namespace TechShop.Model {
    internal class Inventory {
        int inventoryId;
        Products product;
        int quantityInStock;
        DateTime lastStockUpdate;

        public Inventory(int inventoryId, Products product, int quantityInStock, DateTime lastStockUpdate) {
            this.inventoryId = inventoryId;
            this.product = product;
            this.quantityInStock = quantityInStock;
            this.lastStockUpdate = lastStockUpdate;
        }
        public Inventory(int inventoryId, int quantityInStock, DateTime lastStockUpdate) {
            this.inventoryId = inventoryId;
            
            this.quantityInStock = quantityInStock;
            this.lastStockUpdate = lastStockUpdate;
        }
        public int InventoryId {
            get { return inventoryId; }
            set { inventoryId = value; }
        }

        public Products Product {
            get { return product; }
            set { product = value; }
        }

        public int QuantityInStock {
            get { return quantityInStock; }
            set
            {
                if (quantityInStock < 0) throw new ArgumentOutOfRangeException();
                quantityInStock = value;
            }

        }

        public DateTime LastStockUpdate {
            get { return lastStockUpdate; }
            set { lastStockUpdate = value; }
        }

        public override string ToString() {
            return $"InventoryId: {inventoryId} Product: {product} QuantityInStock: {quantityInStock} LastStockUpdate: {lastStockUpdate}";
        }
    }
}
