using System.Threading.Tasks;
using System;
using AutoMapper;
using ReportAPI.DataAccess;
using ReportAPI.Entity;
using System.Linq;
using System.Collections.Generic;
using Helper.RabitMQHelper;
using Common.Model;
using ContactReportAPI.Helper;
using Newtonsoft.Json;
using ReportAPI.Business.Abstract;

namespace ReportAPI.Business.Concrete
{
    public class ReportBusiness : IReportBusiness
    {
        private readonly IMapper mapper;
        private readonly IReportDataAccess<Report> dataAccess;
        private readonly ResultModel<ReportModel> resultModel = new ResultModel<ReportModel>();
        private readonly IRabitMQProducer rabitMQProducer;


        public ReportBusiness(IMapper mapper, IReportDataAccess<Report> dataAccess, IRabitMQProducer rabitMQProducer)
        {
            this.mapper = mapper;
            this.dataAccess = dataAccess;
            this.rabitMQProducer = rabitMQProducer;
        }
        public async Task<ResultModel<ReportModel>> Post()
        {
            try
            {
                ReportModel reportModel = new ReportModel();
                reportModel.CreatedDate = DateTime.Now;
                reportModel.State = 0;//Hazır
                reportModel.Id = Guid.NewGuid();
                reportModel.Path = @"C:\Users\ezgi.bicak\" + reportModel.Id + ".xlsx";
                var report = mapper.Map<Report>(reportModel);
                bool isSuccessful = dataAccess.Add(report);
                var data = await RestHelper.GetRequestAsync("http://localhost:5000/api/Person/GetReport");
                string responseBody = await data.Content.ReadAsStringAsync();
                var sonuc = JsonConvert.DeserializeObject<ResultModel<ReportModel>>(responseBody);
                foreach (var item in sonuc.DataList)
                {
                    item.Id = reportModel.Id;
                    item.CreatedDate = reportModel.CreatedDate;
                    item.State = 0;
                    item.Path = reportModel.Path;
                }
                rabitMQProducer.SendData(sonuc);

                IsSuccessful(isSuccessful);

            }
            catch (Exception ex)
            {
                resultModel.Message = string.Format("Başarısız:{0}", ex.Message);
            }
            return resultModel;

        }
        public async Task<ResultModel<ReportModel>> Get()
        {
            try
            {
                var reportResult = dataAccess.GetAll();
                var reportList = mapper.Map<List<ReportModel>>(reportResult.ToList());
                resultModel.Message = reportList.Count > 0 ? "Başarılı" : "Kişi listesi boş";
                resultModel.DataList = reportList;
            }
            catch (Exception ex)
            {
                resultModel.Message = string.Format("Başarısız:{0}", ex.Message);
            }
            return resultModel;

        }
        public async Task<ResultModel<ReportModel>> Update(List<Guid> liste)
        {
            try
            {
                foreach (var item in liste)
                {
                    var result = dataAccess.GetByGuidId(item);
                    result.State = 1;
                    var reportResult = dataAccess.Update(result);
                    IsSuccessful(reportResult);
                }
                resultModel.Data = null;
            }
            catch (Exception ex)
            {
                resultModel.Message = string.Format("Başarısız:{0}", ex.Message);
            }
            return resultModel;

        }
        private void IsSuccessful(bool isSuccessful)
        {
            if (isSuccessful)
            {
                resultModel.Message = "Başarılı";
            }
            else
            {
                resultModel.Message = "Başarısız";
            }
        }
    }
}
