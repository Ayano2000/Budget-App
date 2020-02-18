using System;

namespace budgetApp.Models {
    public class DataViewModel
    {
        public string Name { get; set; }
        public string Amount { get; set; }
        public string Priority { get; set; }
        public string Rise { get; set; } // likelyhood to rise.
        public string Expense{ get; set; }
    }
}