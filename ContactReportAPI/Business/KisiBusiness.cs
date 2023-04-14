using AutoMapper;
using ContactAPI.DataAccess;
using ContactAPI.Entity;
using ContactAPI.Interface;
using ContactAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactAPI.Business
{
    public class KisiBusiness : IKisiBusiness
    {
        private readonly IMapper mapper;
        private readonly IContactDataAccess<Kisi> dataAccess;
        private readonly IContactDataAccess<Iletisim> dataAccessIletisim;
        private readonly IContactDataAccess<KisiIletisim> dataAccesskisiIletisim;
        private SonucModel<KisiModel> sonucModel;

        public KisiBusiness(IMapper mapper, IContactDataAccess<Kisi> dataAccess, IContactDataAccess<Iletisim> dataAccessIletisim, IContactDataAccess<KisiIletisim> dataAccesskisiIletisim)
        {
            this.mapper = mapper;
            this.dataAccess = dataAccess;
            this.dataAccessIletisim = dataAccessIletisim;
            this.dataAccesskisiIletisim = dataAccesskisiIletisim;
            sonucModel = new SonucModel<KisiModel>();
        }
        public async Task<SonucModel<KisiModel>> Get()
        {
            try
            {
                var kisiListesi = dataAccess.GetAll();
                foreach (var kisi in kisiListesi)
                {
                    var kisiIletisim = dataAccesskisiIletisim.Find(x => x.KisiId == kisi.Id).ToList();
                    foreach (var iletisim in kisiIletisim)
                    {
                        kisi.Iletisim = dataAccessIletisim.Find(x => x.Id == iletisim.İletisimId).ToList();
                    }
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
