using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RabbitMQ.Client.Events;
using RabbitMQ.Client;
using ReportAPI.Interface;
using ReportAPI.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ReportAPI.Controllers
{
    [Route("api/Report")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly IReportBusiness reportBusiness;
        private SonucModel<ReportModel> sonucModel;
        public ReportController(IReportBusiness _reportBusiness)
        {
            reportBusiness = _reportBusiness;
            sonucModel = new SonucModel<ReportModel>();
        }
        [HttpPost]
        public async Task<ActionResult<SonucModel<ReportModel>>> Post()
        {
          
            await reportBusiness.Post();
            sonucModel.Mesaj = "Başarılı";

            return sonucModel;
        }

        [HttpGet]
        public async Task<ActionResult<SonucModel<ReportModel>>> Get()
        {
            sonucModel = await reportBusiness.Get();
            return sonucModel;
        }
    }
}
