using MyBankApp.Interfaces.AccountInterface;
using MyBankApp.Models.AccountModel;
using MyBankApp.Models.CustomerModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBankApp.Implementation.AccountImplementation
{
    internal class Deposit : AccountHelper, IDeposit
    {
        //Deposit fields
        private string? AccountToDepositTo { get; set; }
        private string? AmountToDeposit { get; set; }
        private decimal CleanAmountToDeposit { get; set; }




        public void DepositMoney(Customer LoggedInCustomer)
        {
            Console.Clear();

            ShowAllAccount(LoggedInCustomer);

            Console.Write("Type in the account number you want to send money to.>>");
            AccountToDepositTo = Console.ReadLine();

            Console.Write("Enter the amount you want to send>>>");
            AmountToDeposit = Console.ReadLine().Trim();
            CleanAmountToDeposit = decimal.Parse(AmountToDeposit);

            List<Account> accounts = ReadAccountsFromFile("Accounts.txt");

            List<Account> loggedInUserAccounts = accounts.Where(account => account.Customerid == LoggedInCustomer.CustomerId).ToList();

            Account? accountToUpdate = loggedInUserAccounts.FirstOrDefault(account => account.AccountNumber == AccountToDepositTo);

            if (accountToUpdate is null)
            {
                Console.Clear();
                Console.WriteLine("The account entered does not exist!\nPlease enter a valid account number>>");

            }

            else if (accountToUpdate != null)
            {
                accountToUpdate.Balance += CleanAmountToDeposit;
                Console.WriteLine($"You have successfully deposited {CleanAmountToDeposit} into your account with account number {AccountToDepositTo}");

            }
            // Update the Account.txt file with the new balance
            using (StreamWriter writer = new StreamWriter("Accounts.txt"))
            {
                foreach (var account in accounts)
                {
                    writer.WriteLine($"| {account.Customerid,-12} | {account.Fullname,-12} | {account.AccountNumber,-12} | {account.AccountType,-8} | {account.Balance} |");
                }
            }
        }
    }
}
