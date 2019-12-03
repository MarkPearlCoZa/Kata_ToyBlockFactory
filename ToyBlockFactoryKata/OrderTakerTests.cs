using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Xunit;

namespace ToyBlockFactoryKata
{
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
                consoleInput.Add("1");
                
                using StringReader sr = new StringReader(String.Join(Environment.NewLine,consoleInput));
                Console.SetOut(sw);
                Console.SetIn(sr);
                var result = sut.GetOrder();
                var consoleOutput = sw.ToString().Split(Environment.NewLine).ToList();
                Assert.Equal("Please input your Name: ", consoleOutput[0]);
                Assert.Equal("Please input your Address: ", consoleOutput[1]);
                Assert.Equal("Please input your Due Date: ", consoleOutput[2]);
                Assert.Equal("", consoleOutput[3]);
                Assert.Equal("Please input the number of Red Squares: ", consoleOutput[4]);
                Assert.Equal("Please input the number of Blue Squares: ", consoleOutput[5]);
                Assert.Equal("Please input the number of Yellow Squares: ", consoleOutput[6]);
                
                Assert.Equal("Mark Pearl", result.Name);
                Assert.Equal("1 Bob Avenue, Auckland", result.Address);
                Assert.Equal("19 Jan 2019", result.DueDate);
                
                Assert.Equal(1, result.NumberRedSquares);
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
            
            Console.WriteLine("");
            Console.WriteLine("Please input the number of Red Squares: ");
            var numberRedSquares = Convert.ToInt32(Console.ReadLine());
            
            Console.WriteLine("Please input the number of Blue Squares: ");
            Console.WriteLine("Please input the number of Yellow Squares: ");
            
            return new Order(name, address, dueDate, numberRedSquares);
        }
    }

    public class Order
    {
        public Order(string name, string address, string dueDate, int numberRedSquares)
        {
            Name = name;
            Address = address;
            DueDate = dueDate;
            NumberRedSquares = numberRedSquares;
        }

        public String Name { get; }
        public string Address { get; }
        public string DueDate { get; }
        public int NumberRedSquares { get; }
        public int RedSquares { get; }
    }
}