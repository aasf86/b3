using static B3.Domain.Entities.Rules.CDBRules;

namespace B3.Domain.Entities
{
    public partial class CDB
    {
        private decimal _grossTotal;
        private decimal _liquidTotal;

        public CDB(decimal value, int months)
        {
            if (value < CDBRule.MinimalValue) throw new InvalidDataException(CDBMsgDialog.RequiredValue);
            if (months < CDBRule.MinimalMonth) throw new InvalidDataException(CDBMsgDialog.RequiredMonths);

            Value = value;
            Months = months;
        }

        public decimal Value { get; private set; }
        public int Months { get; private set; }

        public decimal GrossTotal
        {
            get { return _grossTotal > 0 ? _grossTotal : _grossTotal = CalculateGrossTotal(); }
        }

        public decimal LiquidTotal
        {
            get { return _liquidTotal > 0 ? _liquidTotal : _liquidTotal = CalculateLiquidTotal(); }
        }

        public decimal ToRoundGrossTotal
        {
            get { return Math.Round(GrossTotal, 2, MidpointRounding.ToEven); }
        }

        public decimal ToRoundLiquidTotal
        {
            get { return Math.Round(LiquidTotal, 2, MidpointRounding.ToEven); }
        }

        private decimal CalculateGrossTotal()
        {
            var value = Value;
            var newValue = 0m;

            for (int i = 0; i < Months; i++)
            {
                newValue = value * (1 + CDBRule.CDI * CDBRule.TB);
                value = newValue;
            }

            return value;
        }

        private decimal CalculateLiquidTotal()
        {
            if (Months >= CDBRule._Over24Months) return GetLiquidTotal(CDBRule._Over24Months);

            if (Months > CDBRule._12Months) return GetLiquidTotal(CDBRule._24Months);

            if (Months > CDBRule._6Months) return GetLiquidTotal(CDBRule._12Months);

            return GetLiquidTotal(CDBRule._6Months);
        }

        private decimal GetLiquidTotal(int monthKey)
        {
            var delta = GrossTotal - Value;
            var tax = CDBRule.TAX[monthKey];
            var valueTax = delta * tax;
            return GrossTotal - valueTax;
        }
    }
}
