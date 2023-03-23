using Microsoft.AspNetCore.Mvc;
using ObraItatiba.Dto.Claims.ClaimsUser;
using ObraItatiba.Interface.Login;

namespace ObraItatiba.Controllers.Claims
{
    [ApiController]
    [Route("api/claims/user")]
    public class ClaimsForUserController : ControllerBase
    {
        private readonly IClaimsForUserService _service;
        public ClaimsForUserController(IClaimsForUserService service)
        {
            this._service = service;
        }
        [HttpPut]
        public async Task<ActionResult<ClaimForUserRetorno>> Insert(ClaimsCadastroUsuarioDto dto)
        {
            try
            {
                return Ok(_service.InsertClaim(dto));
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        [HttpGet("todos")]
        public async Task<ActionResult<List<ListClaimsForUserDto>>> GetAllClaimsForUser()
        {
            try
            {
                return Ok(_service.GetAllClaimsForUser());
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        [HttpGet("{idUsuario}")]
        public async Task<ActionResult<List<ClaimsForUserDto>>> GetClaimsForUserId(int idUsuario)
        {
            try
            {
                return Ok(_service.ListClaimsForUser(idUsuario));
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
