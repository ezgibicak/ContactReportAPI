using System.Threading.Tasks;
using System;
using AutoMapper;
using ReportAPI.Model;
using ReportAPI.DataAccess;
using ReportAPI.Entity;
using ReportAPI.Interface;
using System.Linq;
using System.Collections.Generic;

namespace ReportAPI.Business
{
    public class ReportBusiness : IReportBusiness
    {
        private readonly IMapper mapper;
        private readonly IReportDataAccess<Report> dataAccess;
        private readonly SonucModel<ReportModel> sonucModel = new SonucModel<ReportModel>();

        public ReportBusiness(IMapper mapper, IReportDataAccess<Report> dataAccess)
        {
            this.mapper = mapper;
            this.dataAccess = dataAccess;
        }
        public async Task<SonucModel<ReportModel>> Post(List<ReportModel> reportModel)
        {

            try
            {
                var reportList = mapper.Map<List<Report>>(reportModel);
                foreach (var report in reportList)
                {
                    bool isSuccessful = dataAccess.Add(report);
                    IsSuccessful(isSuccessful);
                }

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
