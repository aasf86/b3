using B3.Business.Contracts.UseCases.CDB;
using B3.Business.Dtos;
using B3.Business.Dtos.CDB;
using Microsoft.Extensions.Logging;
using Entity = B3.Domain.Entities;

namespace B3.Business.UseCases.CDB
{
    public class CDBUseCase : UseCaseBase, ICDBUseCase
    {
        public CDBUseCase(ILogger<CDBUseCase> logger) : base(logger) { }

        public async Task<ResponseBase<CDBCalcOut>> CalculateInvestment(RequestBase<CDBCalcIn> cdbInvestimentrequest)
        {
            try
            {
                "Iniciando Calculo de investimento".LogInf();

                var cdbInvestiment = cdbInvestimentrequest.Data;
                var cdbInvestimentResponse = ResponseBase.New(new CDBCalcOut(), cdbInvestimentrequest.RequestId);
                var result = Validate(cdbInvestiment);

                if (!result.IsSuccess)
                {
                    cdbInvestimentResponse.Errors.AddRange(result.Validation.Select(x => x.ErrorMessage).ToList());
                    var errors = string.Join("\n", cdbInvestimentResponse.Errors.ToArray());
                    $"Dados inválidos para o calculo: {errors} ".LogWrn();
                    return cdbInvestimentResponse;
                }

                var cdb = new Entity.CDB(cdbInvestiment.Value, cdbInvestiment.Months);

                cdbInvestimentResponse.Data = new CDBCalcOut 
                { 
                    Value = cdb.Value,
                    Months = cdb.Months,
                    GrossTotal = cdb.ToRoundGrossTotal,                    
                    LiquidTotal = cdb.ToRoundLiquidTotal
                };

                return cdbInvestimentResponse;
            }
            catch (Exception exc)
            {
                "Erro ao calcular investimento Dados:{{CDB}}".LogErr(cdbInvestimentrequest.Data);

                exc.Message.LogErr(exc);

                var cdbInvestimentResponse = ResponseBase.New(new CDBCalcOut(), cdbInvestimentrequest.RequestId);
#if DEBUG
                cdbInvestimentResponse.Errors.Add(exc.Message);
#endif
                cdbInvestimentResponse.Errors.Add("Erro ao calcular investimento.");

                return cdbInvestimentResponse;
            }
        }
    }
}
