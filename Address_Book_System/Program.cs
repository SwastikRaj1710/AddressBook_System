using System;

namespace Address_Book_System
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Address Book Program");
            AddressBook addressBook = new AddressBook();
            while (true)
            {
                Console.WriteLine("\nMenu");
                Console.WriteLine("1. Add a new Contact to the Address Book");
                Console.WriteLine("2. Editing an existing Contact in the Address Book");
                Console.WriteLine("3. Exit");
                Console.WriteLine("Enter your choice");
                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Adding a new contact to the address book");
                        addressBook.AddContact();
                        break;
                    case 2:
                        Console.WriteLine("Editing an existing contact in the address book");
                        addressBook.EditContact();
                        break;
                    case 3:
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