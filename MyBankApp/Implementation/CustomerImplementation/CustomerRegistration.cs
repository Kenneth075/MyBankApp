using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyBankApp.Interfaces.CustomerInterface;
using MyBankApp.Models.CustomerModel;

namespace MyBankApp.Implementation.CustomerImplementation
{
    internal class CustomerRegistration: RegHelper, ICustomerRegistration
    {
        public void CustomerRegister()
        {
            var id = CustomerId();
            var name= CustomerName();
            var email= CustomerEmail();
            var pwd=CustomerPassword();
            
            Customer customer = new Customer(id,name,email,pwd);

            using (var writer = new StreamWriter("Customers.txt"))
            {
                writer.WriteLine($" {customer.CustomerId}, {customer.Fullname}, {customer.Email}, {customer.Password}");
            }
            Console.WriteLine($"Congrats, {customer.Fullname} has been added to the Customer.txt File.");
        }
    }
}
