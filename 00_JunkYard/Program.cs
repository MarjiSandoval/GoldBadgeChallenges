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
            Console.ReadKey();
        }
    }
}
