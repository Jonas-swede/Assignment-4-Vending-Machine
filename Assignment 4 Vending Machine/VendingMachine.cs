using System;
using System.Collections.Generic;
using static System.Console;

namespace Assignment_4_Vending_Machine
{
    
    public class VendingMachine : IVending
    {
       
        
        public decimal Balance { get; private set; }
        public Dictionary<int,Product> Stock { get; private set; }
        public int NumberOfTrays { get; set; }
        public readonly int[] Denomination;
        /// <summary>
        /// Create a new VendingMachine with default denominations tabel
        /// </summary>
        public VendingMachine(int numberOfTrays)
        {
            NumberOfTrays = numberOfTrays;
            Stock = new Dictionary<int, Product>();
            Balance = 0;
            Denomination = new int[] { 1, 5, 10, 20, 50, 100, 500, 1000 };
        }
        /// <summary>
        /// Create a new VendingMachine with a provided denominations tabel
        /// </summary>
        /// <param name="denominations"></param>
        public VendingMachine(int[] denominations)
        {
            Balance = 0;
            Denomination = denominations;
        }

       

        public void AddStock(Product product)
        {
            if (!Stock.ContainsKey(product.TrayNumber))
            {
                Stock.Add(product.TrayNumber, product);
            }
            else
            {
                Stock[product.TrayNumber].Amount += product.Amount;
            }
            
        }

        public void ClearStock()
        {
            Stock.Clear();
        }

        public bool Purchase(int trayNumber)
        {
            if (!Stock.ContainsKey(trayNumber)) return false;
            if (Balance >= (decimal)Stock[trayNumber].Price)
            {
                Console.WriteLine($"Ejecting from tray #{Stock[trayNumber].TrayNumber}");
                Stock[trayNumber].Amount -= 1;
                Balance -= (decimal)Stock[trayNumber].Price;
            }
            return true;
        }

        public List<Product> ShowAll()
        {
            List<Product> returnList = new List<Product>();
            for(int i=0;i<NumberOfTrays;i++)
            {
                if (Stock.ContainsKey(i)) 
                {
                    returnList.Add(Stock[i]);WriteLine($"{Stock[i].Name} , Tray: {Stock[i].TrayNumber} , Price:{Stock[i].Price} , Stock: {Stock[i].Amount}"); 
                }
            }
            return returnList;
        }

        public bool InsertMoney(int Amount)
        {
            if (Array.Exists<int>(Denomination, element => element == Amount))
            {
                Balance += Amount;
                return true;
            }
            else return false;

        }

        public int[] EndTransaction()
        {
            int[] returnArray = new int[Denomination.Length];
            int change = Convert.ToInt32(this.Balance);
            while (change > 0)
            {
                for (int i = Denomination.Length-1; i >= 0; i--)
                {
                    while (change >= Denomination[i])
                    {
                        returnArray[i]++;
                        change -= Denomination[i];
                    }
                }
            }
            Balance = 0;
            return returnArray;
        }
    }

}
