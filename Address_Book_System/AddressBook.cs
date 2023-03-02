using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Address_Book_System
{
    internal class AddressBook
    {
        public void AddContact()
        {
            Console.WriteLine("Enter your First Name");
            string firstName = Console.ReadLine();
            Console.WriteLine("Enter your Last Name");
            string lastName = Console.ReadLine();
            Console.WriteLine("Enter your Address");
            string address = Console.ReadLine();
            Console.WriteLine("Enter your State");
            string state = Console.ReadLine();
            Console.WriteLine("Enter your City");
            string city = Console.ReadLine();
            Console.WriteLine("Enter your Zip Code");
            int zip = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter your Phone Number");
            long phone = Convert.ToInt64(Console.ReadLine());
            Console.WriteLine("Enter your Email ID");
            string email = Console.ReadLine();

            Contact contact = new Contact(firstName, lastName, address, state, city, zip, phone, email);

            Console.WriteLine("\nContact added successfully");
        }
    }
}
