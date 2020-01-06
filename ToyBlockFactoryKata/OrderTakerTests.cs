using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Xunit;

namespace ToyBlockFactoryKata
{
    public class InvoiceReportGeneratorTests
    {
        [Theory]
        [InlineData(1,1,1)]
        [InlineData(2,2,2)]
        public void GenerateSimpleInvoiceCostingForBlueSquares(int numberOfBlueSquares, int expectedTotalSquares, int expectedCost)
        {
            var reportGenerator = new InvoiceReportDataGenerator();
            var order = new Order("", "", "", "", 0, numberOfBlueSquares, 0, 0, 0, 0, 0);
            var reportData = reportGenerator.Generate(order);
            Assert.Equal(numberOfBlueSquares, reportData.NumberOfBlueSquares);
            Assert.Equal(expectedTotalSquares, reportData.TotalSquares);
            Assert.Equal(0, reportData.TotalCircles);
            Assert.Equal(0, reportData.TotalTriangles);
            Assert.Equal(expectedCost, reportData.TotalCostForSquares);
            Assert.Equal(expectedCost, reportData.GrandTotal);
        }
        
        [Theory]
        [InlineData(1,1, 1, 2, 3)]
        [InlineData(2,2, 2, 4, 6)]
        public void GenerateSimpleInvoiceCostingForRedTriangles(int numberOfRedTriangles, int expectedRedColorSurcharge,
            int expectedTotalTriangles, int expectedTotalCostForTriangles, int expectedGrandTotal)
        {
            var reportGenerator = new InvoiceReportDataGenerator();
            var order = new Order("", "", "", "",
                0, 0, 0, 0, 0, 0, numberOfRedTriangles);
            var reportData = reportGenerator.Generate(order);
            Assert.Equal(numberOfRedTriangles, reportData.NumberOfRedTriangles);
            Assert.Equal(0, reportData.TotalSquares);
            Assert.Equal(0, reportData.TotalCircles);
            Assert.Equal(expectedTotalTriangles, reportData.TotalTriangles);
            Assert.Equal(expectedTotalCostForTriangles, reportData.TotalCostForTriangles);
            Assert.Equal(expectedRedColorSurcharge, reportData.RedColorSurcharge);
            Assert.Equal(expectedGrandTotal, reportData.GrandTotal);
        }
        
        [Theory]
        [InlineData(1,1, 1, 3, 4)]
        [InlineData(2,2, 2, 6, 8)]
        public void GenerateSimpleInvoiceCostingForRedCircles(int numberOfRedCircles, int expectedRedColorSurcharge,
            int expectedTotalCircles, int expectedTotalCostForCircles, int expectedGrandTotal)
        {
            var reportGenerator = new InvoiceReportDataGenerator();
            var order = new Order("", "", "", "",
                0, 0, 0, 0, 0, numberOfRedCircles, 0);
            var reportData = reportGenerator.Generate(order);
            Assert.Equal(numberOfRedCircles, reportData.NumberOfRedCircles);
            Assert.Equal(0, reportData.TotalSquares);
            Assert.Equal(expectedTotalCircles, reportData.TotalCircles);
            Assert.Equal(0, reportData.TotalTriangles);
            Assert.Equal(expectedTotalCostForCircles, reportData.TotalCostForCircles);
            Assert.Equal(expectedRedColorSurcharge, reportData.RedColorSurcharge);
            Assert.Equal(expectedGrandTotal, reportData.GrandTotal);
        }
        [Theory]
        [InlineData(1,1,3)]
        [InlineData(2,2,6)]
        public void GenerateSimpleInvoiceCostingForBlueCircles(int numberOfBlueCircles, int expectedTotalCircles, int expectedCost)
        {
            var reportGenerator = new InvoiceReportDataGenerator();
            var order = new Order("", "", "", "", 0, 0, 0, 0, numberOfBlueCircles, 0,0);
            var reportData = reportGenerator.Generate(order);
            Assert.Equal(numberOfBlueCircles, reportData.NumberOfBlueCircles);
            Assert.Equal(0, reportData.TotalSquares);
            Assert.Equal(expectedTotalCircles, reportData.TotalCircles);
            Assert.Equal(0, reportData.TotalTriangles);
            Assert.Equal(expectedCost, reportData.TotalCostForCircles);
            Assert.Equal(expectedCost, reportData.GrandTotal);
        }
        
