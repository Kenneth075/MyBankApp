using MyBankApp.Implementation.CustomerImplementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyBankApp.Interfaces.CustomerInterface;

namespace MyBankApp
{
    internal class HomePage
    {
        ICustomerRegistration _reg;
        ILogin _log;
        public HomePage(ICustomerRegistration reg, ILogin log)
        {
            _reg = reg;
            _log = log;
        }

        public void MyHomePage()
        {
            Console.WriteLine("Click 1 to register\nClick 2 to Login");
            string choice = Console.ReadLine(); 
            if (choice == "1")
            {
                
                _reg.CustomerRegister();
            }
            if (choice == "2")
            {
                _log.LogMeIn();

            }
        }
    }
}
