using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using budgetApp.Models;

namespace budgetApp.Controllers
{
    public class TmpController : Controller
    {
        private readonly ILogger<BudgetController> _logger;

        public TmpController(ILogger<BudgetController> logger)
        {
            _logger = logger;
        }
        public IActionResult Budget(string mode = "new", List<Item> Info = null)
        {
            return View(new LoadModel {Mode = mode, Info = InOut.readBudget()});
        }
        
        //public ActionResult Save(List<Item> Budget)
        public ActionResult Save(List<Item> Budget)
        {
            foreach(Item x in Budget)
            {
                Console.WriteLine("-----");
                 Console.WriteLine(x);
            }
            //InOut.saveBudget(Budget);
            return View("Budget", new LoadModel {Mode = "load", Info = InOut.readBudget()});
        }
        //[HttpPost]
        /* public ActionResult Budget(string Name, int Amount, int Priority, int Rise)
        {
            try
            {
                // Item item = new Item(Name, Amount, Priority, Rise);
                IList<Item> itemList = new List<Item>();
                Item to_add = new Item(Name, Amount, Priority, Rise);
                itemList.Add(to_add);
                // ViewData["items"] = itemList;
                // return View("Item");
                return View();
            }
            catch
            {
                return View();
            }
        } */

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}