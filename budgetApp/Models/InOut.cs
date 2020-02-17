using System.IO;
using System;
using System.Collections.Generic;

namespace budgetApp.Models
{
    public abstract class InOut
    {

        public static void saveBudget(List<Item> Budget){
            String filepath = "UserData/budget.txt";
            String line;
            try{
                StreamWriter sw = new StreamWriter(filepath, false);
                foreach (Item token in Budget){
                    line = token.Name + "," + Convert.ToString(token.Amount) + ",";
                    line += Convert.ToString(token.Priority) + "," + Convert.ToString(token.Rise) + "," + Convert.ToString(token.expense);
                    sw.WriteLine(line);
                }
                sw.Close();
            }catch(Exception e){
                Console.WriteLine(e.Message);
            }
        }
        
        public static List<Item> readBudget(){
            String filepath = "UserData/budget.txt";
            #nullable enable
            string? line;
            List<Item> Items = new List<Item>();
            int pos;
            try{
                StreamReader sr = new StreamReader(filepath);
                while ((line = sr.ReadLine()) != null){
                    Item input = new Item();
                    pos = line.IndexOf(',');
                    input.Name = line.Substring(0,pos);
                    line = line.Substring(pos + 1);
                    pos = line.IndexOf(',');
                    input.Amount = int.Parse(line.Substring(0,pos));
                    line = line.Substring(pos + 1);
                    pos = line.IndexOf(',');
                    input.Priority= int.Parse(line.Substring(0,pos));
                    line = line.Substring(pos + 1);
                    pos = line.IndexOf(',');
                    input.Rise= int.Parse(line.Substring(0,pos));
                    line = line.Substring(pos + 1);
                    input.expense = Boolean.Parse(line);
                    Items.Add(input);
                }
                sr.Close();
            } catch(Exception e){
                Console.WriteLine("budget.txt not found");
                Console.WriteLine(e.Message);
            }
            return Items;
        }
    }
}