using Microsoft.AspNetCore.Mvc;
using ObraItatiba.Dto.Time;
using ObraItatiba.Interface.Time;

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
        [HttpDelete]
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
