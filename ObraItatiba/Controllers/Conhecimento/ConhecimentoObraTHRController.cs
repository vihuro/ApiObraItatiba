using Microsoft.AspNetCore.Mvc;
using ObraItatiba.Dto.Conhecimento.Obra.Conhecimento;
using ObraItatiba.Interface.Conhecimento.Obra;

namespace ObraItatiba.Controllers.Conhecimento
{
    [ApiController]
    [Route("api/conhecimento")]
    public class ConhecimentoObraTHRController : ControllerBase
    {
        private readonly IConhecimentoTHRService _service;
        public ConhecimentoObraTHRController(IConhecimentoTHRService service)
        {
            _service = service;
        }
        [HttpPost]
        public async Task<ActionResult<ConhecimentoTHRRetornoDto>> Insert([FromBody] ConhecimentoObraTHRInsertDto dto)
        {
            try
            {
                return Created("", _service.Insert(dto));
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        public async Task<ActionResult<List<ConhecimentoTHRRetornoDto>>> GetAll()
        {
            try
            {
                return Ok(_service.GetList());
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        [HttpGet("{numeroDocumento}")]
        public async Task<ActionResult<ConhecimentoTHRRetornoDto>> GetByDocumento(int numeroDocumento)
        {
            try
            {
                return Ok(_service.GetByNumeroDocumento(numeroDocumento));
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