        [Theory]
        [InlineData(1,1,3)]
        [InlineData(2,2,6)]
        public void GenerateSimpleInvoiceCostingForYellowCircles(int numberOfYellowCircles, int expectedTotalCircles, int expectedCost)
        {
            var reportGenerator = new InvoiceReportDataGenerator();
            var order = new Order("", "", "", "", 0, 0, 0, numberOfYellowCircles, 0, 0 ,0);
            var reportData = reportGenerator.Generate(order);
            Assert.Equal(numberOfYellowCircles, reportData.NumberOfYellowCircles);
            Assert.Equal(0, reportData.TotalSquares);
            Assert.Equal(expectedTotalCircles, reportData.TotalCircles);
            Assert.Equal(0, reportData.TotalTriangles);
            Assert.Equal(expectedCost, reportData.TotalCostForCircles);
            Assert.Equal(expectedCost, reportData.GrandTotal);
        }
        
        [Theory]
        [InlineData(1,1,1)]
        [InlineData(2,2,2)]
        public void GenerateSimpleInvoiceCostingForYellowSquares(int numberOfYellowSquares, int expectedTotalSquares, int expectedCost)
        {
            var reportGenerator = new InvoiceReportDataGenerator();
            var order = new Order("", "", "", "", 0, 0, numberOfYellowSquares, 0, 0, 0,0);
            var reportData = reportGenerator.Generate(order);
            Assert.Equal(numberOfYellowSquares, reportData.NumberOfYellowSquares);
            Assert.Equal(expectedTotalSquares, reportData.TotalSquares);
            Assert.Equal(0, reportData.TotalCircles);
            Assert.Equal(0, reportData.TotalTriangles);
            Assert.Equal(expectedCost, reportData.TotalCostForSquares);
            Assert.Equal(expectedCost, reportData.GrandTotal);
        }
        
        [Theory]
        [InlineData(1,1,2,1,1)]
        [InlineData(2,2,4,2,2)]
        public void GenerateSimpleInvoiceCostingForRedSquares(int numberOfRedSquares, int expectedTotalSquares, int expectedGrandTotal, int expectedRedColorSurcharge, int expectedTotalCostForSquares)
        {
            var reportGenerator = new InvoiceReportDataGenerator();
            var order = new Order("", "", "", "", numberOfRedSquares, 0, 0, 0, 0, 0, 0);
            var reportData = reportGenerator.Generate(order);
            Assert.Equal(numberOfRedSquares, reportData.NumberOfRedSquares);
            Assert.Equal(expectedTotalSquares, reportData.TotalSquares);
            Assert.Equal(0, reportData.TotalCircles);
            Assert.Equal(0, reportData.TotalTriangles);
            Assert.Equal(expectedRedColorSurcharge, reportData.RedColorSurcharge);
            Assert.Equal(expectedGrandTotal, reportData.GrandTotal);
        }

        [Fact]
        
        public void GenerateEmptyInvoiceWithJobDetails()
        {
            var reportGenerator = new InvoiceReportDataGenerator();
            var order = new Order("Mark Pearl", "3 Vinewood Dr", "19 Jan 1980", "123", 0, 0, 0, 0, 0, 0, 0);
            var reportData = reportGenerator.Generate(order);
            Assert.Equal("Mark Pearl", reportData.Name);
            Assert.Equal("3 Vinewood Dr", reportData.Address);
            Assert.Equal("19 Jan 1980", reportData.DueDate);
            Assert.Equal("123", reportData.OrderNumber);
            Assert.Equal(0, reportData.NumberOfRedSquares);
            Assert.Equal(0, reportData.NumberOfYellowSquares);
            Assert.Equal(0, reportData.NumberOfBlueSquares);
            Assert.Equal(0, reportData.NumberOfRedCircles);
            Assert.Equal(0, reportData.NumberOfYellowCircles);
            Assert.Equal(0, reportData.NumberOfBlueCircles);
            Assert.Equal(0, reportData.NumberOfRedTriangles);
            Assert.Equal(0, reportData.NumberOfYellowTriangles);
            Assert.Equal(0, reportData.NumberOfBlueTriangles);
            Assert.Equal(0, reportData.TotalSquares);
            Assert.Equal(0, reportData.TotalCircles);
            Assert.Equal(0, reportData.TotalTriangles);
            Assert.Equal(0, reportData.RedColorSurcharge);
            Assert.Equal(0, reportData.GrandTotal);
        }

