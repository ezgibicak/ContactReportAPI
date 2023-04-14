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
    public class IletisimBusiness:IIletisimBusiness
    {
        private readonly IMapper mapper;
        private readonly IContactDataAccess<Iletisim> dataAccess;
        private readonly SonucModel<İletisimModel> sonucModel = new SonucModel<İletisimModel>();

        public IletisimBusiness(IMapper mapper, IContactDataAccess<Iletisim> dataAccess)
        {
            this.mapper = mapper;
            this.dataAccess = dataAccess;
        }
        public async Task<SonucModel<İletisimModel>> Post(İletisimModel iletisimModel)
        {

            try
            {
                var iletisimEntity = mapper.Map<Iletisim>(iletisimModel);
                bool isSuccessful = dataAccess.Add(iletisimEntity);
                IsSuccessful(isSuccessful);

            }
            catch (Exception ex)
            {
                sonucModel.Mesaj = string.Format("Başarısız:{0}", ex.Message);
            }
            return sonucModel;

        }
        public async Task<SonucModel<İletisimModel>> Delete(İletisimModel iletisimModel)
        {
            try
            {
                var iletisimEntity = mapper.Map<Iletisim>(iletisimModel);
                bool isSuccessful = dataAccess.Remove(iletisimEntity);
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
