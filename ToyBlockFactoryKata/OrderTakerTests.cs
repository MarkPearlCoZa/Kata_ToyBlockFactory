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
}