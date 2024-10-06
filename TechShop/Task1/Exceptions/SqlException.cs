using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechShop.Exceptions {
    internal class SqlException:ApplicationException {
        public SqlException() { }
        public SqlException(string message) : base(message) { }

        public void ExecuteDatabaseQuery(string query) {
            try {
                throw new SqlException();
            }
            catch (SqlException ex) {
                Console.WriteLine("Database connection failed. Retrying...");
            }
        }
    }
}
