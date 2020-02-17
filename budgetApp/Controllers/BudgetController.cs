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

        public IActionResult Budget() => View();
        
        [HttpGet]
        public IActionResult FixedBudget() => View();

        public IActionResult Item => View();

        [HttpPost]
        public ActionResult FixedBudget(string dummy)
        {
            try
            {
                Console.WriteLine(Request.Form["Salary"]);
                Console.WriteLine(Request.Form["Other"]);
                Console.WriteLine(Request.Form["Rent"]);
                Console.WriteLine(Request.Form["Insurance"]);
                Console.WriteLine(Request.Form["MedicalAid"]);
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