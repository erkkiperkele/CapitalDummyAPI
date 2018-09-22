using CapitalDummy.Services;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace CapitalDummy
{
    public static class IocFactory
    {
        public static IServiceProvider ServiceProvider { get; set; }

        public static IServiceProvider CreateIoc()
        {
            var serviceCollection = new ServiceCollection();

            serviceCollection.AddScoped<IAccountService, AccountService>();
            serviceCollection.AddScoped<IAccountInformant, AccountInformant>();

            ServiceProvider = serviceCollection.BuildServiceProvider();

            return ServiceProvider;
        }
    }
}
