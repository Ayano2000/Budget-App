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
        private static Budget budget;

        private readonly ILogger<BudgetController> _logger;

        public BudgetController(ILogger<BudgetController> logger)
        {
            _logger = logger;
        }

        public IActionResult Budget() => View();
        
        [HttpGet]
        public IActionResult FixedBudget() => View();

        [HttpGet]
        public IActionResult VariableBudget() => View();

        public IActionResult Item => View();

        [HttpPost]
        public ActionResult FixedBudget(string dummy) // dummy is necessary to prevent same params and return types on methods named the same
        {
            try
            {
                IList<Item> FixedItems = new List<Item>();
                FixedItems.Add(new Item("Salary", System.Convert.ToInt32(Request.Form["Salary"]), 5, 1, false));
                FixedItems.Add(new Item("Other", System.Convert.ToInt32(Request.Form["Other"]), 5, 1, false));
                FixedItems.Add(new Item("Rent", System.Convert.ToInt32(Request.Form["Rent"]), 5, 1, true));
                FixedItems.Add(new Item("Insurance", System.Convert.ToInt32(Request.Form["Insurance"]), 5, 1, true));
                FixedItems.Add(new Item("MedicalAid", System.Convert.ToInt32(Request.Form["MedicalAid"]), 5, 1, true));

                budget = new Budget(FixedItems);
                // budget.PrintBudget();
                return View();
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult VariableBudget(string dummy) // dummy is necessary to prevent same params and return types on methods named the same
        {
            try
            {
                Item to_add = new Item(Request.Form["Name"],
                                        System.Convert.ToInt32(Request.Form["Amount"]),
                                        System.Convert.ToInt32(Request.Form["Priority"]),
                                        System.Convert.ToInt32(Request.Form["Rise"]),
                                        System.Convert.ToBoolean(Request.Form["Expense"]));
                IList<Item> VariableBudget = budget.budget;
                VariableBudget.Add(to_add);
                budget.budget = VariableBudget;
                budget.PrintBudget();
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