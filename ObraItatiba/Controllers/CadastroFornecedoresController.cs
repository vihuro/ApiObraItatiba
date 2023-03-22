using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;

namespace ObraItatiba.Controllers
{
    [ApiController]
    [Route("api/fornecedores")]
    public class CadastroFornecedoresController : ControllerBase
    {
        [HttpGet]
        public ActionResult<string> SelectAll()
        {
            return "";
        }
        [HttpGet("{id}")]
        public ActionResult<string> SelectFromId(int id)
        {
            return "";
        }
    }
}
