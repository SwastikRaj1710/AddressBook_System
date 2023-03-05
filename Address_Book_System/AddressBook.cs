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
            Console.WriteLine("\nEnter the contact details");
            Console.WriteLine("Enter the First Name");
            string firstName = Console.ReadLine();
            Console.WriteLine("Enter the Last Name");
            string lastName = Console.ReadLine();

            string fullname = firstName + " " + lastName;

            if(contacts.Find(s => (s.firstName + " " + s.lastName) == fullname) != null)
            {
                Console.WriteLine("The entered contact name already exists");
                return;
            }

            Console.WriteLine("Enter the Address");
            string address = Console.ReadLine();
            Console.WriteLine("Enter the City");
            string city = Console.ReadLine();
            Console.WriteLine("Enter the State");
            string state = Console.ReadLine();
            Console.WriteLine("Enter the Zip Code");
            int zip = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the Phone Number");
            long phone = Convert.ToInt64(Console.ReadLine());
            Console.WriteLine("Enter the Email ID");
            string email = Console.ReadLine();

            Contact contact = new Contact(firstName, lastName, address, city, state, zip, phone, email);

            contacts.Add(contact);

            Console.WriteLine("\nContact added successfully");
        }

        public void EditContact()
        {
            int flag = 0;
            Console.WriteLine("Enter the first name of the person whose details you want to edit");
            string name = Console.ReadLine();

            for (int i = 0; i < contacts.Count; i++)
            {
                string fullname = contacts[i].firstName + " " + contacts[i].lastName;
                if (fullname.Equals(name))
                {
                    flag = 1;

                    Console.WriteLine("Enter the First Name");
                    contacts[i].firstName = Console.ReadLine();

                    Console.WriteLine("Enter the Last Name");
                    contacts[i].lastName = Console.ReadLine();

                    Console.WriteLine("Enter the Address");
                    contacts[i].address = Console.ReadLine();

                    Console.WriteLine("Enter the City");
                    contacts[i].city = Console.ReadLine();

                    Console.WriteLine("Enter the State");
                    contacts[i].state = Console.ReadLine();

                    Console.WriteLine("Enter the Zip Code");
                    contacts[i].zip = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine("Enter the Phone Number");
                    contacts[i].phone = Convert.ToInt64(Console.ReadLine());

                    Console.WriteLine("Enter the Email ID");
                    contacts[i].email = Console.ReadLine();

                    break;
                }
            }

            if (flag == 0)
            {
                Console.WriteLine("Contact not found");
            }
            else
            {
                Console.WriteLine("Contact details updated");
            }
        }

        public void DeleteContact()
        {
            Console.WriteLine("Enter the first name of the Contact you want to delete");
            string name = Console.ReadLine();
            int flag = 0;
            for (int i = 0; i < contacts.Count; i++)
            {
                string fullname = contacts[i].firstName + " " + contacts[i].lastName;
                if (fullname.Equals(name))
                {
                    flag = 1;
                    contacts.RemoveAt(i);
                    break;
                }
            }

            if (flag == 0)
            {
                Console.WriteLine("Contact not found");
            }
            else
            {
                Console.WriteLine("Contact deleted");
            }
        }

        public void AddMultipleContacts()
        {
            Console.WriteLine("Enter the number of contacts to be added");
            int num = Convert.ToInt32(Console.ReadLine());

            for(int i=0;i<num;i++)
            {
                AddContact();
            }
        }

        public void DisplayAllContacts()
        {
            foreach(Contact contact in contacts)
            {
                Console.WriteLine("\nFirst Name\tLast Name\tAddress\tCity\tState\tZip Code\tPhone No.\tEmail Id");
                Console.WriteLine(contact.firstName + "\t\t" + contact.lastName + "\t\t" + contact.address + "\t" + contact.city + "\t" + contact.state + "\t" + contact.zip + "\t" + contact.phone + "\t" + contact.email);
            }
        }

        public void DisplayContactDetails(string name)
        {
            foreach(Contact contact in contacts)
            {
                if((contact.firstName + " " + contact.lastName).Equals(name))
                {
                    Console.WriteLine("\nFirst Name\tLast Name\tAddress\tCity\tState\tZip Code\tPhone No.\tEmail Id");
                    Console.WriteLine(contact.firstName + "\t\t" + contact.lastName + "\t\t" + contact.address + "\t" + contact.city + "\t" + contact.state + "\t" + contact.zip + "\t" + contact.phone + "\t" + contact.email);
                }
            }
        }
    }
}
