using AutoMapper;
using Common.Model;
using ContactAPI.Business.Abstract;
using ContactAPI.DataAccess;
using ContactAPI.Entity;
using ContactAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactAPI.Business.Concrete
{
    public class ContactBusiness : IContactBusiness
    {
        private readonly IMapper mapper;
        private readonly IContactDataAccess<Contact> dataAccess;
        private readonly ResultModel<ContactModel> resultModel = new ResultModel<ContactModel>();

        public ContactBusiness(IMapper mapper, IContactDataAccess<Contact> dataAccess)
        {
            this.mapper = mapper;
            this.dataAccess = dataAccess;
        }
        public async Task<ResultModel<ContactModel>> Post(ContactModel contactModel)
        {

            try
            {
                var contactEntity = mapper.Map<Contact>(contactModel);
                bool isSuccessful = dataAccess.Add(contactEntity);
                IsSuccessful(isSuccessful);

            }
            catch (Exception ex)
            {
                resultModel.Mesaj = string.Format("Başarısız:{0}", ex.Message);
            }
            return resultModel;

        }
        public async Task<ResultModel<ContactModel>> Delete(ContactModel contactModel)
        {
            try
            {
                var contactEntity = mapper.Map<Contact>(contactModel);
                bool isSuccessful = dataAccess.Remove(contactEntity);
                IsSuccessful(isSuccessful);
            }
            catch (Exception ex)
            {
                resultModel.Mesaj = string.Format("Başarısız:{0}", ex.Message);
            }
            return resultModel;
        }
        private void IsSuccessful(bool isSuccessful)
        {
            if (isSuccessful)
            {
                resultModel.Mesaj = "Başarılı";
            }
            else
            {
                resultModel.Mesaj = "Başarısız";
            }
        }
    }
}
