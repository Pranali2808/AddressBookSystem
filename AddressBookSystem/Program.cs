using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookSystem
{

    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("*********** Address Book Program ************\n");
            AddressBook addressBook = new AddressBook();
            Console.WriteLine("Please choose an option or choose 0 for Exit\n:");
            Console.WriteLine("1: View Contact \n2: Add New Contact(s) \n3: Edit Contact \n4: Delete Contact " +
                "\n5: Add Multiple Addressbook\n6: Find person in city/state\n7: View person in city/state\n8: Count by city/state\n" +
                "9: Sort Contact List\n10: Retrieve from Database\n11: Update contact in database\n12:get data from particular period range\n13:get no of contact by city or state");
           
            int option = Convert.ToInt32(Console.ReadLine());
            switch (option)
            {
                case 1:
                    addressBook.ViewContact();
                    break;
                case 2:
                    addressBook.AddNewContact();
                    addressBook.ViewContact();
                    break;
                case 3:
                    Console.WriteLine("\nEnter First name to edit it's contact details");
                    string input = Console.ReadLine();
                    addressBook.EditContact(input);
                    addressBook.ViewContact();
                    break;
                case 4:
                    Console.WriteLine("\nEnter First name to delete it's contact details");
                    string fName = Console.ReadLine();
                    Console.WriteLine("Enter last name to delete it's contact details");
                    string lName = Console.ReadLine();
                    addressBook.DeleteContact(fName, lName);
                    addressBook.ViewContact();
                    break;
                case 5:
                    addressBook.AddNewAddressBook();
                    addressBook.ViewContact();
                    break;
                case 6:
                    addressBook.SearchPersonInCityOrState();
                    break;
                case 7:
                    addressBook.ViewPersonInCityOrState();
                    break;
                case 8:
                    addressBook.AddNewAddressBook();
                    addressBook.CountByCityOrState();
                    break;
                case 9:
                    addressBook.AddNewAddressBook();
                    addressBook.ViewAddressBook();
                    Console.WriteLine("After sorting:");
                    addressBook.SortPersonName();
                    break;
                case 10:
                    string query = "select * from AddressBook";
                    addressBook.GetEntriesFromDB(query);
                    break;
                case 11:
                    PersonsDetails contact = new PersonsDetails();
                    Console.WriteLine("Enter first name of contact");
                    contact.FirstName = Console.ReadLine();
                    Console.WriteLine("Enter new City");
                    contact.City = Console.ReadLine();
                    Console.WriteLine("Enter new ZipCode");
                    contact.ZipCode = Convert.ToInt32(Console.ReadLine());
                    addressBook.UpdateContactInDB(contact);
                    break;
                case 12:
                    string query1 = "select * from AddressBook where Date_Added between cast('2001-01-01' as date) and getdate()";
                    addressBook.GetEntriesFromDB(query1);
                    break;
                case 13:
                    string queryState = "select COUNT(*) as StateCount, State from AddressBook group by State";
                    string queryCity = "select COUNT(*) as CityCount, City from AddressBook group by City; ";
                    Console.WriteLine("Displaying contacts by City");
                    addressBook.GetCityCountDB(queryCity);
                    Console.WriteLine("Displaying contacts by State");
                    addressBook.GetStateCountDB(queryState);
                    break;
                case 0:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid Input!");
                    break;
                  
            }
            Console.ReadLine();
        }

    }
}
           
           
                      
            
                   
    





