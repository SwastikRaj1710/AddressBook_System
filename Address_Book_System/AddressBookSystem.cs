﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Address_Book_System
{
    public class AddressBookSystem
    {
        Dictionary<string, AddressBook> addressDict = new Dictionary<string, AddressBook>();
        Dictionary<string, List<Contact>> cityDict = new Dictionary<string, List<Contact>>();
        Dictionary<string, List<Contact>> stateDict = new Dictionary<string, List<Contact>>();

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
                Console.WriteLine("4. Displaying the details of an existing Contact in the Address Book");
                Console.WriteLine("5. Add multiple new Contacts to the Address Book");
                Console.WriteLine("6. Display all Contacts in the Address Book");
                Console.WriteLine("7. Exit");
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
                        Console.WriteLine("Displaying the details of an existing contact");
                        Console.WriteLine("Enter the firstname and lastname");
                        string fname = Console.ReadLine();
                        string lname = Console.ReadLine();
                        string name = fname + " " + lname;
                        addressbook.DisplayContactDetails(name);
                        break;
                    case 5:
                        Console.WriteLine("Adding multiple new contacts to the address book");
                        addressbook.AddMultipleContacts();
                        break;
                    case 6:
                        Console.WriteLine("Displaying all Contacts in the address book");
                        addressbook.DisplayAllContacts();
                        break;
                    case 7:
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

        public void ViewPersonByCityOrState()
        {
            List<AddressBook> addressBooks = new List<AddressBook>();

            foreach (string bookName in addressDict.Keys)
            {
                addressBooks.Add(addressDict[bookName]);
            }
            Console.WriteLine("1. View person by City Name");
            Console.WriteLine("1. View person by State Name");
            Console.WriteLine("Enter your choice");

            int choice = Convert.ToInt32(Console.ReadLine());

            switch(choice)
            {
                case 1:
                    foreach (var addressBook in addressBooks)
                    {

                        foreach (Contact contact in addressBook.contacts)
                        {
                            if (!cityDict.ContainsKey(contact.city))
                            {
                                cityDict.Add(contact.city, new List<Contact>());
                            }
                            cityDict[contact.city].Add(contact);
                        }

                    }

                    foreach (var (key, value) in cityDict)
                    {
                        Console.WriteLine("\nContacts found in " + key + " are:");
                        foreach (Contact contact in value)
                        {
                            Console.WriteLine("\nFirst Name\tLast Name\tAddress\tCity\tState\tZip Code\tPhone No.\tEmail Id");
                            Console.WriteLine(contact.firstName + "\t\t" + contact.lastName + "\t\t" + contact.address + "\t" + contact.city + "\t" + contact.state + "\t" + contact.zip + "\t" + contact.phone + "\t" + contact.email);
                        }
                    }
                    break;
                case 2:
                    foreach (var addressBook in addressBooks)
                    {

                        foreach (Contact contact in addressBook.contacts)
                        {
                            if (!stateDict.ContainsKey(contact.state))
                            {
                                stateDict.Add(contact.state, new List<Contact>());
                            }
                            stateDict[contact.state].Add(contact);
                        }

                    }

                    foreach (var (key, value) in stateDict)
                    {
                        Console.WriteLine("\nContacts found in " + key + " are:");
                        foreach (Contact contact in value)
                        {
                            Console.WriteLine("\nFirst Name\tLast Name\tAddress\tCity\tState\tZip Code\tPhone No.\tEmail Id");
                            Console.WriteLine(contact.firstName + "\t\t" + contact.lastName + "\t\t" + contact.address + "\t" + contact.city + "\t" + contact.state + "\t" + contact.zip + "\t" + contact.phone + "\t" + contact.email);
                        }
                    }
                    break;
            }
        }

        public void CountPersonByCityAndState()
        {
            List<AddressBook> addressBooks = new List<AddressBook>();

            foreach (string bookName in addressDict.Keys)
            {
                addressBooks.Add(addressDict[bookName]);
            }
            foreach (AddressBook addressBook in addressBooks)
            {
                var cities = addressBook.contacts.GroupBy(s => s.city);
                var states = addressBook.contacts.GroupBy(s => s.state);

                Console.WriteLine("\nCity\tNumber Of People");
                foreach (var pair in cities)
                {
                    Console.WriteLine(pair.Key + " \t " + pair.Count());
                }

                Console.WriteLine("State\tNumber Of People");
                foreach (var pair in states)
                {
                    Console.WriteLine(pair.Key + " \t " + pair.Count());
                }
            }
        }
    }
}
