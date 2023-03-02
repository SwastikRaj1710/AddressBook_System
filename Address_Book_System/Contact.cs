using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Address_Book_System
{
    internal class Contact
    {
        public string firstName;
        public string lastName;
        public string address;
        public string state;
        public string city;
        public int zip;
        public long phone;
        public string email;

        public Contact(string firstName, string lastName, string address, string state, string city, int zip, long phone, string email)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.address = address;
            this.state = state;
            this.city = city;
            this.zip = zip;
            this.phone = phone;
            this.email = email;
        }
    }
}
