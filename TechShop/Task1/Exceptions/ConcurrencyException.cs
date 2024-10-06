using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechShop.Exceptions {
    internal class ConcurrencyException: ApplicationException {
        public ConcurrencyException() { }
        public ConcurrencyException(string message) : base(message) { }
    }
}
