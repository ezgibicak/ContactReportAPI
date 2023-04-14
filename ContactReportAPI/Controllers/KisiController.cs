using ContactAPI.Interface;
using ContactAPI.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactAPI.Controllers
{
    [Route("api/Contact")]
    [ApiController]
    public class KisiController : ControllerBase
    {
        private readonly IKisiBusiness kisiBusiness;
        private SonucModel<KisiModel> sonucModel;
        public KisiController(IKisiBusiness _kisiBusiness)
        {
            kisiBusiness = _kisiBusiness;
            sonucModel = new SonucModel<KisiModel>();
        }
        [HttpGet]
        public async Task<ActionResult<SonucModel<KisiModel>>> Get()
        {
            sonucModel = await kisiBusiness.Get();
            return sonucModel;
        }
        [HttpPost]
        public async Task<ActionResult<SonucModel<KisiModel>>> Post([FromBody] KisiModel kisi)
        {
            sonucModel = await kisiBusiness.Post(kisi);
            return sonucModel;
        }
        [HttpDelete]
        public async Task<ActionResult<SonucModel<KisiModel>>> Delete([FromBody] KisiModel kisi)
        {
            sonucModel = await kisiBusiness.Delete(kisi);
            return sonucModel;
        }
    }
}
