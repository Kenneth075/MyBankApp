using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using MyBankApp.Interfaces.CustomerInterface;
using MyBankApp.Models.CustomerModel;

namespace MyBankApp.Implementation.CustomerImplementation
{
    internal class Login :RegHelper, ILogin
    {
        public void LogMeIn()
        {
            List<Customer> customers = ReadCustomersFromFile("Customers.txt");
            string emailPattern = @"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$";
            string passwordPattern = @"^(?=.*[a-zA-Z0-9])(?=.*[@#$%^&+=])(?=.{6,})";
            string? myemail;
            string? mypassword;


            Console.WriteLine("------Login Portal--------");
            Console.WriteLine("Enter your email");
            var email = Console.ReadLine();

            Console.WriteLine("Enter your password");
            var pwd = Console.ReadLine();
            Console.WriteLine("Login is running!");
        }
    }
}
