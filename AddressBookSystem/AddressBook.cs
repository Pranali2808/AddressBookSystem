using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AddressBookSystem
{
    class AddressBook
    {
        private static List<PersonsDetails> contacts = new List<PersonsDetails>();

        private static Dictionary<string, List<PersonsDetails>> addressBook = new Dictionary<string, List<PersonsDetails>>();

        public static Dictionary<string, List<PersonsDetails>> cityBook = new Dictionary<string, List<PersonsDetails>>();
        public static Dictionary<string, List<PersonsDetails>> stateBook = new Dictionary<string, List<PersonsDetails>>();

        public static void AddTo(string name)
        {
            addressBook.Add(name, contacts);
        }
        public static void AddContact()
        {
            PersonsDetails person = new PersonsDetails();

            Console.Write(" Enter your First name : ");
            person.FirstName = Console.ReadLine();
            Console.Write(" Enter your Last name : ");
            person.LastName = Console.ReadLine();
            Console.Write(" Enter your Address : ");
            person.Address = Console.ReadLine();
            Console.Write(" Enter your City : ");
            person.City = Console.ReadLine();
            Console.Write(" Enter your State : ");
            person.State = Console.ReadLine();
            Console.Write(" Enter your Zip Code : ");
            person.ZipCode = Console.ReadLine();
            Console.Write(" Enter your Phone Number : ");
            person.PhoneNumber = Console.ReadLine();
            Console.Write(" Enter your Email-ID : ");
            person.Email = Console.ReadLine();

            contacts.Add(person);
            Console.WriteLine("\n {0}'s contact succesfully added", person.FirstName);
        }

        public static void Details()
        {
            if (contacts.Count == 0)
            {
                Console.WriteLine("Currently there are no people added in your address book.");
            }
            else
            {
                Console.WriteLine("Here is the list and details of all the contacts in your addressbook.");

                foreach (var Detailing in contacts)
                {
                    Console.WriteLine("First name : " + Detailing.FirstName);
                    Console.WriteLine("Last name : " + Detailing.LastName);
                    Console.WriteLine("Address : " + Detailing.Address);
                    Console.WriteLine("State : " + Detailing.State);
                    Console.WriteLine("City : " + Detailing.City);
                    Console.WriteLine("Zip Code : " + Detailing.ZipCode);
                    Console.WriteLine("Phone number = " + Detailing.PhoneNumber);
                }
            }
        }

        public static void ReadAddressBookUsingStreamReader()
        {
            Console.WriteLine("The contact List using StreamReader method ");

            string path = @"D:\Projects\AddressBookSystem\AddressBookSystem\Files\AddressBookWriter.txt";
            using (StreamReader se = File.OpenText(path))
            {
                string s = " ";
                while ((s = se.ReadLine()) != null)
                {
                    Console.WriteLine(s);
                }

            }
        }

        public static void WriteAddressBookUsingStreamWriter()
        {
            string path = @"D:\Projects\AddressBookSystem\AddressBookSystem\Files\AddressBookWriter.txt";
            using (StreamWriter se = File.AppendText(path))
            {
                foreach (KeyValuePair<string, List<PersonsDetails>> item in addressBook)
                {
                    foreach (var items in item.Value)
                    {
                        se.WriteLine("First Name -" + items.FirstName);
                        se.WriteLine("Last Name -" + items.LastName);
                        se.WriteLine("Address -" + items.Address);
                        se.WriteLine("Phone Number - " + items.PhoneNumber);
                        se.WriteLine("Email ID -" + items.Email);
                        se.WriteLine("City -" + items.City);
                        se.WriteLine("State -" + items.State);
                        se.WriteLine("ZIP Code -" + items.ZipCode);
                    }
                    se.WriteLine("--------------------------------------------------------------");
                }
                se.Close();
                Console.WriteLine(File.ReadAllText(path));
            }
        }
    }
}



