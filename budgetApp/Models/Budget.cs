using System;
using System.Collections.Generic;

namespace budgetApp.Models
{
    public class Budget
    {
        //IList<Item> budget;

        public Budget(List<Item> budget_to_add)
        {
            this.budget = budget_to_add;
        }

        public List<Item> budget { get; set; }

        public void PrintBudget()
        {
            foreach (Item item in this.budget)
            {
                Console.WriteLine(item);
            }
        }

        // could be a boolean and return false if failure to update happens
        public void UpdateItemAmount(String name, int amount)
        {
            foreach (Item item in this.budget)
            {
                if (String.Equals(item.Name, name))
                {
                    item.Amount = amount;
                }
            }
        }

        public void UpdateItemPriority(String name, int priority)
        {
            foreach (Item item in this.budget)
            {
                if (String.Equals(item.Name, name))
                {
                    item.Priority = priority;
                }
            }
        }

        public void UpdateItemRise(String name, int rise)
        {
            foreach (Item item in this.budget)
            {
                if (String.Equals(item.Name, name))
                {
                    item.Rise = rise;
                }
            }
        }

        public void DeleteItem(String name)
        {
            foreach (Item item in this.budget)
            {
                if (String.Equals(item.Name, name))
                {
                    this.budget.Remove(item);
                }
            }
        }

        public void AddItem(Item item)
        {
            this.budget.Add(item);
        }
    }
}