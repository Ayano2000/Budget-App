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
        Budget budget = new Budget(InOut.readBudget());
        private readonly ILogger<BudgetController> _logger;

        public TmpController(ILogger<BudgetController> logger)
        {
            _logger = logger;
        }
        public IActionResult Budget(string mode = "new")
        {
            if(mode.Equals("new"))
            {
                System.IO.File.WriteAllText(@"UserData/budget.txt",string.Empty);
                budget.budget = InOut.readBudget();
            }
            return View(new LoadModel {Mode = mode, Budget = this.budget.budget.ToList()});
        }

        public ActionResult NewItem()
        {
            return View();
        }

        public ActionResult EditItem(string Name, string Amount, string Priority, string Rise, string Type)
        {
            return View(new DataViewModel {Name = Name, Amount = Amount, Priority = Priority, Rise = Rise, Expense = Type});
        }

        public ActionResult DeleteItem(string Name, string Amount, string Priority, string Rise, string Type)
        {
            budget.DeleteItem(Name);
            InOut.saveBudget(budget.budget);
            return View("Budget", new LoadModel {Mode = "load", Budget = this.budget.budget.ToList()});
        }

        [HttpPost]
        public ActionResult AddItem(string Name, int Amount, int Priority, int Rise, string Type)
        {
            try
            {
                Item item = new Item(Name, Amount, Priority, Rise, Boolean.Parse(Type));
                budget.AddItem(item);
                InOut.saveBudget(budget.budget);
                return View("Budget", new LoadModel {Mode = "load", Budget = this.budget.budget.ToList()});
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
                return View("Budget", new LoadModel {Mode = "load", Budget = this.budget.budget.ToList()});
            }
        }

        [HttpPost]
        public ActionResult ChangeItem(string Name, int Amount, int Priority, int Rise, string Type)
        {
            try
            {
                budget.UpdateItemAmount(Name, Amount);
                budget.UpdateItemPriority(Name, Priority);
                budget.UpdateItemRise(Name, Rise);
                //budget.UpdateItemExpense(Name, Boolean.Parse(Type));
                InOut.saveBudget(budget.budget);
                return View("Budget", new LoadModel {Mode = "load", Budget = this.budget.budget.ToList()});
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
                return View("Budget", new LoadModel {Mode = "load", Budget = this.budget.budget.ToList()});
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}