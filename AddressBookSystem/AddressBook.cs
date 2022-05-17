using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Json.Net;

namespace AddressBookSystem
{
    class AddressBook
    {
        List<PersonsDetails> contactList;
        Dictionary<string, List<PersonsDetails>> addressBookDict;
        public static string connectionstring = @"Data Source=DESKTOP-9LLI94A\SQLEXPRESS;Initial Catalog = AddressBookService; Integrated Security = True";
        SqlConnection connection = null;

        public AddressBook()
        {
            contactList = new List<PersonsDetails>();
            addressBookDict = new Dictionary<string, List<PersonsDetails>>();
        }
        public List<PersonsDetails> AddNewContact()
        {
            Console.WriteLine("Enter how many contacts you want to add?");
            int howMany = Convert.ToInt32(Console.ReadLine());
            for (int i = 1; i <= howMany; i++)
            {

                Console.WriteLine("\nEnter your First Name: ");
                string firstName = Console.ReadLine();
                Console.WriteLine("Enter your Last Name: ");
                string lastName = Console.ReadLine();
                Console.WriteLine("Enter your Address: ");
                string address = Console.ReadLine();
                Console.WriteLine("Enter your City: ");
                string city = Console.ReadLine();
                Console.WriteLine("Enter your State: ");
                string state = Console.ReadLine();
                Console.WriteLine("Enter your Zipcode: ");
                int zipcode = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter your Phone Number: ");
                long phoneNumber = Convert.ToInt64(Console.ReadLine());
                Console.WriteLine("Enter your Email-ID: ");
                string email = Console.ReadLine();

                if (CheckIfAlreadyPresent(firstName, lastName))
                    Console.WriteLine("Already exist");
                else
                {
                    contactList.Add(new PersonsDetails()
                    {
                        FirstName = firstName,
                        LastName = lastName,
                        Address = address,
                        City = city,
                        State = state,
                        ZipCode = zipcode,
                        Email = email,
                        PhoneNumber = phoneNumber
                    });
                }
            }
            return contactList;
        }
        public bool CheckIfAlreadyPresent(string firstName, string lastName) //using lambda for no duplicate entry
        {
            return contactList.Any(x => x.FirstName == firstName && x.LastName == lastName);
        }

