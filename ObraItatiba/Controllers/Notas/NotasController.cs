﻿using Microsoft.AspNetCore.Mvc;
using ObraItatiba.Dto.Notas;
using ObraItatiba.Interface.NotasRadar;
using System.Text;

namespace ObraItatiba.Controllers.Notas
{
    [ApiController]
    [Route("api/notas/radar")]
    public class NotasController : ControllerBase
    {
        private readonly INotasRadarService _service;
        public NotasController(INotasRadarService service)
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
