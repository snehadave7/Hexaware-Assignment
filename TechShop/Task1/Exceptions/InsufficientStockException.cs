using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechShop.Dao;
using TechShop.Util;

namespace TechShop.Exceptions {
    
    internal class InsufficientStockException : ApplicationException {
        public InsufficientStockException(string message) : base(message) { }
        public InsufficientStockException()
        {
            
        }


    }
}
