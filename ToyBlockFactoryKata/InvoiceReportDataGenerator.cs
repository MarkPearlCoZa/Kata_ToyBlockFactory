namespace ToyBlockFactoryKata
{
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
            result.NumberOfBlueTriangles = order.NumberBlueTriangles;
            result.NumberOfYellowTriangles = order.NumberYellowTriangles;
            return result;
        }
    }
}