using MyBankApp.Interfaces.CustomerInterface;
using MyBankApp.Models.AccountModel;
using MyBankApp.Models.CustomerModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBankApp.Implementation.AccountImplementation
{
    internal class AccountHelper
    {
        private readonly IDashboard _dash;
        public void PromptToViewAccount(Customer loggedInCustomer)
        {
            string choice;
            bool isValid;
            do
            {
                Console.WriteLine("\n>>To view all your accounts press Y \n>>To go back to your Menu Press N");
                choice = Console.ReadLine();
                if (choice == "Y" || choice == "y")
                {
                    isValid = true;
                    ShowAllAccount(loggedInCustomer);
                }
                else if (choice == "N" || choice == "n")
                {
                    isValid = true;
                    Console.Clear();
                    Console.WriteLine("You have been redirected to your Dashboard.\n");
                    _dash.MyDashBoard(loggedInCustomer);

                }
                else
                {
                    isValid = false;
                    Console.WriteLine(" Invalid input! ");
                    Console.WriteLine("Please choose either 'Y' or 'N' when prompted again ?");
                }
            } while (isValid);

        }
        public static List<Account> ReadAccountsFromFile(string filePath)
        {
            List<Account> accounts = new List<Account>();

            using (StreamReader reader = new StreamReader(filePath))
            {
                string? line;
                while ((line = reader.ReadLine()) != null)
                {
                    if (!string.IsNullOrWhiteSpace(line))
                    {
                        string[] fields = line.Split('|');

                        if (fields.Length >= 5)
                        {
                            string id = fields[1].Trim();
                            string name = fields[2].Trim();
                            string accNo = fields[3].Trim();
                            string accType = fields[4].Trim();
                            decimal Bal = decimal.Parse(fields[5].Trim());

                            Account account = new Account(id, name, accNo, accType, Bal);
                            accounts.Add(account);
                        }
                    }
                }
            }

            return accounts;
        }

        public void ShowAllAccount(Customer loggedInCustomer)
        {
            List<Account> accounts = ReadAccountsFromFile("Accounts.txt");

            List<Account> loggedInUserAccounts = accounts.Where(account => account.Customerid == loggedInCustomer.CustomerId).ToList();

            string allprints = "";
            foreach (Account acc in accounts)
            {
                allprints += $"|   {acc.Customerid,-14}  |   {acc.Fullname,-14}  |   {acc.AccountNumber,-15}  |  {acc.AccountType,-15}  |  {acc.Balance,-16}  |\n";
            }
            Console.WriteLine("|-------------------|-------------------|--------------------|-------------------|--------------------|");
            Console.WriteLine("|     CUSTOMER_ID   |    FULLNAME       |     ACCOUNT_NO     |   ACCOUNT_TYPE    |   ACCOUNT BALANCE  |");
            Console.WriteLine("|-------------------|-------------------|--------------------|-------------------|--------------------|");
            Console.WriteLine(allprints);
            Console.WriteLine("|-----------------------------------------------------------------------------------------------------|");
        }

    }
}



