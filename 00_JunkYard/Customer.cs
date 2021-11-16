using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _00_JunkYard
{
    public class Customer
    {
        public Customer(int id, string firstName, string lastName)
        {
            ID = id;
            FirstName = firstName;
            LastName = lastName;
        }

        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
       

    }
}
