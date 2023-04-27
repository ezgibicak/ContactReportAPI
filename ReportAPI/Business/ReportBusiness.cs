using System.Threading.Tasks;
using System;
using AutoMapper;
using ReportAPI.Model;
using ReportAPI.DataAccess;
using ReportAPI.Entity;
using ReportAPI.Interface;
using System.Linq;
using System.Collections.Generic;
using Helper.RabitMQHelper;
using Common.Model;
using ContactReportAPI.Helper;
using Newtonsoft.Json;

namespace ReportAPI.Business
{
    public class ReportBusiness : IReportBusiness
    {
        private readonly IMapper mapper;
        private readonly IReportDataAccess<Report> dataAccess;
        private readonly SonucModel<ReportModel> sonucModel = new SonucModel<ReportModel>();
        private readonly IRabitMQProducer rabitMQProducer;


        public ReportBusiness(IMapper mapper, IReportDataAccess<Report> dataAccess, IRabitMQProducer rabitMQProducer)
        {
            this.mapper = mapper;
            this.dataAccess = dataAccess;
            this.rabitMQProducer = rabitMQProducer;
        }
        public async Task<SonucModel<ReportModel>> Post()
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
                var data = await RestHelper.GetRequestAsync("http://localhost:5000/api/Contact/GetReport");
                string responseBody = await data.Content.ReadAsStringAsync();
                var sonuc = JsonConvert.DeserializeObject<SonucModel<ReportModel>>(responseBody);
                foreach (var item in sonuc.Data)
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
                sonucModel.Mesaj = string.Format("Başarısız:{0}", ex.Message);
            }
            return sonucModel;

        }
        public async Task<SonucModel<ReportModel>> Get()
        {
            try
            {
                var reportResult = dataAccess.GetAll();
                var reportList = mapper.Map<List<ReportModel>>(reportResult.ToList());
                sonucModel.Mesaj = reportList.Count > 0 ? "Başarılı" : "Kişi listesi boş";
                sonucModel.Data = reportList;
            }
            catch (Exception ex)
            {
                sonucModel.Mesaj = string.Format("Başarısız:{0}", ex.Message);
            }
            return sonucModel;

        }
        public async Task<SonucModel<ReportModel>> Update(List<Guid> liste)
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
                sonucModel.Data = null;
            }
            catch (Exception ex)
            {
                sonucModel.Mesaj = string.Format("Başarısız:{0}", ex.Message);
            }
            return sonucModel;

        }
        private void IsSuccessful(bool isSuccessful)
        {
            if (isSuccessful)
            {
                sonucModel.Mesaj = "Başarılı";
            }
            else
            {
                sonucModel.Mesaj = "Başarısız";
            }
        }
    }
}
