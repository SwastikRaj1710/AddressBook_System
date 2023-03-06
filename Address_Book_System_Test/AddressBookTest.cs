using Address_Book_System;

namespace Address_Book_System_Test
{
    [TestClass]
    public class AddressBookTest
    {
        [TestMethod]
        public void GivenContactDetails_returnSuccessfulAdd()
        {
            AddressBook addressBook = new AddressBook();
            string fname = "Swastik";
            string lname = "Raj";
            string address = "CMRIT";
            string city = "Bengaluru";
            string state = "Karnataka";
            int zip = 560037;
            long phone = 7760484255;
            string email = "srs@gmail.com";

            Contact contact = new Contact(fname, lname, address, city, state, zip, phone, email);

            bool result = addressBook.AddContact(contact);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void GivenContactDetails_returnSuccessfulEdit()
        {
            AddressBook addressBook = new AddressBook();
            string fname = "Swastik";
            string lname = "Raj";
            string address = "CMRIT";
            string city = "Bengaluru";
            string state = "Karnataka";
            int zip = 560037;
            long phone = 7760484255;
            string email = "srs@gmail.com";

            Contact contact = new Contact(fname, lname, address, city, state, zip, phone, email);

            addressBook.AddContact(contact);

            fname = "Swastik";
            lname = "Raj";
            address = "CMR";
            city = "Jamshedpur";
            state = "Jharkhand";
            zip = 560037;
            phone = 7760484255;
            email = "srs@gmail.com";

            Contact cont = new Contact(fname, lname, address, city, state, zip, phone, email);
            bool result = addressBook.EditContact(cont);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void GivenContactDetails_returnSuccessfulDelete()
        {
            AddressBook addressBook = new AddressBook();
            string fname = "Swastik";
            string lname = "Raj";
            string address = "CMRIT";
            string city = "Bengaluru";
            string state = "Karnataka";
            int zip = 560037;
            long phone = 7760484255;
            string email = "srs@gmail.com";

            Contact contact = new Contact(fname, lname, address, city, state, zip, phone, email);

            addressBook.AddContact(contact);
            bool result = addressBook.DeleteContact(fname + " " + lname);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void GivenContactDetails_returnSuccessfulDisplay()
        {
            AddressBook addressBook = new AddressBook();
            string fname = "Swastik";
            string lname = "Raj";
            string address = "CMRIT";
            string city = "Bengaluru";
            string state = "Karnataka";
            int zip = 560037;
            long phone = 7760484255;
            string email = "srs@gmail.com";

            Contact contact = new Contact(fname, lname, address, city, state, zip, phone, email);

            addressBook.AddContact(contact);
            bool result = addressBook.DisplayContactDetails(fname + " " + lname);
            Assert.IsTrue(result);
        }

        public void GivenContactDetails_returnSuccessfulDisplayAll()
        {
            AddressBook addressBook = new AddressBook();
            bool result = addressBook.DisplayAllContacts();
            Assert.IsTrue(result);
        }
    }
}