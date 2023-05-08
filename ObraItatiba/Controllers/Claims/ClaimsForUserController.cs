using Microsoft.AspNetCore.Mvc;
using ObraItatiba.Dto.Claims.ClaimsUser;
using ObraItatiba.Interface.Login;
using ObraItatiba.Service.JWT;

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
        //[ClaimsAuthorizeAttribute("Ti", "Full,regra2,regra3")]
        public async Task<ActionResult<ClaimForUserRetorno>> Insert([FromBody]ClaimsCadastroUsuarioDto dto)
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
        [ClaimsAuthorizeAttribute("Ti", "Full,regra2,regra3")]
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
        [ClaimsAuthorizeAttribute("Ti", "Full,regra2,regra3")]
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
        [HttpDelete("delete")]
        [ClaimsAuthorizeAttribute("Ti", "Full,regra2,regra3")]
        public async Task<ActionResult> DeleteClaimForUser(ClaimsCadastroUsuarioDto dto)
        {
            try
            {
                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }
    }
}
