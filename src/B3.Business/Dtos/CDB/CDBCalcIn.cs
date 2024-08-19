using System.ComponentModel.DataAnnotations;
using static B3.Domain.Entities.Rules.CDBRules;

namespace B3.Business.Dtos.CDB
{
    public class CDBCalcIn
    {
        [Required(ErrorMessage = CDBMsgDialog.RequiredValue)]
        [Range(CDBRule.MinimalValue, double.MaxValue, ErrorMessage = CDBMsgDialog.InvalidValue)]
        public decimal Value { get; set; }

        [Required(ErrorMessage = CDBMsgDialog.RequiredMonths)]
        [Range(CDBRule.MinimalMonth, double.MaxValue, ErrorMessage = CDBMsgDialog.InvalidMonths)]
        public int Months { get; set; }
    }
}
