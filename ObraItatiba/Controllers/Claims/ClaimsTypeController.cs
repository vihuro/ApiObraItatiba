using Microsoft.AspNetCore.Mvc;
using ObraItatiba.Dto.Claims.ClaimsType;
using ObraItatiba.Dto.Claims.ClaimsUser;
using ObraItatiba.Interface.Login;

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