        [Fact]
        public void GenerateEmptyInvoiceWithNoDetails()
        {
            var reportGenerator = new InvoiceReportDataGenerator();
            var order = new Order("", "", "", "", 0, 0, 0, 0, 0, 0, 0);
            var reportData = reportGenerator.Generate(order);
            Assert.Equal("", reportData.Name);
            Assert.Equal("", reportData.Address);
            Assert.Equal("", reportData.DueDate);
            Assert.Equal("", reportData.OrderNumber);
            Assert.Equal(0, reportData.NumberOfRedSquares);
            Assert.Equal(0, reportData.NumberOfYellowSquares);
            Assert.Equal(0, reportData.NumberOfBlueSquares);
            Assert.Equal(0, reportData.NumberOfRedCircles);
            Assert.Equal(0, reportData.NumberOfYellowCircles);
            Assert.Equal(0, reportData.NumberOfBlueCircles);
            Assert.Equal(0, reportData.NumberOfRedTriangles);
            Assert.Equal(0, reportData.NumberOfYellowTriangles);
            Assert.Equal(0, reportData.NumberOfBlueTriangles);
            Assert.Equal(0, reportData.TotalSquares);
            Assert.Equal(0, reportData.TotalCircles);
            Assert.Equal(0, reportData.TotalTriangles);
            Assert.Equal(0, reportData.RedColorSurcharge);
            Assert.Equal(0, reportData.GrandTotal);
        }
    }

    public class InvoiceReportData
    {
        public string Name { get; set; }
        public string Address{ get; set; }
        public string DueDate{ get; set; }
        public string OrderNumber{ get; set; }
        public int NumberOfRedSquares { get; set; }
        public int NumberOfBlueSquares { get; set; }
        public int NumberOfYellowSquares { get; set; }
        public int NumberOfRedCircles { get; set; }
        public int NumberOfYellowCircles { get; set; }
        public int NumberOfBlueCircles { get; set; }
        public int NumberOfRedTriangles { get; set; }
        public int NumberOfYellowTriangles { get; set; }
        public int NumberOfBlueTriangles { get; set; }

        public int TotalSquares => NumberOfBlueSquares + NumberOfYellowSquares + NumberOfRedSquares;

        public int TotalCircles
        {
            get { return NumberOfYellowCircles + NumberOfBlueCircles + NumberOfRedCircles; }
        }

        public int TotalTriangles => NumberOfRedTriangles;

        public int RedColorSurcharge
        {
            get
            {
                const int redSurchargeAmountPerItem = 1;
                return (NumberOfRedCircles + NumberOfRedSquares + NumberOfRedTriangles) * redSurchargeAmountPerItem;
            }
        }

        public int TotalCostForSquares => 1 * TotalSquares;

        public int GrandTotal => TotalCostForSquares + RedColorSurcharge + TotalCostForCircles + TotalCostForTriangles;
        public int TotalCostForCircles => 3 * TotalCircles;

        public int TotalCostForTriangles
        {
            get { return 2 * TotalTriangles; }
            
        }
    }

    public class InvoiceReportDataGenerator
    {
        public InvoiceReportData Generate(Order order)
        {
            var result = new InvoiceReportData();
            result.Name = order.Name;
            result.Address= order.Address;
            result.DueDate = order.DueDate;
            result.OrderNumber = order.OrderNumber;
            result.NumberOfBlueSquares = order.NumberBlueSquares;
            result.NumberOfYellowSquares = order.NumberYellowSquares;
            result.NumberOfRedSquares = order.NumberRedSquares;
            result.NumberOfYellowCircles = order.NumberYellowCircles;
            result.NumberOfBlueCircles = order.NumberBlueCircles;
            result.NumberOfRedCircles = order.NumberRedCircles;
            result.NumberOfRedTriangles = order.NumberRedTriangles;
            return result;
        }
    }

