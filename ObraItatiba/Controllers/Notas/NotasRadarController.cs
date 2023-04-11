using Microsoft.AspNetCore.Mvc;
using ObraItatiba.Dto.Notas.Radar;
using ObraItatiba.Interface.NotasRadar;
using ObraItatiba.Service.JWT;
using System.Text;

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
    }
}
