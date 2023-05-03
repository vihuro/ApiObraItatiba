using Microsoft.AspNetCore.Mvc;
using ObraItatiba.Interface.Conhecimento.Obra;
using ObraItatiba.Dto.Conhecimento.Obra;

namespace ObraItatiba.Controllers.Conhecimento
{
    [Route("api/conhecimento/radar")]
    public class ConhecimentoObraController : ControllerBase
    {
        private readonly IConhecimentoObraService _service;
        public ConhecimentoObraController(IConhecimentoObraService _service) 
        { this._service = _service; }
        [HttpGet]
        public ActionResult<List<ConhecimentoObraDto>> BuscarConhecimentos()
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
    }
}
