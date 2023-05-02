using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Common.Model;
using ReportAPI.Business.Abstract;

namespace ReportAPI.Controllers
{
    [Route("api/Report")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly IReportBusiness reportBusiness;
        private ResultModel<ReportModel> resultModel;
        public ReportController(IReportBusiness _reportBusiness)
        {
            reportBusiness = _reportBusiness;
            resultModel = new ResultModel<ReportModel>();
        }
        [HttpPost]
        public async Task<ActionResult<ResultModel<ReportModel>>> Post()
        {

            await reportBusiness.Post();
            resultModel.Message = "Başarılı";

            return resultModel;
        }

        [HttpGet]
        public async Task<ActionResult<ResultModel<ReportModel>>> Get()
        {
            resultModel = await reportBusiness.Get();
            return resultModel;
        }
        [HttpPost("Update")]
        public async Task<ActionResult<ResultModel<ReportModel>>> Update()
        {
            using var streamReader = new StreamReader(Request.Body, Encoding.UTF8);
            var requestBody = await streamReader.ReadToEndAsync();
            List<Guid> idList = JsonConvert.DeserializeObject<List<Guid>>(requestBody);
            resultModel = await reportBusiness.Update(idList);
            return resultModel;
        }
    }
}
