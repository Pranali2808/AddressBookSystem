using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("welcome to addressbook program");
            // UC1 : Ability to create a Contacts in Address Book with first and last names, address,
            // city, state, zip, phone number and email...
            AddressBook.Display();
            AddressBook.AddContact();
            Console.ReadLine();
        }
    }
}
