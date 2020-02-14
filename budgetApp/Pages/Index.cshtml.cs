using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace budgetApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public string Time { get; set; }
        public string Name { get; set; }
        public void OnGet()
        {
            Time = DateTime.Today.ToShortTimeString();
            Name = "Arata Yano";
        }
    }
}
