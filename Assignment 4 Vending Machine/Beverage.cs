using System;
using System.Collections.Generic;
using System.Text;


namespace Assignment_4_Vending_Machine
{
    public class Beverage : Product
    {
        public int Volume { get; set; }
        public string ContainerType { get; set; }

        public Beverage(string name,double price,int trayNumber,int volume,string containertype)
        {
            Name = name;
            Price = price;
            TrayNumber = trayNumber;
            Volume = volume;
            ContainerType = containertype;
        }

    }
}
