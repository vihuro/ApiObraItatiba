using Microsoft.AspNetCore.Mvc;
using ObraItatiba.Dto.Time;
using ObraItatiba.Interface.Time;
using ObraItatiba.Service.JWT;

namespace ObraItatiba.Controllers.Time
{
    [ApiController]
    [Route("api/time")]
    public class TimeController : ControllerBase
    {
        private readonly ITimeService _service;
        public TimeController(ITimeService service)
        {
            _service = service;
        }
        [HttpPost]
        [ClaimsAuthorizeAttribute("Financeiro", "Full,regra2,regra3")]
        public async Task<ActionResult<RetornoTimeDto>> Insert(InsertTimeDto dto)
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
        [HttpGet("{time}")]
        [ClaimsAuthorizeAttribute("Financeiro", "Full,regra2,regra3")]
        public async Task<ActionResult<RetornoTimeDto>> TimeGetForTime(string time)
        {
            try
            {
                return Ok(_service.BuscarPorTime(time));
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        [ClaimsAuthorizeAttribute("Financeiro", "Full,regra2,regra3")]
        public async Task<ActionResult<List<RetornoTimeDto>>> GetTimeList()
        {
            try
            {
                return Ok(_service.ListTimes());
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<string>> DeleteForId(int id)
        {
            try
            {
                return Ok(_service.DeleteForId(id));
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        [HttpGet("{id}")]
        [ClaimsAuthorizeAttribute("Financeiro", "Full,regra2,regra3")]
        public async Task<ActionResult<RetornoTimeDto>> GetForId([FromRoute]int id)
        {
            try
            {
                return Ok(_service.GetForId(id));
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        [HttpDelete]
        [ClaimsAuthorizeAttribute("Financeiro", "Full,regra2,regra3")]
        public async Task<ActionResult<string>> DeleteAll()
        {
            try
            {
                return Ok(_service.DeleteAll());
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }


    }
}
