using ContactAPI.Interface;
using ContactAPI.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class IletisimController : ControllerBase
    {
        private readonly IIletisimBusiness iletisimBusiness;
        private SonucModel<İletisimModel> sonucModel;

        public IletisimController(IIletisimBusiness iletisimBusiness)
        {
            this.iletisimBusiness = iletisimBusiness;
        }
        [HttpPost]
        public async Task<ActionResult<SonucModel<İletisimModel>>> Post([FromBody] İletisimModel iletisimModel)
        {
            sonucModel = await iletisimBusiness.Post(iletisimModel);

            return sonucModel;
        }
        [HttpDelete]
        public async Task<ActionResult<SonucModel<İletisimModel>>> Delete([FromBody] İletisimModel iletisimModel)
        {
            sonucModel = await iletisimBusiness.Delete(iletisimModel);
            return sonucModel;
        }
    }
}
