using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _00_JunkYard
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<Customer> line = new Queue<Customer>();

            // we need to create customers...
            Customer customerA = new Customer(1, "Terry", "Brown");
            Customer customerB = new Customer(2, "Marjorie", "Sandoval");
            Customer customerC = new Customer(3, "Tim", "Timmy");
            Customer customerD = new Customer(4, "Jim", "Carey");

            //Queue is FIFO  first in first out
            //Queue doesn't have an add...
            //Queue has an Enqueue
            line.Enqueue(customerA);
            line.Enqueue(customerB);
            line.Enqueue(customerC);
            line.Enqueue(customerD);

            //whose next in line
            var customer = line.Peek();
            Console.WriteLine(customer.FirstName);

            // if we were to remove the first coustomer
            line.Dequeue();
            Console.WriteLine("We just removed the first customer");

            var nextCustomer = line.Peek();
            Console.WriteLine(nextCustomer.FirstName);
            Console.WriteLine("------------------------------------------\n");

            // let's see everyone
            foreach (var item in line)
            {
                Console.WriteLine($"{item.ID}         {item.FirstName}                {item.LastName}");
            }

            Console.WriteLine("----------------------------Dictionary Notes---------------------------");
            //Dictionaries are key/value pair collection
            //A real dictionary key -> 'Apple' (string)
            // the value would be the definition of Apple(string)
            Dictionary<string, string> dictionary = new Dictionary<string, string>();
            dictionary.Add("apple", "a delicious treat");
            dictionary.Add("orange", "Another delicious treat");
            
            
            Dictionary<int, string> employees = new Dictionary<int, string>();
            employees.Add(1, "Terry Brown");
            employees.Add(2, "Marjorie Sandoval");
            employees.Add(3, "Tim Timmy");
            employees.Add(2, "Jim Carey");


            Dictionary<int, Customer> customers = new Dictionary<int, Customer>();
            customers.Add(customerA.ID, customerA);
            customers.Add(customerB.ID, customerB);
            customers.Add(customerC.ID, customerC);
            customers.Add(customerD.ID, customerD);

            //we are using the key/value pair approach
            foreach (var item in customers)
            {
                Console.WriteLine(item.Value.FirstName);
            }

            // we can put constraints on our Dictionary collections
            //while looping through them
            foreach (var item in customers.Keys)
            {
                if (item == 2)
                {
                    Console.WriteLine(item);
                }
            }

            foreach (var item in customers.Values)
            {
                if (item.FirstName == "Tim Timmy".ToLower())
                {
                    Console.WriteLine($"{item.FirstName} {item.LastName} {item.ID}");
                }
            }
            
            //So -> Lets get a customer by their ID
            Customer GiveMeACustomer (int ID)
            {
                foreach (var c in customers)
                {
                    if (c.Key == ID)
                    {
                        return c.Value;
                    }
                }
                return null;

            }
            var terry = GiveMeACustomer(1);
            Console.WriteLine($"ID: {terry.ID} {terry.FirstName} {terry.LastName}");
          
}
    }
   
}
