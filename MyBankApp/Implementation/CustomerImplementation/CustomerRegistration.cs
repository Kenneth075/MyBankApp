using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyBankApp.Interfaces.CustomerInterface;
using MyBankApp.Models.CustomerModel;

namespace MyBankApp.Implementation.CustomerImplementation
{
    internal class CustomerRegistration : ICustomerRegistration
    {
        public void CustomerRegister()
        {
            var id = Guid.NewGuid();

            Console.WriteLine("Enter your fullname");
            string fullname = Console.ReadLine();

            Console.WriteLine("Enter your Email");
            string email = Console.ReadLine();

            Console.WriteLine("Enter your password");
            string password = Console.ReadLine();

            Customer customer = new Customer(id,fullname,email,password);

            using (var writer = new StreamWriter("Customers.txt"))
            {
                writer.WriteLine($" {customer.Id}, {customer.Name}, {customer.Email}, {customer.Password}");
            }
            Console.WriteLine($"Congrats, {customer.Name} has been added to the Customer.txt File.");
        }
    }
}
