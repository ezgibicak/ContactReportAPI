using Common.Model;
using ContactAPI.Business.Abstract;
using ContactAPI.Model;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ContactAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContactController : ControllerBase
    {
        private readonly IContactBusiness contactBusiness;
        private ResultModel<ContactModel> resultModel;

        public ContactController(IContactBusiness contactBusiness)
        {
            this.contactBusiness = contactBusiness;
        }
        [HttpPost]
        public async Task<ActionResult<ResultModel<ContactModel>>> Post([FromBody] ContactModel contactModel)
        {
            resultModel = await contactBusiness.Post(contactModel);

            return resultModel;
        }
        [HttpDelete]
        public async Task<ActionResult<ResultModel<ContactModel>>> Delete([FromBody] ContactModel contactModel)
        {
            resultModel = await contactBusiness.Delete(contactModel);
            return resultModel;
        }
    }
}
