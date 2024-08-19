namespace B3.Business.Dtos.CDB
{
    public class CDBCalcOut
    {
        public decimal Value { get; set; }
        public int Months { get; set; }
        public decimal GrossTotal { get; set; }
        public decimal LiquidTotal { get; set; }
        public string ToFormatMoneyGrossTotal { get { return $"R$ {GrossTotal.ToString("N2")}"; } }
        public string ToFormatMoneyLiquidTotal { get { return $"R$ {LiquidTotal.ToString("N2")}"; } }
    }
}
