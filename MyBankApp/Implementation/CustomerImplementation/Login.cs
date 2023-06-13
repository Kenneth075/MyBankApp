using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using MyBankApp.Interfaces.CustomerInterface;

namespace MyBankApp.Implementation.CustomerImplementation
{
    internal class Login : ILogin
    {
        public void LogMeIn()
        {
            Console.WriteLine("------Login Portal--------");
            Console.WriteLine("Enter your email");
            var email = Console.ReadLine();

            Console.WriteLine("Enter your password");
            var pwd = Console.ReadLine();
            Console.WriteLine("Login is running!");
        }
    }
}
