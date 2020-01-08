using System;

namespace ToyBlockFactoryKata
{
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
            
            return new Order(name, address, dueDate,orderNumber, numberRedSquares, numberBlueSquares, numberYellowSquares, 0, 0, 0, 0, 0);
        }
    }
}