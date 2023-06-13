using MyBankApp.Models.CustomerModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBankApp.Interfaces.CustomerInterface
{
    internal interface IDashboard
    {
        void MyDashBoard(Customer LoggedInCustomer);
    }
}