    public class OrderTakerTests
    {
        [Fact]
        public  void PromptOrderDetails()
        {
            var sut = new OrderTaker();
            using (StringWriter sw = new StringWriter())
            {
                var consoleInput = new List<string>();
                consoleInput.Add("Mark Pearl");
                consoleInput.Add("1 Bob Avenue, Auckland");
                consoleInput.Add("19 Jan 2019");
                consoleInput.Add("123");
                consoleInput.Add("1");
                consoleInput.Add("1");
                consoleInput.Add("1");
                
                using StringReader sr = new StringReader(String.Join(Environment.NewLine,consoleInput));
                Console.SetOut(sw);
                Console.SetIn(sr);
                var result = sut.GetOrder();
                var consoleOutput = sw.ToString().Split(Environment.NewLine).ToList();
                
                Assert.Equal("Please input your Name: ", consoleOutput[0]);
                Assert.Equal("Please input your Address: ", consoleOutput[1]);
                Assert.Equal("Please input your Due Date: ", consoleOutput[2]);
                Assert.Equal("Please input the Order Number: ", consoleOutput[3]);
                Assert.Equal("", consoleOutput[4]);
                Assert.Equal("Please input the number of Red Squares: ", consoleOutput[5]);
                Assert.Equal("Please input the number of Blue Squares: ", consoleOutput[6]);
                Assert.Equal("Please input the number of Yellow Squares: ", consoleOutput[7]);
                Assert.Equal("", consoleOutput[8]);
                Assert.Equal("Please input the number of Red Triangle: ", consoleOutput[9]);
                Assert.Equal("Please input the number of Blue Triangle: ", consoleOutput[10]);
                Assert.Equal("Please input the number of Yellow Triangle: ", consoleOutput[11]);
                
                Assert.Equal("Mark Pearl", result.Name);
                Assert.Equal("1 Bob Avenue, Auckland", result.Address);
                Assert.Equal("19 Jan 2019", result.DueDate);
                
                Assert.Equal(1, result.NumberRedSquares);
                Assert.Equal(1, result.NumberBlueSquares);
                Assert.Equal(1, result.NumberYellowSquares);
            }
        }
    }

    public class OrderTaker
    {
        public Order GetOrder()
        {
            Console.WriteLine("Please input your Name: ");
            var name = Console.ReadLine();
            
            Console.WriteLine("Please input your Address: ");
            var address = Console.ReadLine();
            
            Console.WriteLine("Please input your Due Date: ");
            var dueDate = Console.ReadLine();
            
            Console.WriteLine("Please input the Order Number: ");
            var orderNumber = Console.ReadLine();
            
            Console.WriteLine("");
            Console.WriteLine("Please input the number of Red Squares: ");
            var numberRedSquares = Convert.ToInt32(Console.ReadLine());
            
            Console.WriteLine("Please input the number of Blue Squares: ");
            var numberBlueSquares = Convert.ToInt32(Console.ReadLine());
            
            Console.WriteLine("Please input the number of Yellow Squares: ");
            var numberYellowSquares = Convert.ToInt32(Console.ReadLine());
            
            Console.WriteLine("");
            Console.WriteLine("Please input the number of Red Triangle: ");
            var numberRedTriangle = Convert.ToInt32(Console.ReadLine());
            
            Console.WriteLine("Please input the number of Blue Triangle: ");
            var numberBlueTriangle = Convert.ToInt32(Console.ReadLine());
            
            Console.WriteLine("Please input the number of Yellow Triangle: ");
            var numberYellowTriangle = Convert.ToInt32(Console.ReadLine());
            
            return new Order(name, address, dueDate,orderNumber, numberRedSquares, numberBlueSquares, numberYellowSquares, 0, 0, 0, 0);
        }
    }

    public class Order
    {
        public Order(string name, string address, string dueDate, string orderNumber, int numberRedSquares,
            int numberBlueSquares,
            int numberYellowSquares, int numberYellowCircles, int numberBlueCircles, int numberRedCircles,
            int numberRedTriangles)
        {
            Name = name;
            Address = address;
            DueDate = dueDate;
            OrderNumber = orderNumber;
            NumberRedSquares = numberRedSquares;
            NumberBlueSquares = numberBlueSquares;
            NumberYellowSquares = numberYellowSquares;
            NumberYellowCircles = numberYellowCircles;
            NumberBlueCircles = numberBlueCircles;
            NumberRedCircles = numberRedCircles;
            NumberRedTriangles = numberRedTriangles;
        }

        public int NumberBlueCircles { get; set; }
        public int NumberRedCircles { get; }
        public String Name { get; }
        public string Address { get; }
        public string DueDate { get; }
        public string OrderNumber { get; }
        public int NumberRedSquares { get; }
        public int NumberBlueSquares { get; }
        public int NumberYellowSquares { get; }
        public int NumberYellowCircles { get; }
        public int NumberRedTriangles { get; }
    }
}