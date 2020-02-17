using System.Collections.Generic;
using budgetApp.Models;
using System;

namespace budgetApp.Models {
    public class FixedBudget
    {
        /*public FixedBudget(int salary, int rent, int insuarnce, int medicalaid)
        {
            this.Salary = salary;
            this.Rent = rent;
            this.Insurance = insuarnce;
            this.MedicalAid = medicalaid;
        }*/


        public int Salary { get; set; }
        public int Rent { get; set; }
        public int Insurance { get; set; }
        public int MedicalAid { get; set; } // likelyhood to rise.


     List<FixedBudget> fixedbudget = new List<FixedBudget>
     {
         new FixedBudget { Salary = 0, Rent = 0, Insurance= 0, MedicalAid=0}
     };

    }

}