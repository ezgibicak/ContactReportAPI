using Common.Model;
using ContactAPI.Business.Abstract;
using ContactAPI.Model;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ContactAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonBusiness personBusiness;
        private ResultModel<PersonModel> resultModel;
        public PersonController(IPersonBusiness _personBusiness)
        {
            personBusiness = _personBusiness;
            resultModel = new ResultModel<PersonModel>();
        }
        [HttpGet]
        public async Task<ActionResult<ResultModel<PersonModel>>> Get()
        {
            resultModel = await personBusiness.Get();
            return resultModel;
        }
        [HttpPost]
        public async Task<ActionResult<ResultModel<PersonModel>>> Post([FromBody] PersonModel personModel)
        {
            resultModel = await personBusiness.Post(personModel);
            return resultModel;
        }
        [HttpDelete]
        public async Task<ActionResult<ResultModel<PersonModel>>> Delete([FromBody] PersonModel personModel)
        {
            resultModel = await personBusiness.Delete(personModel);
            return resultModel;
        }
        [HttpGet("GetReport")]
        public async Task<ActionResult<ResultModel<ReportModel>>> GetReport()
        {
            var personList = await personBusiness.GetReportData();
            return personList;
        }
    }
}
