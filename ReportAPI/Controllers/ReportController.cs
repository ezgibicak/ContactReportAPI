using ContactAPI.Model;
using Microsoft.AspNetCore.Mvc;
using ReportAPI.Model;
using System.Threading.Tasks;

namespace ReportAPI.Controllers
{
    [Route("api/Report")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        [HttpGet("GetReport")]
        public async Task<ActionResult<bool>> GetReport()
        {
            return true;
        }
    }
}
