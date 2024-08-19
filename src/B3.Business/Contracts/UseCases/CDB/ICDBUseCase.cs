using B3.Business.Dtos;
using B3.Business.Dtos.CDB;

namespace B3.Business.Contracts.UseCases.CDB
{
    public interface ICDBUseCase : IValidators
    {
        Task<ResponseBase<CDBCalcOut>> CalculateInvestment(RequestBase<CDBCalcIn> request);
    }
}
