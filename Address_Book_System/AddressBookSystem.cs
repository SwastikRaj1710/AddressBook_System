using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Address_Book_System
{
    public class AddressBookSystem
    {
        Dictionary<string, AddressBook> addressDict = new Dictionary<string, AddressBook>();

        public void AddAddressBook()
        {
            Console.WriteLine("Enter the Address Book name");
            string addressbookName = Console.ReadLine();
            AddressBook addressBook = new AddressBook();
            AddressBookOperations(addressBook);
            addressDict[addressbookName] = addressBook;
        }

        public void AccessAddressBook()
        {
            Console.WriteLine("Enter the Address book name");
            string name = Console.ReadLine();
            AddressBook addressBook = addressDict[name];
            AddressBookOperations(addressBook);
            addressDict[name] = addressBook;
        }

        public void AddressBookOperations(AddressBook addressbook)
        {
            int flag = 0;
            while (true)
            {
                Console.WriteLine("\nMenu");
                Console.WriteLine("1. Add a new Contact to the Address Book");
                Console.WriteLine("2. Editing an existing Contact in the Address Book");
                Console.WriteLine("3. Deleting an existing Contact in the Address Book");
                Console.WriteLine("4. Add multiple new Contacts to the Address Book");
                Console.WriteLine("5. Display all Contacts in the Address Book");
                Console.WriteLine("6. Exit");
                Console.WriteLine("Enter your choice");
                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Adding a new contact to the address book");
                        addressbook.AddContact();
                        break;
                    case 2:
                        Console.WriteLine("Editing an existing contact in the address book");
                        addressbook.EditContact();
                        break;
                    case 3:
                        Console.WriteLine("Deleting an existing contact in the address book");
                        addressbook.DeleteContact();
                        break;
                    case 4:
                        Console.WriteLine("Adding multiple new contacts to the address book");
                        addressbook.AddMultipleContacts();
                        break;
                    case 5:
                        Console.WriteLine("Displaying all Contacts in the address book");
                        addressbook.DisplayAllContacts();
                        break;
                    case 6:
                        flag = 1;
                        break;
                    default:
                        Console.WriteLine("Incorrect Choice!");
                        break;
                }
                if (flag == 1)
                    break;
            }
        }

        public void SearchPersonAcrossAllAddressBooks()
        {
            Console.WriteLine("Enter the City");
            string city = Console.ReadLine();
            Console.WriteLine("Enter the State");
            string state = Console.ReadLine();

            List<AddressBook> addressBooks = new List<AddressBook>();

            foreach(string bookName in addressDict.Keys)
            {
                addressBooks.Add(addressDict[bookName]);
            }

            Console.WriteLine("Names of people present in the same City or State are:");

            foreach(var addressBook in addressBooks)
            {
                var contactList = addressBook.contacts.Where(s => s.city == city || s.state == state);
                var personName = contactList.Select(s => s.firstName + " " +  s.lastName).ToList();

                for(int i=0;i<personName.Count;i++)
                {
                    Console.WriteLine(personName[i]);
                }
            }
        }
    }
}
