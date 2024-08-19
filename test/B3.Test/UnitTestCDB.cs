using static B3.Domain.Entities.Rules.CDBRules;
using Entity = B3.Domain.Entities;

namespace B3.Test.Tests
{
    public class UnitTestCDB
    {
        [Fact(DisplayName = "[CDB] com valor de 1000 em 1 mês, resulta no total bruto de 1.009,72")]
        public void When_Value_1000_In_1_Months_Then_Return_GrossTotal_1009_72()
        {
            var months = 1;
            var value = 1000m;
            var calcCDB = new Entity.CDB(value, months);

            Assert.Equal("1.009,72", calcCDB.GrossTotal.ToString("N2"));
            Assert.Equal("1.007,53", calcCDB.LiquidTotal.ToString("N2"));
            Assert.Equal(value, calcCDB.Value);
            Assert.Equal(months, calcCDB.Months);
        }

        [Fact(DisplayName = "[CDB] com valor de 1000 em 6 meses, resulta no total bruto de 1.059,76")]
        public void When_Value_1000_In_6_Months_Then_Return_GrossTotal_1059_76()
        {
            var months = 6;
            var value = 1000m;
            var calcCDB = new Entity.CDB(value, months);

            Assert.Equal("1.059,76", calcCDB.GrossTotal.ToString("N2"));
            Assert.Equal("1.046,31", calcCDB.LiquidTotal.ToString("N2"));
            Assert.Equal(value, calcCDB.Value);
            Assert.Equal(months, calcCDB.Months);
        }

        [Fact(DisplayName = "[CDB] com valor de 1000 em 8 meses, resulta no total bruto de 1.080,46")]
        public void When_Value_1000_In_8_Months_Then_Return_GrossTotal_1080_46()
        {
            var months = 8;
            var value = 1000m;
            var calcCDB = new Entity.CDB(value, months);

            Assert.Equal("1.080,46", calcCDB.GrossTotal.ToString("N2"));
            Assert.Equal("1.064,37", calcCDB.LiquidTotal.ToString("N2"));
            Assert.Equal(value, calcCDB.Value);
            Assert.Equal(months, calcCDB.Months);
        }

        [Fact(DisplayName = "[CDB] com valor de 1000 em 14 meses, resulta no total bruto de 1.145,02")]
        public void When_Value_1000_In_14_Months_Then_Return_GrossTotal_1145_02()
        {
            var months = 14;
            var value = 1000m;
            var calcCDB = new Entity.CDB(value, months);

            Assert.Equal("1.145,02", calcCDB.GrossTotal.ToString("N2"));
            Assert.Equal("1.119,64", calcCDB.LiquidTotal.ToString("N2"));
            Assert.Equal(value, calcCDB.Value);
            Assert.Equal(months, calcCDB.Months);
        }

        [Fact(DisplayName = "[CDB] com valor de 1000 em 24 meses, resulta no total bruto de 1.261,31")]
        public void When_Value_1000_In_24_Months_Then_Return_GrossTotal_1261_31()
        {
            var months = 24;
            var value = 1000m;
            var calcCDB = new Entity.CDB(value, months);

            Assert.Equal("1.261,31",calcCDB.GrossTotal.ToString("N2"));
            Assert.Equal("1.215,58", calcCDB.LiquidTotal.ToString("N2"));
            Assert.Equal(value, calcCDB.Value);
            Assert.Equal(months, calcCDB.Months);
        }

        [Fact(DisplayName = "[CDB] com valor de 1000 em 35 meses, resulta no total bruto de 1.402,92")]
        public void When_Value_1000_In_35_Months_Then_Return_GrossTotal_1402_92()
        {
            var months = 35;
            var value = 1000m;
            var calcCDB = new Entity.CDB(value, months);

            Assert.Equal("1.402,92", calcCDB.GrossTotal.ToString("N2"));
            Assert.Equal("1.342,48", calcCDB.LiquidTotal.ToString("N2"));
            Assert.Equal(value, calcCDB.Value);
            Assert.Equal(months, calcCDB.Months);
        }


        [Fact(DisplayName = "[CDB] com valor de 0, resulta em 'Exception'")]
        public void When_Value_0_Then_Return_Throw_Exception()
        {
            var exc = Assert.Throws<InvalidDataException>(() =>
            {
                var calcCDB = new Entity.CDB(0, 24);
            });

            Assert.Equal(CDBMsgDialog.RequiredValue, exc.Message);
        }

        [Fact(DisplayName = "[CDB] com mês 0, resulta em 'Exception'")]
        public void When_Mounth_0_Then_Return_Throw_Exception()
        {
            var exc = Assert.Throws<InvalidDataException>(() =>
            {
                var calcCDB = new Entity.CDB(1000, 0);
            });

            Assert.Equal(CDBMsgDialog.RequiredMonths, exc.Message);
        }
    }
}