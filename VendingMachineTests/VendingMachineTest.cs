using System;
using Xunit;
using Assignment_4_Vending_Machine;
using System.Collections.Generic;

namespace VendingMachineTests
{
    public class VendingMachineTest
    {
        [Fact]
        [Trait("VendingMachine","Constructor")]
        public void ConstructorTest()
        {
            //Arrange.
            VendingMachine sut = new VendingMachine(30);
            //Act.

            //Assert.
            Assert.Equal(0, sut.Balance);
            Assert.Empty(sut.Stock);
            Assert.Equal(30, sut.NumberOfTrays);
            Assert.Equal(new int[] { 1, 5, 10, 20, 50, 100, 500, 1000 },sut.Denomination);

        }

        [Fact]
        [Trait("VendingMachine", "Methods")]
        public void AddStockTest()
        {
            //Arrange.
            VendingMachine sut = new VendingMachine(30);
            Candy product = new Candy("Test", 10, 2);
            //Act.
            sut.AddStock(product);
            //Assert.
            Assert.Same(product, sut.Stock[2]);
        }

        [Fact]
        [Trait("VendingMachine", "Methods")]
        public void AddStockExistingTray()
        {
            //Arrange.
            VendingMachine sut = new VendingMachine(30);
            Candy product = new Candy("Test", 10, 2);
            product.Amount = 10;
            sut.Stock.Add(2,new Candy("Testing", 12, 2));
            //Act.
            int before = sut.Stock[2].Amount;
            sut.AddStock(product);
            int after = sut.Stock[2].Amount;
            //Assert.
            Assert.NotSame(product, sut.Stock[2]);
            Assert.Equal(before + 10, after);
        }

        [Fact]
        [Trait("VendingMachine", "Methods")]
        public void ClearStockTest()
        {
            //Arrange.
            VendingMachine sut = new VendingMachine(30); 
            sut.Stock.Add(2, new Candy("Testing", 12, 2));
            //Act.
            sut.ClearStock();
            //Assert.
            Assert.Empty(sut.Stock);
        }

        [Fact]
        [Trait("VendingMachine", "Methods")]
        public void PurchaseTest()
        {
            //Arrange.
            VendingMachine sut = new VendingMachine(30);
            Candy product = new Candy("Testing", 10, 2);
            sut.Stock.Add(2,product);
            sut.Stock[2].Amount = 10;
            sut.InsertMoney(100);
            //Act.
            sut.Purchase(2);
            //Assert.
            Assert.Equal(90, sut.Balance);
            Assert.Equal(9, sut.Stock[2].Amount);
        }

        [Fact]
        [Trait("VendingMachine", "Methods")]
        public void ShowAllTest()
        {
            //Arrange.
            VendingMachine sut = new VendingMachine(30);
            Candy product1 = new Candy("Testing", 10, 1);
            Candy product3 = new Candy("Testing", 10, 3);
            sut.AddStock(product1);
            sut.AddStock(product3);
            
            //Act.
            List<Product> productList = sut.ShowAll();
            //Assert.
            Assert.Contains(product1, productList);
            Assert.Contains(product3, productList);
            Assert.Equal(2, productList.Count);

        }

        [Fact]
        [Trait("VendingMachine", "Methods")]
        public void InsertValidMoneyTest()
        {
            //Arrange.
            VendingMachine sut = new VendingMachine(30);
            decimal before=0, after;
            //Act.
            sut.InsertMoney(100);
            after = sut.Balance;
            //Assert.
            Assert.Equal(before + 100, after);
        }
        
        [Fact]
        [Trait("VendingMachine", "Methods")]
        public void InsertInvalidMoneyTest()
        {
            //Arrange.
            VendingMachine sut = new VendingMachine(30);
            decimal before = 0, after;
            //Act.
            sut.InsertMoney(110);
            after = sut.Balance;
            //Assert.
            Assert.Equal(before, after);
        }

        [Fact]
        [Trait("VendingMachine", "Methods")]
        public void EndTransactionTest()
        {
            //Arrange.
            VendingMachine sut = new VendingMachine(30);
            sut.InsertMoney(1000);
            sut.InsertMoney(100);
            sut.InsertMoney(20);
            sut.InsertMoney(1);
            sut.InsertMoney(1);
            int[] expected = new int[] { 2, 0, 0, 1, 0, 1, 0, 1};
            //Act.
            int[] actual = sut.EndTransaction();
            //Assert.
            Assert.Equal(expected, actual);
        }




    }
}
