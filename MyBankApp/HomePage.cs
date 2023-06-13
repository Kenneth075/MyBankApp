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
            string choice;
            do
            {
                Console.WriteLine("Welcome to United Bank of Nigeria\n\nPress 1 to register\nPress 2 to Login\nPress 3 to exit");
                choice = Console.ReadLine();
                if (choice == "1")
                {

                    _reg.CustomerRegister();
                }
                if (choice == "2")
                {
                    _log.LogMeIn();

                }
                if (choice == "3")
                {
                    Console.WriteLine("Thank you for banking with us");
                    Environment.Exit(0);
                }

            }while (!int.TryParse(choice, out _) || int.Parse(choice) != 1 || int.Parse(choice) != 2 || int.Parse(choice) != 3);
        }

    }
    
}
