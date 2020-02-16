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
    public class BudgetController : Controller
    {
        private readonly ILogger<BudgetController> _logger;

        public BudgetController(ILogger<BudgetController> logger)
        {
            _logger = logger;
        }

        public IActionResult Budget()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Budget(string Name, int Amount, int Priority, int Rise)
        {
            try
            {
                // IList<Item> itemList = new List<Item>();
                // Item to_add = new Item(Name, Amount, Priority, Rise);
                // itemList.Add(to_add);
                // ViewData["items"] = itemList;
                // return View("Item");
                return View();
            }
            catch
            {
                return View();
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}