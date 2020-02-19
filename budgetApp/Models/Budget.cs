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

        public IList<Item> budget { get; set; }

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

        public void UpdateItemType(String name, bool type)
        {
            foreach (Item item in this.budget)
            {
                if (String.Equals(item.Name, name))
                {
                    item.expense = type;
                }
            }
        }

        public Boolean ItemExists(String name){
        foreach (Item item in this.budget)
            {
                if (String.Equals(item.Name, name))
                {
                    return true;
                }
            }
            return false;
        }

        public int NetTotal()
        {
            int total = 0;
                foreach(Item item in this.budget)
                {
                    if(item.Expense)
                    {
                        total -= item.Amount;
                    }
                    else
                    {
                        total +=item.Amount;
                    }
                }
            return total;
        }
        
        public int NetIncome()
        {
            int total = 0;
            foreach(Item item in this.budget)
            {
                if(!item.Expense){
                    total += item.Amount;
                }
            }
            return total;
        }

        public int NetExpenses()
        {
            int total = 0;
            foreach(Item item in this.budget)
            {
                if(item.Expense){
                    total += item.Amount;
                }
            }
            return total;
        }

        public void DeleteItem(String name)
        {
            foreach (Item item in this.budget)
            {
                if (String.Equals(item.Name, name))
                {
                    this.budget.Remove(item);
                    break ;
                }
            }
        }

        public void AddItem(Item item)
        {
            if(ItemExists(item.Name)){
                foreach(Item oldItem in this.budget)
                {
                    if(oldItem.Name == item.Name){
                        oldItem.Amount=item.Amount;
                        oldItem.expense = item.expense;
                        oldItem.Priority = item.Priority;
                        oldItem.Rise = item.Rise;
                    }
                }
            }
            else
            {
                this.budget.Add(item);
            }
        }
    }
}