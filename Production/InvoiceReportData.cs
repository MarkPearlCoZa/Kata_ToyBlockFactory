namespace ToyBlockFactoryKata
{
    public class InvoiceReportData
    {
        public string Name { get; set; }
        public string Address{ get; set; }
        public string DueDate{ get; set; }
        public string OrderNumber{ get; set; }
        public int NumberOfRedSquares { get; set; }
        public int NumberOfBlueSquares { get; set; }
        public int NumberOfYellowSquares { get; set; }
        public int NumberOfRedCircles { get; set; }
        public int NumberOfYellowCircles { get; set; }
        public int NumberOfBlueCircles { get; set; }
        public int NumberOfRedTriangles { get; set; }
        public int NumberOfYellowTriangles { get; set; }
        public int NumberOfBlueTriangles { get; set; }

        public int TotalSquares => NumberOfBlueSquares + NumberOfYellowSquares + NumberOfRedSquares;

        public int TotalCircles => NumberOfYellowCircles + NumberOfBlueCircles + NumberOfRedCircles;

        public int TotalTriangles => NumberOfRedTriangles + NumberOfBlueTriangles + NumberOfYellowTriangles;

        public int RedColorSurcharge
        {
            get
            {
                const int redSurchargeAmountPerItem = 1;
                return (NumberOfRedCircles + NumberOfRedSquares + NumberOfRedTriangles) * redSurchargeAmountPerItem;
            }
        }
        private int CostPerSquare = 1;
        private int CostPerTriangle = 2;
        private int CostPerCircle = 3;

        public int TotalCostForSquares => CostPerSquare * TotalSquares;
        public int TotalCostForTriangles => CostPerTriangle * TotalTriangles;
        public int TotalCostForCircles => CostPerCircle * TotalCircles;
        public int GrandTotal => TotalCostForSquares + RedColorSurcharge + TotalCostForCircles + TotalCostForTriangles;
    }
}