using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechShop.Exceptions {
    internal class IOException : ApplicationException{
        public IOException() { }
        public IOException(string message) : base(message) { }
        public void LogError(string message) {
            try {
                using (StreamWriter writer = new StreamWriter("file.txt", true)) {
                    writer.WriteLine($"{DateTime.Now}: {message}");
                }
            }
            catch (IOException ex) {
                Console.WriteLine($"Failed to write to log: {ex.Message}");
            }
        }
    }

}
