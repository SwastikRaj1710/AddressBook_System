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
            Console.WriteLine("Enter the full name of the Contact you want to delete");
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
                Console.WriteLine(contact.firstName + "\t\t" + contact.lastName + "\t\t" + contact.address + "\t" + contact.city + "\t" + contact.state + "\t" + contact.zip + "\t\t" + contact.phone + "\t" + contact.email);
            }
        }

        public void DisplayContactDetails(string name)
        {
            foreach(Contact contact in contacts)
            {
                if((contact.firstName + " " + contact.lastName).Equals(name))
                {
                    Console.WriteLine("\nFirst Name\tLast Name\tAddress\tCity\tState\tZip Code\tPhone No.\tEmail Id");
                    Console.WriteLine(contact.firstName + "\t\t" + contact.lastName + "\t\t" + contact.address + "\t" + contact.city + "\t" + contact.state + "\t" + contact.zip + "\t\t" + contact.phone + "\t" + contact.email);
                }
            }
        }

        public void SortContactByName()
        {
            contacts.Sort((p1, p2) => p1.firstName.CompareTo(p2.firstName));
            Console.WriteLine("Contacts sorted by their name");
            DisplayAllContacts();
        }

        public void SortContactByCity()
        {
            contacts.Sort((p1, p2) => p1.city.CompareTo(p2.city));
            Console.WriteLine("Contacts sorted by their city names");
            DisplayAllContacts();
        }

        public void SortContactByState()
        {
            contacts.Sort((p1, p2) => p1.state.CompareTo(p2.state));
            Console.WriteLine("Contacts sorted by their state names");
            DisplayAllContacts();
        }

        public void SortContactByZipCode()
        {
            contacts.Sort((p1, p2) => p1.zip.CompareTo(p2.zip));
            Console.WriteLine("Contacts sorted by their zip codes");
            DisplayAllContacts();
        }

        public void ReadWriteTextFile()
        {
            string path = "D:\\BridgeLabz\\AddressBook_System\\Address_Book_System\\File1.txt";
            Console.WriteLine("1.Read from a text file");
            Console.WriteLine("2.Write to a text file");
            Console.WriteLine("Enter your choice");

            int choice = Convert.ToInt32(Console.ReadLine());

            switch(choice)
            {
                case 1:
                    Console.WriteLine("\nContents of the file are:");
                    if (File.Exists(path))
                    {
                        StreamReader sr = new StreamReader(path);
                        string line = sr.ReadLine();
                        while (line != null)
                        {
                            Console.WriteLine(line);
                            line = sr.ReadLine();
                        }
                        sr.Close();

                    }
                    else
                    {
                        Console.WriteLine("File does not exist");
                    }
                    break;
                case 2:
                    StreamWriter sw = new StreamWriter(path);
                    foreach(Contact contact in contacts)
                    {
                        sw.WriteLine("First Name: " + contact.firstName);
                        sw.WriteLine("Last Name: " + contact.lastName);
                        sw.WriteLine("Address: " + contact.address);
                        sw.WriteLine("City: " + contact.city);
                        sw.WriteLine("State: " + contact.state);
                        sw.WriteLine("Zip Code: " + contact.zip);
                        sw.WriteLine("Phone Number: " + contact.phone);
                        sw.WriteLine("Email Id: " + contact.email);
                        sw.WriteLine();
                    }
                    sw.Close();
                    Console.WriteLine("Successfully written to the file");
                    break;
            }
        }
    }
}
