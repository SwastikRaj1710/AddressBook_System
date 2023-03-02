using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Address_Book_System
{
    public class AddressBook
    {
        public List<Contact> contacts = new List<Contact>();
        public void AddContact()
        {
            Console.WriteLine("Enter the First Name");
            string firstName = Console.ReadLine();
            Console.WriteLine("Enter the Last Name");
            string lastName = Console.ReadLine();
            Console.WriteLine("Enter the Address");
            string address = Console.ReadLine();
            Console.WriteLine("Enter the State");
            string state = Console.ReadLine();
            Console.WriteLine("Enter the City");
            string city = Console.ReadLine();
            Console.WriteLine("Enter the Zip Code");
            int zip = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the Phone Number");
            long phone = Convert.ToInt64(Console.ReadLine());
            Console.WriteLine("Enter the Email ID");
            string email = Console.ReadLine();

            Contact contact = new Contact(firstName, lastName, address, state, city, zip, phone, email);
            contacts.Add(contact);

            Console.WriteLine("\nContact added successfully");
        }

        public void EditContact()
        {
            int flag = 0;
            Console.WriteLine("Enter the first name of the person whose details you want to edit");
            string name = Console.ReadLine();

            for(int i=0;i<contacts.Count;i++)
            {
                if (contacts[i].firstName.Equals(name))
                {
                    flag = 1;

                    Console.WriteLine("Enter the First Name");
                    contacts[i].firstName = Console.ReadLine();

                    Console.WriteLine("Enter the Last Name");
                    contacts[i].lastName = Console.ReadLine();

                    Console.WriteLine("Enter the Address");
                    contacts[i].address = Console.ReadLine();

                    Console.WriteLine("Enter the State");
                    contacts[i].state = Console.ReadLine();

                    Console.WriteLine("Enter the City");
                    contacts[i].city = Console.ReadLine();

                    Console.WriteLine("Enter the Zip Code");
                    contacts[i].zip = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine("Enter the Phone Number");
                    contacts[i].phone = Convert.ToInt64(Console.ReadLine());

                    Console.WriteLine("Enter the Email ID");
                    contacts[i].email = Console.ReadLine();
                }
            }

            if(flag==0)
            {
                Console.WriteLine("Contact not found");
            }
        }
    }
}
