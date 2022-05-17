using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookSystem
{
    class PersonsDetails
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int ZipCode { get; set; }
        public long PhoneNumber { get; set; }
        public string Email { get; set; }
        public override string ToString()
        {
            return $"firstname:{FirstName} lastname:{LastName} address:{Address} city:{City} state:{State} zipcode:{ZipCode} phone:{PhoneNumber} email:{Email}";
        }
    }
}