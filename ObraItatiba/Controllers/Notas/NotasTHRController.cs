using Microsoft.AspNetCore.Mvc;
using ObraItatiba.Dto.Notas.Thr;
using ObraItatiba.Interface.NotasTHR;
using ObraItatiba.Service.JWT;

namespace ObraItatiba.Controllers.Notas
{
    [ApiController]
    [Route("api/notas")]
    public class NotasTHRController : ControllerBase
    {
        private readonly INotasThrService _service;
        public NotasTHRController(INotasThrService service)
        {
            _service = service;
        }
        [HttpPost]
        [ClaimsAuthorizeAttribute("Financeiro", "regra1,regra2,regra3")]
        public async Task<ActionResult<RetornoNotaThrDto>> Insert([FromBody] InsertNotaDto dto) 
        {
            try
            {
                return Ok(_service.Insert(dto));
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        [HttpGet("{numeroNota}")]
        [ClaimsAuthorizeAttribute("Financeiro", "regra1,regra2,regra3")]
        public async Task<ActionResult<List<RetornoNotaThrDto>>> GetNotNumeroNota(int numeroNota)
        {
            try
            {
                return Ok(_service.GetNotaNumeroNota(numeroNota));
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }


        [HttpGet]

        public async Task<ActionResult<RetornoNotaThrDto>> GetAll()
        {
            try
            {
                return Ok(_service.GetAll());
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        [HttpDelete]
        [ClaimsAuthorizeAttribute("Financeiro", "regra1,regra2,regra3")]

        public async Task<ActionResult<string>> DeleteAll()
        {
            try
            {
                return Ok(_service.DeleteAll());
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
  
    }
}
