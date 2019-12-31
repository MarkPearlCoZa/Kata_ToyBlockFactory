using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Xunit;

namespace ToyBlockFactoryKata
{
    public class InvoiceReportGeneratorTests
    {
        [Fact]
        public void GenerateEmptyInvoice()
        {
            var reportGenerator = new InvoiceReportDataGenerator();
            var order = new Order("Mark Pearl", "1 Bob Avenue, Auckland", "19 Jan 2019", "0001", 0, 0, 0);
            var reportData = reportGenerator.Generate(order);
            Assert.Equal("Name: Mark Pearl Address: 1 Bob Avenue, Auckland, Due Date: 19 Jan 2019, Order #: 0001", reportData.ElementAt(0));
        }
    }

    public class InvoiceReportDataGenerator
    {
        public IReadOnlyCollection<string> Generate(Order order)
        {
            var result = new List<string>();
            var customerName = order.Name;
            var customerAddress = order.Address;
            var dueDate = order.DueDate;
            var orderNumber = "0001";
            result.Add($"Name: {customerName} Address: {customerAddress}, Due Date: {dueDate}, Order #: {orderNumber}");
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
            
            return new Order(name, address, dueDate,orderNumber, numberRedSquares, numberBlueSquares, numberYellowSquares);
        }
    }

    public class Order
    {
        public Order(string name, string address, string dueDate, string orderNumber, int numberRedSquares,
            int numberBlueSquares,
            int numberYellowSquares)
        {
            Name = name;
            Address = address;
            DueDate = dueDate;
            NumberRedSquares = numberRedSquares;
            NumberBlueSquares = numberBlueSquares;
            NumberYellowSquares = numberYellowSquares;
        }

        public String Name { get; }
        public string Address { get; }
        public string DueDate { get; }
        public int NumberRedSquares { get; }
        public int NumberBlueSquares { get; }
        public int NumberYellowSquares { get; }
    }
}