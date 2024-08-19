using B3.Business.Contracts.UseCases.CDB;
using B3.Business.Dtos;
using B3.Business.Dtos.CDB;
using Microsoft.AspNetCore.Mvc;

namespace B3.Api.Controllers
{
    /// <summary>
    /// Controller para gestão de CDB's.
    /// </summary>

    [Route("api/[controller]")]
    [ApiController]
    public class CDBController : ControllerBase
    {
        private readonly ICDBUseCase _CDBUseCase;
        private ICDBUseCase CDBUseCase => _CDBUseCase;

        /// <summary>
        /// Controller para gestão de CDB's.
        /// </summary>
        /// <param name="cdbUseCase"></param>
        public CDBController(ICDBUseCase cdbUseCase)
        {
            _CDBUseCase = cdbUseCase;
        }
        
        /// <summary>
        /// Calcular investimento do CDB.
        /// </summary>
        /// <param name="cdbCalcIn"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] CDBCalcIn cdbCalcIn)
        {
            if (ModelState.IsValid)
            {
                var cdbCalcRequest = RequestBase.New(cdbCalcIn, "host:api", "1.0");                
                var cdbCalcResponse = await CDBUseCase.CalculateInvestment(cdbCalcRequest);

                if (cdbCalcResponse.IsSuccess)
                    return Ok(cdbCalcResponse);

                return BadRequest(cdbCalcResponse);
            }

            return BadRequest();
        }       
    }
}
