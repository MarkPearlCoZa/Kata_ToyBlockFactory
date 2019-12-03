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
                using StringReader sr = new StringReader($"Mark Pearl{Environment.NewLine}Bobby");
                Console.SetOut(sw);
                Console.SetIn(sr);
                var result = sut.GetOrder();
                var consoleOutput = sw.ToString().Split(Environment.NewLine).ToList();
                Assert.Equal("Please input your Name: ", consoleOutput[0]);
                Assert.Equal("Please input your Address: ", consoleOutput[1]);
//                Assert.Equal("Please input your Due Date: ", consoleOutput[2]);
                Assert.Equal("Mark Pearl", result.Name);
//                Assert.Equal("Mark Pearl", result.Address);
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
            return new Order(name, address);
        }
    }

    public class Order
    {
        public Order(string name, string address)
        {
            Name = name;
            Address = address;
        }

        public String Name { get; }
        public string Address { get; }
    }
}