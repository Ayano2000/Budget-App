using System;
using System.Collections.Generic;

namespace budgetApp.Models
{
    public class Budget
    {
        IList<Item> budget = new List<Item>();

        public Budget(IList<Item> FixedBudget)
        {
            this.budget = FixedBudget;
        }

        public void PrintBudget()
        {
            foreach (Item item in this.budget)
            {
                Console.WriteLine(item);
            }
        }
    }
}