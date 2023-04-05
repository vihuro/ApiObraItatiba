using Microsoft.AspNetCore.Mvc;
using ObraItatiba.Dto.Usuario;
using ObraItatiba.Interface.Login;
using ObraItatiba.Service.ExceptionCuton;
using ObraItatiba.Service.JWT;

namespace ObraItatiba.Controllers.Usuario
{
    [ApiController]
    [Route("api/login")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _service;
        public UsuarioController(IUsuarioService service)
        {
            _service = service;
        }
        [HttpPost("create")]
        public async Task<ActionResult<RetornoUsuarioDto>> Create([FromBody] CreateUsuarioDto dto)
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
        [HttpPost]
        public async Task<ActionResult<string>> Logar(LogarDto dto)
        {
            try
            {
                return Ok(_service.Logar(dto));
            }
            catch (Exception ex)
            {
                if(ex.HResult == 404)
                {
                    return NotFound(ex.Message);
                }
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{apelido}")]
        [ClaimsAuthorizeAttribute("Admin","regra1,regra2,regra3")]
        public async Task<ActionResult<RetornoUsuarioDto>> ProcurarPorApelido(string apelido)
        {
            try
            {
                return Ok(_service.ProcurarPorApelido(apelido));
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        [HttpGet("todos")]
        [ClaimsAuthorizeAttribute("Admin", "")]
        public async Task<ActionResult<List<RetornoUsuarioDto>>> BuscarTodos()
        {
            try
            {
                return Ok(_service.BuscarTodos());
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        [HttpGet("id/{id}")]
        [ClaimsAuthorizeAttribute("Admin", "")]
        public async Task<ActionResult<RetornoUsuarioDto>> BuscarPorId(int id)
        {
            try
            {
                return Ok(_service.BuscarPorId(id));
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

    }
}
