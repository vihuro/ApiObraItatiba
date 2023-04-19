using Microsoft.AspNetCore.Mvc;
using ObraItatiba.Dto.Claims.ClaimsType;
using ObraItatiba.Dto.Claims.ClaimsUser;
using ObraItatiba.Interface.Login;
using ObraItatiba.Service.JWT;

namespace ObraItatiba.Controllers.Claims
{
    [ApiController]
    [Route("api/claimstype")]
    public class ClaimsTypeController : ControllerBase
    {
        private readonly IClaimTypeService _service;
        public ClaimsTypeController(IClaimTypeService service) 
        {
            this._service = service;
        }

        [HttpPost]
        //[ClaimsAuthorizeAttribute("Ti", "Full,regra2,regra3")]
        public async Task<ActionResult<RetornoClaimsTypeDto>> Insert([FromBody]CreateClaimsTypeDto dto)
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
        [HttpGet("{id}")]
        [ClaimsAuthorizeAttribute("Ti", "Full,regra2,regra3")]
        public async Task<ActionResult<RetornoClaimsTypeDto>> SelectFromId(int id)
        {
            try
            {
                return Ok(_service.SelectForId(id));
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        [ClaimsAuthorizeAttribute("Ti", "Full,regra2,regra3")]
        public async Task<ActionResult<List<RetornoClaimsTypeDto>>> SelectAll()
        {
            try
            {
                return Ok(_service.SelectAll());
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
