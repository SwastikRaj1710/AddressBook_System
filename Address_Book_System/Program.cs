﻿using System;

namespace Address_Book_System
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Address Book Program");
            AddressBookSystem addressBookSystem = new AddressBookSystem();
            while (true)
            {
                Console.WriteLine("\nMenu");
                Console.WriteLine("1. Add a new Address Book to the system");
                Console.WriteLine("2. Access an existing Address Book and its Contacts");
                Console.WriteLine("3. Search people present in the same city or state");
                Console.WriteLine("4. Exit");
                Console.WriteLine("Enter your choice");
                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Adding a new address book to the system");
                        addressBookSystem.AddAddressBook();
                        break;
                    case 2:
                        Console.WriteLine("Accessing an address book");
                        addressBookSystem.AccessAddressBook();
                        break;
                    case 3:
                        Console.WriteLine("Searching people living in a given state or city");
                        addressBookSystem.SearchPersonAcrossAllAddressBooks();
                        break;
                    case 4:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Incorrect Choice!");
                        break;
                }
            }
        }
    }
}