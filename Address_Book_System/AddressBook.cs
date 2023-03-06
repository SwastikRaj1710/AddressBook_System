using CsvHelper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Security.Policy;

namespace Address_Book_System
{
    public class AddressBook
    {
        public static string connectionString = ConfigurationManager.ConnectionStrings["connection_string"].ConnectionString;
        SqlConnection conn = new SqlConnection(connectionString);
        public List<Contact> contacts = new List<Contact>();

        public bool AddContact(Contact contact)
        {
            SqlCommand cmd = new SqlCommand("spInsertContact", conn);
            try
            {
                conn.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@fname", contact.firstName));
                cmd.Parameters.Add(new SqlParameter("@lname", contact.lastName));
                cmd.Parameters.Add(new SqlParameter("@address", contact.address));
                cmd.Parameters.Add(new SqlParameter("@city", contact.city));
                cmd.Parameters.Add(new SqlParameter("@state", contact.state));
                cmd.Parameters.Add(new SqlParameter("@zip", contact.zip));
                cmd.Parameters.Add(new SqlParameter("@phone", contact.phone));
                cmd.Parameters.Add(new SqlParameter("@email", contact.email));
                cmd.ExecuteNonQuery();
                Console.WriteLine("Inserted to Database");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                conn.Close();
            }
            string fullname = contact.firstName + " " + contact.lastName;

            if(contacts.Find(s => (s.firstName + " " + s.lastName) == fullname) != null)
            {
                Console.WriteLine("The entered contact name already exists");
                return false;
            }
            else
            {
                contacts.Add(contact);
                Console.WriteLine("\nContact added successfully");
                return true;
            }
        }

        public bool EditContact(Contact contact)
        {
            for (int i = 0; i < contacts.Count; i++)
            {
                string fullname = contacts[i].firstName + " " + contacts[i].lastName;
                if (fullname.Equals(contact.firstName + " " + contact.lastName))
                {
                    contacts[i].firstName = contact.firstName;
                    contacts[i].lastName = contact.lastName;
                    contacts[i].address = contact.address;
                    contacts[i].city = contact.city;
                    contacts[i].state = contact.state;
                    contacts[i].zip = contact.zip;
                    contacts[i].phone = contact.phone;
                    contacts[i].email = contact.email;

                    Console.WriteLine("Contact details updated");
                    return true;
                }
            }

            return false;
        }

        public bool DeleteContact(string name)
        {
            for (int i = 0; i < contacts.Count; i++)
            {
                string fullname = contacts[i].firstName + " " + contacts[i].lastName;
                if (fullname.Equals(name))
                {
                    contacts.RemoveAt(i);
                    Console.WriteLine("Contact deleted");
                    return true;
                }
            }
            return false;
        }

        public void AddMultipleContacts()
        {
            Console.WriteLine("Enter the number of contacts to be added");
            int num = Convert.ToInt32(Console.ReadLine());

            for(int i=0;i<num;i++)
            {
                Console.WriteLine("\nEnter the contact details");
                Console.WriteLine("Enter the First Name");
                string firstName = Console.ReadLine();
                Console.WriteLine("Enter the Last Name");
                string lastName = Console.ReadLine();
                string fullname = firstName + " " + lastName;

                if (contacts.Find(s => (s.firstName + " " + s.lastName) == fullname) != null)
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
                AddContact(contact);
            }
            Console.WriteLine("\nContacts added successfully");

        }

