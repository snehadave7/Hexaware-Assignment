using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechShop.Dao;

namespace TechShop.Model {
    internal class Products {
        int productId;
        string productName;
        string description;
        decimal price;
        string category;
        public Products( String productName, String description, decimal price, string category) {
            this.productName = productName;
            this.description = description;
            this.price = price;
            this.category = category;
        }
        public Products()
        {
            
        }

        public int ProductId {
            get { return productId; }
            set { productId = value; }
        }

        public string ProductName {
            get { return productName; }
            set { productName = value; }
        }

        public string Description {
            get { return description; }
            set { description = value; }
        }
        public decimal Price {
            get { return price; }
            set
            {
                if (price < 0) throw new ArgumentOutOfRangeException(nameof(Price));
                price = value;
            }
        }

        public string Category {
            get { return category; }
            set{ category = value; }
        }
        public override string ToString() {
            return $"ProductId: {productId} ProductName: {productName} Description: {description} Price: {price} Category: {category}";
        }
    }
}
