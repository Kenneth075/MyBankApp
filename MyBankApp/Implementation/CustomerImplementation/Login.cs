using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Transactions;
using MyBankApp.Interfaces.CustomerInterface;
using MyBankApp.Models.CustomerModel;

namespace MyBankApp.Implementation.CustomerImplementation
{
    internal class Login : RegHelper,ILogin
    {
        private IDashboard _dash;
        public Login(IDashboard dash)
        {
            _dash = dash;
        }

        public void LogMeIn()
        {
            List<Customer> customers = ReadCustomersFromFile("Customers.txt");
            string emailPattern = @"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$";
            string passwordPattern = @"^(?=.*[a-zA-Z0-9])(?=.*[@#$%^&+=])(?=.{6,})";
            string? myemail;
            string? mypassword;

            Console.WriteLine("------Welcome to your Login portal-------");
            do
            {
                Console.Write("Enter your email. (e.g, ken@gmail.com):>>> ");
                myemail = Console.ReadLine();
            } while (!Regex.IsMatch(myemail, emailPattern));

            do
            {
                Console.WriteLine("password should not be less than 6 characters and should contain a special character: @ ,#,* ");
                Console.Write("Enter your password: ");
                mypassword = Console.ReadLine();
            } while (!Regex.IsMatch(mypassword, passwordPattern));


            Customer? loggedInUser = customers.FirstOrDefault(c => c.Email == myemail && c.Password == mypassword);

            if (loggedInUser != null)
            {
                Console.Clear();
                Console.WriteLine("Successfully Logged in!");
                _dash.MyDashBoard(loggedInUser);
            }
            else
            {
                Console.WriteLine("\n\nInvalid email or password.");
                Console.WriteLine("Please try again or register a new account.");
            }

           
        }
    }
}
