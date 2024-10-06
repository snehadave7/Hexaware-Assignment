using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechShop.Dao;

namespace TechShop.Model {
    internal class OrderDetails {
        int orderDetailId;
        Orders order;
        Products product;
        int quantity;
        
        public OrderDetails(Orders order, Products product,int quantity) {
           
            this.order = order;
            this.product= product;
            this.quantity = quantity;
            
        }
        public OrderDetails()
        {
            
        }

        public int OrderDetailId {
            get { return orderDetailId; }
            set { orderDetailId = value; }
        }

        public Orders Order{
            get { return order; }
            set { order = value; }
        }

        public Products Product {
            get { return product; }
            set { product= value; }
        }

        public int Quantity {
            get { return quantity; }
            set
            {
                if (quantity < 0) throw new ArgumentOutOfRangeException();
                quantity = value;
            }
        }

        public override string ToString() {
            return $"Order: {order.OrderId} Product: {product.ProductId} Quantity: {quantity}";
        }


    }
}
