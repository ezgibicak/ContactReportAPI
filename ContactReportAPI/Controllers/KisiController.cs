using ContactAPI.Interface;
using ContactAPI.Model;
using ContactReportAPI.Helper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

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
        //[HttpPost("CreateReport")]
        //public async Task CreateReport()
        //{
        //    var kisiList = await kisiBusiness.GetReportData();
        //    var json = JsonConvert.SerializeObject(kisiList.Data);
        //    await RestHelper.PostRequestAsync("http://localhost:5001/api/Report", json);


        //}
        //[HttpGet("GetReport")]
        //public async Task GetReport()
        //{
        //    await RestHelper.GetRequestAsync("http://localhost:5001/api/Report");
        //}
    }
}
