

namespace TechShop.Exceptions {
    internal class AuthenticationException: ApplicationException {
        public AuthenticationException() { }
        public AuthenticationException(string message) : base(message) { }
        public void AuthenticateUser(string username, string password) {
            bool isAuthenticated = false;

            if (!isAuthenticated) {
                throw new AuthenticationException("User authentication failed.");
            }
        }

    }
}
