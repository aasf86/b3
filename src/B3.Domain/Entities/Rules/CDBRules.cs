namespace B3.Domain.Entities.Rules
{
    public partial class CDBRules
    {
        public static class CDBRule
        {
            public const int MinimalValue = 1;
            public const int MinimalMonth = 1;

            public const decimal TB = 1.08m;// 108 %
            public const decimal CDI = 0.009m;// 0,9 %

            public const int _6Months = 6;
            public const int _12Months = 12;
            public const int _24Months = 24;
            public const int _Over24Months = 25;

            public static readonly Dictionary<int, decimal> TAX = new()
            {
              //{Meses,             %}
                { _6Months,         0.225m },  // 22.5 %
                { _12Months,        0.20m },   // 20 %
                { _24Months,        0.175m },  // 17.5 %
                { _Over24Months,    0.15m }    // 15 %
            };
        }

        public static class CDBMsgDialog
        {
            public const string RequiredValue = "Informe o valor.";
            public const string InvalidValue = "Informe um valor válido.";

            public const string RequiredMonths = "Informe o prazo de meses.";
            public const string InvalidMonths = "Informe um prazo válido.";
        }
    }
}
