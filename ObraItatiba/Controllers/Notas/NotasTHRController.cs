using Microsoft.AspNetCore.Mvc;
using ObraItatiba.Dto.Notas.Thr;
using ObraItatiba.Interface.NotasTHR;

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
        public async Task<ActionResult<RetornoNotaThrDto>> GetNotNumeroNota(string numeroNota)
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
  
    }
}
