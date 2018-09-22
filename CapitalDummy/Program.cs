using CapitalDummy.Models;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace CapitalDummy
{
    class Program
    {
        static async Task Main(string[] args)
        {
            PrintInColor($"==== Challenge Starting ====", ConsoleColor.Green);

            var accountInfo = await IocFactory
                .CreateIoc()
                .GetRequiredService<IAccountInformant>()
                .RetrieveAccountSummary(Environment.CapitalDummyCredentials);

            PrintChallengeResults(accountInfo);

            PrintInColor($"==== End of Challenge ====", ConsoleColor.Green);
            Console.ReadLine();
        }

        private static void PrintInColor(string message, ConsoleColor color)
        {
            var previousColor = Console.ForegroundColor;
            
            Console.ForegroundColor = color;
            Console.WriteLine();
            Console.WriteLine(message);
            Console.WriteLine();
            Console.ForegroundColor = previousColor;
        }

        private static void PrintChallengeResults(AccountSummary accountInfo)
        {
            Console.WriteLine($"==== Account Information ====");
            Console.WriteLine();
            Console.WriteLine(JsonConvert.SerializeObject(accountInfo, Formatting.Indented));
            Console.WriteLine();
            Console.WriteLine($"==== End of Account Information ====");
        }
    }
}
