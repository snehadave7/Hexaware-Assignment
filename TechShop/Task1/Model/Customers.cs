using System;
using System.Xml.Linq;
using TechShop.Dao;

namespace TechShop.Model {
    internal class Customers {
        int customerId;
        string firstName;
        string lastName;
        string email;
        string phone;
        string address;

        public  Customers( int customerId,string firstName, string lastName, string email, string phone, string address) {
            this.customerId = customerId;
            this.firstName = firstName;
            this.lastName = lastName;
            this.email = email;
            this.phone = phone;
            this.address = address;
        }
        public Customers(int customerId)
        {
            this.customerId = customerId;
        }
        public int CustomerId {
            get { return customerId; }
            set { customerId = value; }
        }
        public string FirstName {
            get { return firstName; }
            set { firstName = value; }
        }
        public string LastName {
            get { return lastName; }
            set { lastName = value; }
        }
        public string Email {
            get { return email; }
            set { email = value;}
        }
        public string Phone {
            get { return phone; }
            set { phone = value; }
        }
        public string Address {
            get { return address; }
            set { address = value; }
        }

        public override string ToString() {
            return $"CustomerId: {customerId} FirstName: {firstName} LastName: {lastName} Email: {email} Phone: {phone} Address: {address}";
        }


    }
}
