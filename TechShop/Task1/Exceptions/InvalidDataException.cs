

namespace TechShop.Exceptions {
    internal class InvalidDataException: ApplicationException {
        
        public InvalidDataException() { }
        public InvalidDataException(string message) : base(message) { }
    }

    
}