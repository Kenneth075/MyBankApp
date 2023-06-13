using MyBankApp.Implementation.CustomerImplementation;
using MyBankApp.Models.CustomerModel;
using MyBankApp.Interfaces.CustomerInterface;
using Microsoft.Extensions.DependencyInjection;

namespace MyBankApp
{
    internal class Program
    {
        
        public static void Main(string[] args)
        {
            var services = new ServiceCollection();

            services.AddSingleton<HomePage>();
            services.AddScoped<ICustomerRegistration, CustomerRegistration>();
            services.AddScoped<ILogin, Login>();

            var serviceProvider =services.BuildServiceProvider();
            var home = serviceProvider.GetRequiredService<HomePage>();

            home.MyHomePage();


             
        }

    }
}