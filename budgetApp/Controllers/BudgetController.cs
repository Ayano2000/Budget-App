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

        private static bool visited = false;

        private readonly ILogger<BudgetController> _logger;

        public BudgetController(ILogger<BudgetController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Budget() => View();

        [HttpGet]
        public IActionResult FixedBudget() => View();

        [HttpGet]
        public IActionResult GeneralBudget()
        {
            if (visited == false)
            {
                string link = "http://localhost:5000/Budget/FixedBudget";
                return Redirect(link);
            }
            return View();

        }

        [HttpGet]
        public IActionResult VariableBudget()
        {
            if (visited == false)
            {
                string link = "http://localhost:5000/Budget/FixedBudget";
                return Redirect(link);
            }
            return View();
        }

        [HttpPost]
        public ActionResult FixedBudget(string dummy) // dummy is necessary to prevent same params and return types on methods named the same
        {
            visited = true;
            try
            {
                IList<Item> FixedItems = new List<Item>();
                FixedItems.Add(new Item("Salary", System.Convert.ToInt32(Request.Form["Salary"]), 5, 1, false));
                FixedItems.Add(new Item("Other Income", System.Convert.ToInt32(Request.Form["Other"]), 5, 1, false));
                FixedItems.Add(new Item("Rent", System.Convert.ToInt32(Request.Form["Rent"]), 5, 1, true));
                FixedItems.Add(new Item("Insurance", System.Convert.ToInt32(Request.Form["Insurance"]), 5, 1, true));
                FixedItems.Add(new Item("MedicalAid", System.Convert.ToInt32(Request.Form["MedicalAid"]), 5, 1, true));

                budget = new Budget(FixedItems);
                budget.PrintBudget();
                return View();
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult GeneralBudget(string dummy) // dummy is necessary to prevent same params and return types on methods named the same
        {
            try
            {
                IList<Item> updatedBudget = budget.budget;
                updatedBudget.Add(new Item("Groceries", System.Convert.ToInt32(Request.Form["Groceries"]), 5, 1, false));
                updatedBudget.Add(new Item("Transport", System.Convert.ToInt32(Request.Form["Transport"]), 5, 1, false));
                updatedBudget.Add(new Item("Utilities", System.Convert.ToInt32(Request.Form["Utilities"]), 5, 1, true));
                updatedBudget.Add(new Item("Leisure", System.Convert.ToInt32(Request.Form["Leisure"]), 5, 1, true));
                updatedBudget.Add(new Item("Phone", System.Convert.ToInt32(Request.Form["Phone"]), 5, 1, true));
                updatedBudget.Add(new Item("Savings", System.Convert.ToInt32(Request.Form["Savings"]), 5, 1, true));
                budget.budget = updatedBudget;
                budget.PrintBudget();
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