using AutoMapper;
using Common.Model;
using ContactAPI.DataAccess;
using ContactAPI.Entity;
using ContactAPI.Interface;
using ContactAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ContactAPI.Business
{
    public class KisiBusiness : IKisiBusiness
    {
        private readonly IMapper mapper;
        private readonly IContactDataAccess<Kisi> dataAccess;
        private readonly IContactDataAccess<Iletisim> dataAccessIletisim;
        private SonucModel<KisiModel> sonucModel;

        public KisiBusiness(IMapper mapper, IContactDataAccess<Kisi> dataAccess, IContactDataAccess<Iletisim> dataAccessIletisim)
        {
            this.mapper = mapper;
            this.dataAccess = dataAccess;
            this.dataAccessIletisim = dataAccessIletisim;
            sonucModel = new SonucModel<KisiModel>();
        }
        public async Task<SonucModel<KisiModel>> Get()
        {
            try
            {
                var kisiListesi = dataAccess.GetAll();
                foreach (var kisi in kisiListesi.ToList())
                {
                    var kisiIletisim = dataAccessIletisim.Find(x => x.KisiId == kisi.Id).ToList();
                    kisi.Iletisim = kisiIletisim;
                }
                var kisiModelListe = mapper.Map<List<KisiModel>>(kisiListesi.ToList());
                sonucModel.Data = kisiModelListe;
                sonucModel.Mesaj = kisiModelListe.Count > 0 ? "Başarılı" : "Kişi listesi boş";
                return sonucModel;

            }
            catch (Exception ex)
            {
                sonucModel.Mesaj = string.Format("Başarısız:{0}", ex.Message);
            }
            return sonucModel;

        }
        public async Task<SonucModel<KisiModel>> Post(KisiModel kisi)
        {
            try
            {
                var kisiEntity = mapper.Map<Kisi>(kisi);
                bool isSuccessful = dataAccess.Add(kisiEntity);
                IsSuccessful(isSuccessful);

            }
            catch (Exception ex)
            {
                sonucModel.Mesaj = string.Format("Başarısız:{0}", ex.Message);
            }
            return sonucModel;

        }
        public async Task<SonucModel<KisiModel>> Delete(KisiModel kisi)
        {
            try
            {
                var kisiEntity = mapper.Map<Kisi>(kisi);
                bool isSuccessful = dataAccess.Remove(kisiEntity);
                IsSuccessful(isSuccessful);
            }
            catch (Exception ex)
            {
                sonucModel.Mesaj = string.Format("Başarısız:{0}", ex.Message);
            }
            return sonucModel;
        }
        public async Task<SonucModel<ReportModel>> GetReportData()
        {
            SonucModel<ReportModel> reportSonuc = new SonucModel<ReportModel>();
            try
            {
                List<ReportModel> reportModelList = new List<ReportModel>();
                var iletisimResult = dataAccessIletisim.GetAll();
                var liste = iletisimResult.ToList();
                foreach (var item in liste)
                {
                    ReportModel reportModel = new ReportModel();
                    var kayitliTelefonNo = liste.Where(x => x.Latitude == item.Latitude && x.Longitude == item.Longitude).Count();
                    var kayitliKisi = liste.Where(x => x.Latitude == item.Latitude && x.Longitude == item.Longitude).GroupBy(d => new { d.KisiId }, (key, group) => new { Key = key, Count = group.Count() }).Count();
                    reportModel.KayitliTelefonNo = kayitliTelefonNo;
                    reportModel.KayitliKisi = kayitliKisi;
                    reportModel.Latitude = item.Latitude;
                    reportModel.Longitude = item.Longitude;
                    if (!reportModelList.Where(x => x.Longitude == item.Longitude && x.Latitude == item.Latitude).Any())
                    {
                        reportModelList.Add(reportModel);
                    }
                }
                reportSonuc.Data = reportModelList;
                reportSonuc.Mesaj = reportModelList.Count > 0 ? "Başarılı" : "Başarısız";

            }
            catch (Exception ex)
            {
                reportSonuc.Mesaj = string.Format("Başarısız:{0}", ex.Message);
            }
            return reportSonuc;

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
