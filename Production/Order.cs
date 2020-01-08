using System;

namespace ToyBlockFactoryKata
{
    public class Order
    {
        public Order(string name, string address, string dueDate, string orderNumber, int numberRedSquares,
            int numberBlueSquares,
            int numberYellowSquares, int numberYellowCircles, int numberBlueCircles, int numberRedCircles,
            int numberRedTriangles, int numberBlueTriangles, int numberYellowTriangles = 0)
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
            NumberBlueTriangles = numberBlueTriangles;
            NumberYellowTriangles = numberYellowTriangles;
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
        public int NumberBlueTriangles { get; }
        public int NumberYellowTriangles { get; }
    }
}