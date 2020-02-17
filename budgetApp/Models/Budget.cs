using System;
using System.Collections.Generic;

namespace budgetApp.Models
{
    public class Budget
    {
       //  IList<Item> budget;

        public Budget(IList<Item> FixedBudget)
        {
            this.budget = FixedBudget;
        }

        public IList<Item> budget { get; set; }

        public void PrintBudget()
        {
            foreach (Item item in this.budget)
            {
                Console.WriteLine(item);
            }
        }

        public void AddItem(Item to_add)
        {
            this.budget.Add(to_add);
        }
    }
}