using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;

namespace Assignment_4_Vending_Machine
{
    public class Toy : Product
    {
        public string AgeGroup { get; set; }
        public Toy(string name,double price,int trayNumber,string ageGroup)
        {
            Name = name;
            Price = price;
            TrayNumber = trayNumber;
            AgeGroup = ageGroup;
        }
        public override string Examine()
        {
            string returnString;
            returnString = base.Examine();
            returnString +=$".\nSuitable for ages {AgeGroup}";
            WriteLine(returnString);
            return returnString;
        }
    }
}