        public bool DisplayAllContacts()
        {
            if (contacts == null)
            {
                Console.WriteLine("There are no contacts to be displayed.");
                return false;
            }
            foreach(Contact contact in contacts)
            {
                Console.WriteLine("\nFirst Name\tLast Name\tAddress\tCity\tState\tZip Code\tPhone No.\tEmail Id");
                Console.WriteLine(contact.firstName + "\t\t" + contact.lastName + "\t\t" + contact.address + "\t" + contact.city + "\t" + contact.state + "\t" + contact.zip + "\t\t" + contact.phone + "\t" + contact.email);
            }

            Console.WriteLine("Contacts as fetched from the database");
            SqlCommand cmd = new SqlCommand("spDisplayContacts", conn);
            try
            {
                conn.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter ad = new SqlDataAdapter(cmd);
                DataTable dataTable = new DataTable();
                ad.Fill(dataTable);

                foreach (DataRow row in dataTable.Rows)
                {
                    Console.WriteLine("{0} {1} {2} {3} {4} {5} {6} {7} {8}", row[0], row[1], row[2], row[3], row[4], row[5], row[6], row[7], row[8]);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                conn.Close();
            }
            return true;
        }

        public bool DisplayContactDetails(string name)
        {
            foreach(Contact contact in contacts)
            {
                if((contact.firstName + " " + contact.lastName).Equals(name))
                {
                    Console.WriteLine("\nFirst Name\tLast Name\tAddress\tCity\tState\tZip Code\tPhone No.\tEmail Id");
                    Console.WriteLine(contact.firstName + "\t\t" + contact.lastName + "\t\t" + contact.address + "\t" + contact.city + "\t" + contact.state + "\t" + contact.zip + "\t\t" + contact.phone + "\t" + contact.email);
                    return true;
                }
            }
            return false;
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

        public void ReadWriteCSVFile()
        {
            string path = "D:\\BridgeLabz\\AddressBook_System\\Address_Book_System\\File1.csv";
            Console.WriteLine("1.Read from a csv file");
            Console.WriteLine("2.Write to a csv file");
            Console.WriteLine("Enter your choice");

            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.WriteLine("\nContents of the file are:");
                    if (File.Exists(path))
                    {
                        using var streamReader = File.OpenText(path);
                        using var csvReader = new CsvReader(streamReader, CultureInfo.InvariantCulture);

                        string record;

                        while (csvReader.Read())
                        {
                            for (int i = 0; csvReader.TryGetField<string>(i, out record); i++)
                            {
                                Console.Write($"{record} ");
                            }
                            Console.WriteLine();
                        }

                    }
                    else
                    {
                        Console.WriteLine("File does not exist");
                    }
                    break;
                case 2:
                    using (var streamWriter = new StreamWriter(path))
                    {
                        using (var csvWriter = new CsvWriter(streamWriter, CultureInfo.InvariantCulture))
                        {
                            csvWriter.WriteField("First Name");
                            csvWriter.WriteField("Last Name");
                            csvWriter.WriteField("Address");
                            csvWriter.WriteField("City");
                            csvWriter.WriteField("State");
                            csvWriter.WriteField("Zip");
                            csvWriter.WriteField("Phone Number");
                            csvWriter.WriteField("Email ID");
                            csvWriter.NextRecord();
                            foreach (Contact contact in contacts)
                            {
                                csvWriter.WriteField(contact.firstName + "\t");
                                csvWriter.WriteField(contact.lastName + "\t");
                                csvWriter.WriteField(contact.address);
                                csvWriter.WriteField(contact.city);
                                csvWriter.WriteField(contact.state);
                                csvWriter.WriteField(contact.zip + "\t");
                                csvWriter.WriteField(contact.phone);
                                csvWriter.WriteField(contact.email);
                                csvWriter.NextRecord();
                            }
                        }
                    }
                    Console.WriteLine("Successfully written to the file");
                    break;
            }
        }

        public void ReadWriteJSONFile()
        {
            string path = "D:\\BridgeLabz\\AddressBook_System\\Address_Book_System\\File1.json";
            Console.WriteLine("1.Read from a json file");
            Console.WriteLine("2.Write to a json file");
            Console.WriteLine("Enter your choice");

            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.WriteLine("\nContents of the file are:");
                    if (File.Exists(path))
                    {
                        string resultString = File.ReadAllText(path);
                        List<Contact> Result = JsonConvert.DeserializeObject<List<Contact>>(resultString);
                        foreach (Contact contact in Result)
                        {
                            Console.WriteLine("First Name: " + contact.firstName);
                            Console.WriteLine("Last Name: " + contact.lastName);
                            Console.WriteLine("Address: " + contact.address);
                            Console.WriteLine("City: " + contact.city);
                            Console.WriteLine("State: " + contact.state);
                            Console.WriteLine("Zip Code: " + contact.zip);
                            Console.WriteLine("Phone Number: " + contact.phone);
                            Console.WriteLine("Email Id: " + contact.email);
                            Console.WriteLine();
                        }
                    }
                    else
                    {
                        Console.WriteLine("File does not exist");
                    }
                    break;
                case 2:
                    if (!File.Exists(path))
                    {
                        File.WriteAllText(path, "[]");
                    }
                    string storedJson = File.ReadAllText(path);
                    List<Contact> contactsJson = new List<Contact>();
                    contactsJson = JsonConvert.DeserializeObject<List<Contact>>(storedJson);
                    foreach (Contact contact in contacts)
                    {
                        contactsJson.Add(contact);
                    }
                    string resultJson = JsonConvert.SerializeObject(contactsJson);
                    File.WriteAllText(path, resultJson);
                    Console.WriteLine("Successfully written to the file");
                    break;
            }
        }
    }
}
