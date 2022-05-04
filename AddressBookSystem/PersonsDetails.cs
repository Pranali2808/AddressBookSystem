using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookSystem
{
    class PersonsDetails
    {
        public PersonsDetails(string fname, string lname, string address, string city, string state, string phone, string zip, string email)
        {
            Address = address;
            City = city;
            State = state;
            Email = email;
        }

        public string Firstname { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }
}
