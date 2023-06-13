using MyBankApp.Implementation.CustomerImplementation;
using MyBankApp.Models.CustomerModel;
using MyBankApp.Interfaces.CustomerInterface;
using Microsoft.Extensions.DependencyInjection;
using MyBankApp.Interfaces.AccountInterface;
using MyBankApp.Implementation.AccountImplementation;

namespace MyBankApp
{
    internal class Program
    {
        
        public static void Main(string[] args)
        {
            var services = new ServiceCollection();

            
            services.AddScoped<ICustomerRegistration, CustomerRegistration>();
            services.AddScoped<ILogin, Login>();

            services.AddScoped<IDashboard, Dashboard>();
            services.AddScoped<ICreateAccount, CreateAccount>();
            services.AddScoped<IDeposit, Deposit>();
            services.AddScoped<ITransfer, Transfer>();
            services.AddScoped<IWithdraw, Withdraw>();

            services.AddSingleton<HomePage>();

            var serviceProvider =services.BuildServiceProvider();
            var home = serviceProvider.GetRequiredService<HomePage>();

            home.MyHomePage();


             
        }

    }
}