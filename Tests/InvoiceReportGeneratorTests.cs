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
            var order = new Order("", "", "", "", 0, numberOfBlueSquares, 0, 0, 0, 0, 0, 0);
            var reportData = reportGenerator.Generate(order);
            Assert.Equal(numberOfBlueSquares, reportData.NumberOfBlueSquares);
            Assert.Equal(expectedTotalSquares, reportData.TotalSquares);
            Assert.Equal(0, reportData.TotalCircles);
            Assert.Equal(0, reportData.TotalTriangles);
            Assert.Equal(expectedCost, reportData.TotalCostForSquares);
            Assert.Equal(expectedCost, reportData.GrandTotal);
        }
        
        [Theory]
        [InlineData(1, 1, 2, 2)]
        [InlineData(2, 2, 4, 4)]
        public void GenerateSimpleInvoiceCostingForYellowTriangles(int numberOfYellowTriangles, 
            int expectedTotalTriangles, int expectedTotalCostForTriangles, int expectedGrandTotal)
        {
            var reportGenerator = new InvoiceReportDataGenerator();
            var order = new Order("", "", "", "",
                0, 0, 0, 0, 0, 0, 0, 0, numberOfYellowTriangles);
            var reportData = reportGenerator.Generate(order);
            Assert.Equal(numberOfYellowTriangles, reportData.NumberOfYellowTriangles);
            Assert.Equal(0, reportData.TotalSquares);
            Assert.Equal(0, reportData.TotalCircles);
            Assert.Equal(expectedTotalTriangles, reportData.TotalTriangles);
            Assert.Equal(expectedTotalCostForTriangles, reportData.TotalCostForTriangles);
            Assert.Equal(expectedGrandTotal, reportData.GrandTotal);
        }
        
        [Theory]
        [InlineData(1, 1, 2, 2)]
        [InlineData(2, 2, 4, 4)]
        public void GenerateSimpleInvoiceCostingForBlueTriangles(int numberOfBlueTriangles, 
            int expectedTotalTriangles, int expectedTotalCostForTriangles, int expectedGrandTotal)
        {
            var reportGenerator = new InvoiceReportDataGenerator();
            var order = new Order("", "", "", "",
                0, 0, 0, 0, 0, 0, 0, numberOfBlueTriangles);
            var reportData = reportGenerator.Generate(order);
            Assert.Equal(numberOfBlueTriangles, reportData.NumberOfBlueTriangles);
            Assert.Equal(0, reportData.TotalSquares);
            Assert.Equal(0, reportData.TotalCircles);
            Assert.Equal(expectedTotalTriangles, reportData.TotalTriangles);
            Assert.Equal(expectedTotalCostForTriangles, reportData.TotalCostForTriangles);
            Assert.Equal(expectedGrandTotal, reportData.GrandTotal);
        }
        
        [Theory]
        [InlineData(1,1, 1, 2, 3)]
        [InlineData(2,2, 2, 4, 6)]
        public void GenerateSimpleInvoiceCostingForRedTriangles(int numberOfRedTriangles, int expectedRedColorSurcharge,
            int expectedTotalTriangles, int expectedTotalCostForTriangles, int expectedGrandTotal)
        {
            var reportGenerator = new InvoiceReportDataGenerator();
            var order = new Order("", "", "", "",
                0, 0, 0, 0, 0, 0, numberOfRedTriangles,0);
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
                0, 0, 0, 0, 0, numberOfRedCircles, 0, 0);
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
            var order = new Order("", "", "", "", 0, 0, 0, 0, numberOfBlueCircles, 0,0, 0);
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
            var order = new Order("", "", "", "", 0, 0, 0, numberOfYellowCircles, 0, 0 ,0, 0);
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
            var order = new Order("", "", "", "", 0, 0, numberOfYellowSquares, 0, 0, 0,0, 0);
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
            var order = new Order("", "", "", "", numberOfRedSquares, 0, 0, 0, 0, 0, 0, 0);
            var reportData = reportGenerator.Generate(order);
            Assert.Equal(numberOfRedSquares, reportData.NumberOfRedSquares);
            Assert.Equal(expectedTotalSquares, reportData.TotalSquares);
            Assert.Equal(0, reportData.TotalCircles);
            Assert.Equal(0, reportData.TotalTriangles);
            Assert.Equal(expectedTotalCostForSquares, reportData.TotalCostForSquares);
            Assert.Equal(expectedRedColorSurcharge, reportData.RedColorSurcharge);
            Assert.Equal(expectedGrandTotal, reportData.GrandTotal);
        }

        [Fact]
        
        public void GenerateEmptyInvoiceWithJobDetails()
        {
            var reportGenerator = new InvoiceReportDataGenerator();
            var order = new Order("Mark Pearl", "3 Vinewood Dr", "19 Jan 1980", "123", 0, 0, 0, 0, 0, 0, 0, 0);
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
            var order = new Order("", "", "", "", 0, 0, 0, 0, 0, 0, 0, 0);
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
}