using System;

namespace budgetApp.Models {
    public class Item
    {
        public Item(string name, int amount, int priority, int rise)
        {
            this.Name = name;
            this.Amount = amount;
            this.Priority = priority;
            this.Rise = rise;
        }
        public Item(){}

        public override string ToString()
        {
            return("Item: " + this.Name + " amount: " + this.Amount
                                + " priority: " + this.Priority
                                + " likelyhood to rise " + this.Rise);
        }

        public string Name { get; set; }
        public int Amount { get; set; }
        public int Priority { get; set; }
        public int Rise { get; set; } // likelyhood to rise.
    }
}