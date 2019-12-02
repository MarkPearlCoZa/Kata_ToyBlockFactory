using System;
using System.IO;
using Xunit;

namespace ToyBlockFactoryKata
{
    public class OrderTakerTests
    {
        private static string _s;

        [Fact]
        public  void GetName()
        {
            var sut = new OrderTaker();
            using StringWriter sw1 = new StringWriter();
            Console.SetOut(sw1);
            var sw = sw1;
            using StringReader sr = new StringReader($"Mark Pearl{Environment.NewLine}");
            Console.SetIn(sr);
            var result = sut.GetOrder();
            var expected = "Please input your Name: " + Environment.NewLine;
            Assert.Equal(expected, sw.ToString());
        }

        private static void SetConsoleInputToReader(string s1)
        {
            using StringReader sr = new StringReader(s1);
            Console.SetIn(sr);
        }

        private static StringWriter SetConsoleOutputToWriter()
        {
            using StringWriter sw = new StringWriter();
            Console.SetOut(sw);
            return sw;
        }
    }

    public class OrderTaker
    {
        public Order GetOrder()
        {
            Console.WriteLine("Please input your Name: ");
            var name = Console.ReadLine();
            return null;
        }
    }

    public class Order
    {
    }
}