        public void ViewContact()
        {
            int count = 1;
            foreach (var contact in contactList)
            {
                Console.WriteLine("Person {0} Details: ", count);
                Console.WriteLine("First Name: " + contact.FirstName);
                Console.WriteLine("Last Name: " + contact.LastName);
                Console.WriteLine("Address: " + contact.Address);
                Console.WriteLine("City: " + contact.City);
                Console.WriteLine("State: " + contact.State);
                Console.WriteLine("ZipCode: " + contact.ZipCode);
                Console.WriteLine("Phone Number: " + contact.PhoneNumber);
                Console.WriteLine("Email ID: " + contact.Email);
                count++;
            }
        }
        public void EditContact(string input)
        {
            for (int i = 0; i < contactList.Count; i++)
            {
                if (contactList[i].FirstName == input)
                {
                    Console.WriteLine("\n Choose the field you want to edit " +
                        "\n 1. First Name \n 2 Last Name \n 3. Address \n 4. City \n 5. State \n 6. ZipCode \n 7. Phone Number \n 8. Email-ID\n");
                    int edit = Convert.ToInt32(Console.ReadLine());
                    switch (edit)
                    {
                        case 1:
                            Console.WriteLine("Enter New First Name: ");
                            contactList[i].FirstName = Console.ReadLine();
                            break;
                        case 2:
                            Console.WriteLine("Enter New Last Name: ");
                            contactList[i].LastName = Console.ReadLine();
                            break;
                        case 3:
                            Console.WriteLine("Enter New Address: ");
                            contactList[i].Address = Console.ReadLine();
                            break;
                        case 4:
                            Console.WriteLine("Enter New City: ");
                            contactList[i].City = Console.ReadLine();
                            break;
                        case 5:
                            Console.WriteLine("Enter New State: ");
                            contactList[i].State = Console.ReadLine();
                            break;
                        case 6:
                            Console.WriteLine("Enter New ZipCode: ");
                            contactList[i].ZipCode = Convert.ToInt32(Console.ReadLine());
                            break;
                        case 7:
                            Console.WriteLine("Enter New Phone Number: ");
                            contactList[i].PhoneNumber = Convert.ToInt64(Console.ReadLine());
                            break;
                        case 8:
                            Console.WriteLine("Enter New Email-ID: ");
                            contactList[i].Email = Console.ReadLine();
                            break;
                        default:
                            Console.WriteLine("Invalid Input");
                            break;
                    }
                }
            }
        }
        public void DeleteContact(string fName, string lName)
        {
            for (int i = 0; i < contactList.Count; i++)
            {
                if (contactList[i].FirstName == fName && contactList[i].LastName == lName)
                {
                    Console.WriteLine("Contact {0} {1} Deleted Successfully from Address Book.", contactList[i].FirstName, contactList[i].LastName);
                    contactList.RemoveAt(i);
                }
            }
        }
        public void AddNewAddressBook()
        {
            Console.WriteLine("Howmany number of address books you want to add? ");
            int numberOfBooks = Convert.ToInt32(Console.ReadLine());
            while (numberOfBooks > 0)
            {
                Console.WriteLine("Enter name of the address book:");
                string addBookName = Console.ReadLine();
                if (addressBookDict.ContainsKey(addBookName))
                {
                    Console.WriteLine("Address Book Name Already Exists");
                }
                else
                {
                    AddressBook books = new AddressBook();
                    List<PersonsDetails> list = books.AddNewContact();
                    addressBookDict.Add(addBookName, list);
                }
                foreach (KeyValuePair<string, List<PersonsDetails>> item in addressBookDict)
                {
                    Console.WriteLine($"key:{item.Key} value:{item.Value}");
                }
                numberOfBooks--;
            }
        }
        public void ViewAddressBook()
        {
            int count = 1;
            foreach (KeyValuePair<string, List<PersonsDetails>> user in addressBookDict)
            {
                Console.WriteLine("\nName of Address Book: " + user.Key);
                foreach (PersonsDetails contact in user.Value)
                {
                    Console.Write("\nPerson " + count + " Details:\n");
                    Console.Write(" FirstName: " + contact.FirstName);
                    Console.Write(" LastName: " + contact.LastName);
                    Console.Write(" City: " + contact.City);
                    Console.Write(" State: " + contact.State);
                    Console.Write(" Address: " + contact.Address);
                    Console.Write(" zipCode: " + contact.ZipCode);
                    Console.Write(" PhoneNo: " + contact.PhoneNumber);
                    Console.Write(" Email: " + contact.Email);
                    count++;
                }
            }
        }
        public void SearchPersonInCityOrState()
        {
            Console.WriteLine("enter the city or state name");
            string city = Console.ReadLine();
            int found = 0;
            foreach (KeyValuePair<string, List<PersonsDetails>> user in addressBookDict)
            {
                foreach (PersonsDetails contact in user.Value)
                {
                    if (contact.City == city || contact.State == city)
                    {
                        Console.WriteLine(contact.FirstName);
                        found = 1;
                    }
                }
            }
            if (found == 0)
                Console.WriteLine("No record found");
        }
        public void ViewPersonInCityOrState()
        {
            Console.WriteLine("enter the city or state name");
            string city = Console.ReadLine();
            foreach (KeyValuePair<string, List<PersonsDetails>> user in addressBookDict)
            {
                foreach (PersonsDetails contact in user.Value)
                {
                    if (contact.City == city || contact.State == city)
                    {
                        Console.WriteLine("FirstName: " + contact.FirstName);
                        Console.WriteLine("LastName: " + contact.LastName);
                        Console.WriteLine("City: " + contact.City);
                        Console.WriteLine("State: " + contact.State);
                        Console.WriteLine("Address: " + contact.Address);
                        Console.WriteLine("zipCode: " + contact.ZipCode);
                        Console.WriteLine("Email: " + contact.Email);
                        Console.WriteLine("PhoneNo: " + contact.PhoneNumber);
                    }
                }
            }
        }
        public void CountByCityOrState()
        {
            int count = 0;
            Console.WriteLine("enter the city or state name");
            string city = Console.ReadLine();
            foreach (KeyValuePair<string, List<PersonsDetails>> user in addressBookDict)
            {
                count += user.Value.Count(x => x.City == city || x.State == city);
            }
            Console.WriteLine("No of persons in city " + city + " is " + count);
        }
        public void SortPersonName()
        {
            Console.WriteLine("Choose option(1-4)\n1: Sort by Name\n2: Sort by City\n3: Sort by State\n4: Sort by Zipcode\n");
            int choice = Convert.ToInt32(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    foreach (KeyValuePair<string, List<PersonsDetails>> user in addressBookDict)
                    {
                        user.Value.Sort((emp1, emp2) => emp1.FirstName.CompareTo(emp2.FirstName));
                    }
                    break;
                case 2:
                    foreach (KeyValuePair<string, List<PersonsDetails>> user in addressBookDict)
                    {
                        user.Value.Sort((emp1, emp2) => emp1.City.CompareTo(emp2.City));
                    }
                    break;
                case 3:
                    foreach (KeyValuePair<string, List<PersonsDetails>> user in addressBookDict)
                    {
                        user.Value.Sort((emp1, emp2) => emp1.State.CompareTo(emp2.State));
                    }
                    break;
                case 4:
                    foreach (KeyValuePair<string, List<PersonsDetails>> user in addressBookDict)
                    {
                        user.Value.Sort((emp1, emp2) => emp1.ZipCode.CompareTo(emp2.ZipCode));
                    }
                    break;
                default:
                    Console.WriteLine("Choose between 1-4");
                    break;
            }
            ViewAddressBook();
        }
       
        //UC 16 - Method to retrieve entries from DB 
        public void GetEntriesFromDB(string query)
        {
            try
            {
                DataSet dataSet = new DataSet();
                using (connection = new SqlConnection(connectionstring))
                {
                    connection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    adapter.Fill(dataSet);
                    foreach (DataRow dataRow in dataSet.Tables[0].Rows)
                    {
                        Console.WriteLine(dataRow["FirstName"] + ", " + dataRow["LastName"] + ", " + dataRow["Address"] + ", " + dataRow["City"] + ", " + dataRow["State"] + ", " + dataRow["Zip"] + ", " + dataRow["PhoneNumber"] + ", " + dataRow["Email"]);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }
    }
}


