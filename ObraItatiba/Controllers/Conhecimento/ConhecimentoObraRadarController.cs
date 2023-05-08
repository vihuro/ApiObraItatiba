using Microsoft.AspNetCore.Mvc;
using ObraItatiba.Interface.Conhecimento.Obra;
using ObraItatiba.Dto.Conhecimento.Obra.Conhecimento;

namespace ObraItatiba.Controllers.Conhecimento
{
    [Route("api/conhecimento/radar")]
    public class ConhecimentoObraRadarController : ControllerBase
    {
        private readonly IConhecimentoObraService _service;
        public ConhecimentoObraRadarController(IConhecimentoObraService _service) 
        { this._service = _service; }
        [HttpGet]
        public async Task<ActionResult<List<ConhecimentoObraDto>>> BuscarConhecimentos()
        {
            try
            {
                return Ok(_service.LerArquivoTXT());
            }
            catch (Exception ex )
            {

                return BadRequest(ex.Message);
            }
        }
        [HttpGet("notsaved")]
        public async Task< ActionResult<List<ConhecimentoObraDto>>> GetConhecimentoNotSaved()
        {
            try
            {
                return Ok(_service.GetListNotSaved());
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
