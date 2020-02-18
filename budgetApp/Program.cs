using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using budgetApp.Models;

namespace budgetApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
            List<Item> items =InOut.readBudget();
            foreach(Item Wank in items){
                Console.WriteLine(Wank.ToString());
            }
            Item produce = new Item("Wetknees",100, 2, 4,true);
            items.Add(produce);
            InOut.saveBudget(items);
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
