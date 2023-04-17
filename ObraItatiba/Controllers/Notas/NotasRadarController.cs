using Microsoft.AspNetCore.Mvc;
using ObraItatiba.Dto.Notas.Radar;
using ObraItatiba.Dto.Notas.Thr;
using ObraItatiba.Interface.NotasRadar;

namespace ObraItatiba.Controllers.Notas
{
    [ApiController]
    [Route("api/notas/radar")]
    public class NotasRadarController : ControllerBase
    {
        private readonly INotasRadarService _service;
        public NotasRadarController(INotasRadarService service)
        {
            this._service = service;
        }
        [HttpGet]

        public ActionResult<List<NotasArquivoTextoDto>> BuscarNotasArquivoTexto()
        {
            try
            {
                return Ok(_service.GerarArquivo());
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }
        [HttpGet("notsaved")]
        public async Task<ActionResult<List<RetornoNotaThrDto>>> GetNotSaved()
        {
            try
            {
                return Ok(_service.NotSaved());
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
