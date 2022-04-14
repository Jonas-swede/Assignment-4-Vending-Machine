using System;
using Xunit;
using Assignment_4_Vending_Machine;

namespace VendingMachineTests
{
    
    public class ProductTest
    {
        [Fact]
        [Trait("Category","Products")]
        [Trait("Product", "Beverage")]
        public void BeverageConstructorTest()
        {
            //Arrange.
            string name = "BeverageConstructorTest";
            double price = 12.5;

            //Act.
            Beverage sut = new Beverage(name,price,1,10, "Bottle");
            //Assert.
            Assert.Equal(name,sut.Name);
            Assert.Equal(price, sut.Price);
            Assert.Equal(10, sut.Volume);
            Assert.Equal(1, sut.TrayNumber);
            Assert.Equal("Bottle", sut.ContainerType);
        }


        [Fact]
        [Trait("Category", "Products")]
        [Trait("Product", "Candy")]
        public void CandyConstructorTest()
        {
            //Arrange.
            string name = "CandyNameTest";
            double price = 12.5;
            //Act.
            Candy sut = new Candy(name, price, 2);
            //Assert.
            Assert.Equal(name, sut.Name);
            Assert.Equal(price, sut.Price);
            Assert.Equal(2, sut.TrayNumber);
        }

      

        [Fact]
        [Trait("Category", "Products")]
        [Trait("Product", "Candy")]
        public void CandyWarningTest()
        {
            //Arrange.
            string name = "CandyWarningTest";
            double value = 17.5;
            //Act.
            Candy sut = new Candy(name, value, 2);
            sut.Warnings = "WarningTest";
            //Assert.
            Assert.Equal("WarningTest", sut.Warnings);
        }

        [Fact]
        [Trait("Category", "Products")]
        [Trait("Product", "Candy")]
        public void CandyWarningNullTest()
        {
            //Arrange.
            string name = "CandyWarningNullTest";
            double price = 17.5;
            //Act.
            Candy sut = new Candy(name, price, 2);
            //Assert.
            Assert.Null(sut.Warnings);
        }

        [Fact]
        [Trait("Category", "Products")]
        [Trait("Product", "Candy")]
        public void CandyExamineTest()
        {
            //Arrange.
            string warning = "Warning, Testing";
            //Act.
            Candy sut = new Candy("Test", 10, 2);
            sut.Info = "TestInfo";
            sut.Warnings = warning;
            string expectetValue = "Price : 10\n Information : TestInfo.\nWarning! Warning, Testing";

            //Assert.
            Assert.Equal(expectetValue, sut.Examine());
        }


        [Fact]
        [Trait("Category", "Products")]
        [Trait("Product", "Toy")]
        public void ToyConstructorTest()
        {
            //Arrange.
            string name = "ToyNameTest";
            double price = 17.5;
            int trayNumber = 2;
            string ageGroup = "3-8";
            //Act.
            Toy sut = new Toy(name,price,trayNumber,ageGroup);
            //Assert.
            Assert.Equal(name, sut.Name);
            Assert.Equal(price, sut.Price);
            Assert.Equal(trayNumber, sut.TrayNumber);
            Assert.Equal(ageGroup, sut.AgeGroup);
        }

        [Fact]
        [Trait("Category", "Products")]
        [Trait("Product", "Toy")]
        public void ToyExamineTest()
        {
            //Arrange.
            string name = "ToyExamineTest";
            double price = 17.5;
            int trayNumber = 2;
            string ageGroup = "3-8";
            //Act.
            Toy sut = new Toy(name, price, trayNumber, ageGroup);
            sut.Info = "TestInfo";
            string expectetValue = "Price : 17,5\nInformation : TestInfo.\nSuitable for ages 3-8";
            //Assert.
            Assert.Equal(expectetValue, sut.Examine());

        }

        [Fact]
        [Trait("Category", "Products")]
        public void ProductConstructorTest()
        {
            //Arrange.
            string Name = "ProductConstructorTest";
            double Price = 20;
            string Info = "ProductConstructorTestInfo";
            string Instructions = "ProductConstructorTestInstr";
            string Brand = "ProductConstructorTestBrand";
            int TrayNumber = 2;
            int Amount = 10;
            //Act.
            Product sut = new Beverage(Name,Price,TrayNumber,0,"");
            sut.Info = Info;
            sut.Instructions = Instructions;
            sut.Brand = Brand;
            sut.Amount = Amount;
            //Assert.
            Assert.Equal(Name, sut.Name);
            Assert.Equal(Price, sut.Price);
            Assert.Equal(Info, sut.Info);
            Assert.Equal(Instructions, sut.Instructions);
            Assert.Equal(Brand, sut.Brand);
            Assert.Equal(Amount, sut.Amount);
        }

        [Fact]
        [Trait("Category", "Products")]
        public void ProductExamineTest()
        {
            //Arrange.
            string name = "BeverageConstructorTest";
            double price = 12.5;
            string info = "ProductExamineTestInfo";
            //Act.
            Beverage sut = new Beverage(name, price, 2, 33, "Can");
            sut.Info = info;
            string expectedString = "Price : 12,5\nInformation : ProductExamineTestInfo";
            //Assert.
            Assert.Equal(expectedString, sut.Examine());
        }

        [Fact]
        [Trait("Category", "Products")]
        public void ProductUseTest()
        {
            //Arrange.
            string name = "BeverageConstructorTest";
            double price = 12.5;
            string use = "ProductUseTestInfo";
            //Act.
            Beverage sut = new Beverage(name, price, 1, 10, "Bottle");
            sut.Instructions = use;
            string expectedString = use;
            //Assert.
            Assert.Equal(expectedString, (sut as Product).Use());
        }


    }
}
