using MyBankApp.Models.CustomerModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBankApp.Interfaces.AccountInterface
{
    internal interface ITransfer
    {
        void TransferMoney(Customer loggedInCustomer);
    }
}
