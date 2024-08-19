using B3.Business.Dtos.CDB;
using B3.Business.Dtos;
using B3.Business.UseCases.CDB;
using Microsoft.Extensions.Logging;
using Moq;
using B3.Domain.Entities.Rules;
using static B3.Domain.Entities.Rules.CDBRules;

namespace B3.Test
{
    public  class UnitTestCDBUseCase
    {
        private readonly CDBUseCase _cdbUseCase;
        private readonly Mock<ILogger<CDBUseCase>> _logger;

        public UnitTestCDBUseCase()
        {
            _logger = new Mock<ILogger<CDBUseCase>>();
            _cdbUseCase = new CDBUseCase(_logger.Object);
        }

        [Fact(DisplayName = "[CDB-UseCase] Calcular investimento com sucesso")]
        public async void Calcule_Whit_Success()
        {
            var cdbCalcIn = new CDBCalcIn { Value = 1000, Months = 24 };
            var cdbCalcRequest = RequestBase.New(cdbCalcIn, "unit-test", "1.0");
            var cdbCalcResponse = await _cdbUseCase.CalculateInvestment(cdbCalcRequest);

            Assert.True(cdbCalcResponse.IsSuccess);
        }

        [Fact(DisplayName = "[CDB-UseCase] Calcular investimento sem sucesso")]
        public async void Calcule_Without_Success()
        {
            var cdbCalcIn = new CDBCalcIn { Value = -1, Months = 24 };
            var cdbCalcRequest = RequestBase.New(cdbCalcIn, "unit-test", "1.0");
            var cdbCalcResponse = await _cdbUseCase.CalculateInvestment(cdbCalcRequest);

            Assert.False(cdbCalcResponse.IsSuccess);
            Assert.Contains(CDBMsgDialog.InvalidValue, cdbCalcResponse.Errors);
        }
    }
}
