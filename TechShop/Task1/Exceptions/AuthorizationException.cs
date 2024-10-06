using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechShop.Exceptions {
    internal class AuthorizationException:ApplicationException {
        public AuthorizationException(string message) : base(message) { }
        public AuthorizationException() { }
        public void AuthorizeUser(string userRole, string requiredRole) {
            if (userRole != requiredRole) {
                throw new AuthorizationException("User is not authorized to access.");
            }
        }


    }
}
