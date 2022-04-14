using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;

namespace Assignment_4_Vending_Machine
{
    public abstract class Product
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public string Info { get; set; }
        public string Instructions { get; set; }
        public string Brand { get; set; }
        public int TrayNumber { get; set; }
        public int Amount { get; set; }

        public virtual string Examine()
        {
            return $"Price : {Price}\nInformation : {Info}";
        }

        public string Use()
        {
            return Instructions;
        }

    }
}
