using System;

 

namespace SimpleCalc

{

    public class BudgetClass

    {

        private int budget;

        private int spent;

        private int result;

 

        public void Budget()

        {

            Console.WriteLine("What is your budget?");

            int newBudget = int.Parse(Console.ReadLine());

            budget = newBudget;

 

            Console.WriteLine("How much did you spend on groceries?");

            Prompt();

 

            Console.WriteLine("How much did you spend eating out?");

            Prompt();

 

            Console.WriteLine("How much did you spend on fuel?");

            Prompt();

 

            Console.WriteLine("How much did you spend on entertainment?");

            Prompt();

 

            string overOrUnder = OverOrUnder(result);

            Console.WriteLine("You spent $" + result + " " + overOrUnder + " your budget.");

            Console.ReadLine();

        }

 

        public void Prompt()

        {

            spent = int.Parse(Console.ReadLine());

            result = Calculate(spent);

        }

 
        public int Calculate(int spent)

        {

            budget = budget - spent;

            return budget;

        }

 

        public string OverOrUnder(int result)

        {

            if (result >= 0) return "under";

 

            return "over";

        }

    }

}