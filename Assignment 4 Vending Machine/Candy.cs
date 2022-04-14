using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;

namespace Assignment_4_Vending_Machine
{
    public class Candy : Product
    {
        public string Warnings { get; set; }
        public override string Examine()
        {
            string returnString;
            returnString = $"Price : {Price}\n";
            if(Warnings!=null)returnString+=($" Information : {Info}.\nWarning! {Warnings}");
            WriteLine(returnString);
            return returnString;

        }

        public Candy(string name, double price, int trayNumber)
        {
            Name = name;
            Price = price;
            TrayNumber = trayNumber;
        }
    }
}
