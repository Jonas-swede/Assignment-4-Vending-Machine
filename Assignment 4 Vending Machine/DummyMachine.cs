using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;

namespace Assignment_4_Vending_Machine
{
    public static class DummyMachine
    {
        static void Main(string[] args)
        {
            Write("TEst");
            VendingMachine TestMachine = new VendingMachine(20);
            Product testProduct = new Beverage("Beer", 10, 1,33,"Can");
            TestMachine.AddStock(testProduct);
            int menuChoice = -1;
            do
            {
                WriteLine("Test Machine 1.0");
                WriteLine($"Current money : {TestMachine.Balance}");
                WriteLine("0:Quit\n1.Show all products\n2.Clear all stock\n3.Add Product\n4.Insert money\n5.Make purchase\n6.End transaction");
                while (!int.TryParse(ReadLine(), out menuChoice));
                switch (menuChoice)
                {
                    case 1:
                        TestMachine.ShowAll();
                        break;

                    case 2:
                        TestMachine.ClearStock();
                        break;

                    case 3:
                        WriteLine("Enter tray #");
                        int traynr;
                        while (!int.TryParse(ReadLine(), out traynr));
                        Product product = new Candy("",0,0);
                        if (!TestMachine.Stock.ContainsKey(traynr))
                        {
                            NewProduct(traynr,TestMachine);
                            
                        }
                        else
                        {
                            ExistingProduct(traynr, TestMachine);
                        }
                        break;

                    case 4:

                        WriteLine("Enter a amount of valid denomination :");
                        int money;
                        while (!int.TryParse(ReadLine(), out money)) ;
                        if (!TestMachine.InsertMoney(money)) goto case 4;
                        break;

                    case 5:
                        WriteLine("Enter tray number :");
                        int trayNumber;
                        while (!int.TryParse(ReadLine(), out trayNumber)) ;
                        WriteLine(TestMachine.Stock[trayNumber].Name);
                        WriteLine(TestMachine.Stock[trayNumber].Examine());
                        WriteLine(TestMachine.Stock[trayNumber].Use());
                        if (!TestMachine.Purchase(trayNumber))
                        {
                            WriteLine("\nPurchase failed");
                        }
                        break;

                    case 6:
                        int[] change = TestMachine.EndTransaction();
                        WriteLine("You got the following change:");
                        for(int i=0;i<TestMachine.Denomination.Length;i++)
                        {
                            if(change[i]!=0)WriteLine($"{change[i]} pcs of {TestMachine.Denomination[i]}");
                        }
                        WriteLine("");
                        break;

                }
            } while (menuChoice != 0);
        }

        static void NewProduct(int trayNr,VendingMachine vendingMachine)
        {
            string name, containerType, ageGroup;
            double price;
            int volume;
            Product product;
        choice:
            WriteLine("Choose product type\n1. Beverage\n2. Candy\n3. Toy\n");
            int choice;
            while (!int.TryParse(ReadLine(), out choice)) ;
            WriteLine("Enter name :");
            name = ReadLine();
            WriteLine("Enter price :");
            while (!double.TryParse(ReadLine(), out price)) ;
            WriteLine("Enter general information:");
            string info = ReadLine();
            switch (choice)
            {
                case 1:

                    WriteLine("Enter volume :");
                    while (!int.TryParse(ReadLine(), out volume)) ;
                    WriteLine("Enter container type :");
                    containerType = ReadLine();
                    product = new Beverage(name, price, trayNr, volume, containerType);
                    product.Info = info;
                    break;

                case 2:
                    product = new Candy(name, price, trayNr);
                    product.Info = info;
                    WriteLine("Enter warnings if applicable otherwise leave empty:");
                    string warnings = ReadLine();
                    if (warnings.Length != 0) (product as Candy).Warnings = warnings;
                    break;

                case 3:
                    WriteLine("Enter agegroup :");
                    ageGroup = ReadLine();
                    product = new Toy(name, price, trayNr, ageGroup);
                    product.Info = info;
                    break;

                default:
                    goto choice;
                    
            }
            WriteLine("Enter amount");
            int amount;
            while (!int.TryParse(ReadLine(), out amount)) ;
            product.Amount = amount;
            vendingMachine.AddStock(product);
        }

        static void ExistingProduct(int trayNr, VendingMachine vendingMachine)
        {
            Product product=new Candy("",0,trayNr);
            WriteLine("Enter amount to add :");
            int amount;
            while (!int.TryParse(ReadLine(), out amount)) ;
            product.Amount = amount;  
        }

    }
}
