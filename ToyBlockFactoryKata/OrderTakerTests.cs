using System;
using System.Collections.Generic;
using System.IO;
using Xunit;

namespace ToyBlockFactoryKata
{
    public class OrderTakerTests
    {
        private static string _s;

        [Fact]
        public  void PromptName()
        {
            var sut = new OrderTaker();
            using (StringWriter sw1 = new StringWriter())
            {
                using (StringReader sr = new StringReader($"Mark Pearl{Environment.NewLine}"))
                {
                    Console.SetOut(sw1);
                    Console.SetIn(sr);
                    var result = sut.GetOrder();
                    Assert.Equal("Please input your Name: " + Environment.NewLine, sw1.ToString());
                    Assert.Equal("Mark Pearl", result.Name);
                }
            }
        }
    }

    public class OrderTaker
    {
        public Order GetOrder()
        {
            Console.WriteLine("Please input your Name: ");
            var name = Console.ReadLine();
            return new Order(name);
        }
    }

    public class Order
    {
        public Order(string name)
        {
            Name = name;
        }

        public String Name { get; }
    }
}