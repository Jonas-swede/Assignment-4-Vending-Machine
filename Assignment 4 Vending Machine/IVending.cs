using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment_4_Vending_Machine
{
    interface IVending
    {
        /// <summary>
        /// Make a purchase
        /// </summary>
        /// <param name="trayNumber"></param>
        /// <returns>true if transaction succeeded</returns>
        public bool Purchase(int trayNumber);
        /// <summary>
        /// Show all products currently in the machine
        /// </summary>
        /// <returns>a List of all products</returns>
        public List<Product> ShowAll();
        /// <summary>
        /// Add money to the current money pool.
        /// The amount must be of a correct denomenation 
        /// </summary>
        /// <param name="Amount"></param>
        /// <returns>true if the amount was added to the current pool</returns>
        public bool InsertMoney(int Amount);
        /// <summary>
        /// Ends the current transaction
        /// </summary>
        /// <returns>An array of change to be returned. The array contains how much of each denomenation shall be returned.</returns>
        public int[] EndTransaction();
    }
}
