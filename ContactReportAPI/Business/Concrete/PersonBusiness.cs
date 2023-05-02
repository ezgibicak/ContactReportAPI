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
using System.Xml.Linq;

namespace ContactAPI.Business.Concrete
{
    public class PersonBusiness : IPersonBusiness
    {
        private readonly IMapper mapper;
        private readonly IContactDataAccess<Person> dataAccess;
        private readonly IContactDataAccess<Contact> dataAccessIletisim;
        private ResultModel<PersonModel> resultModel;

        public PersonBusiness(IMapper mapper, IContactDataAccess<Person> dataAccess, IContactDataAccess<Contact> dataAccessIletisim)
        {
            this.mapper = mapper;
            this.dataAccess = dataAccess;
            this.dataAccessIletisim = dataAccessIletisim;
            resultModel = new ResultModel<PersonModel>();
        }
        public async Task<ResultModel<PersonModel>> Get()
        {
            try
            {
                var personList = dataAccess.GetAll();
                foreach (var person in personList.ToList())
                {
                    var personOfContact = dataAccessIletisim.Find(x => x.PersonId == person.Id).ToList();
                    person.Contact = personOfContact;
                }
                var personModelList = mapper.Map<List<PersonModel>>(personList.ToList());

                resultModel.DataList = personModelList;
                resultModel.Message = personModelList.Count > 0 ? "Başarılı" : "Kişi listesi boş";

            }
            catch (Exception ex)
            {
                resultModel.Message = string.Format("Başarısız:{0}", ex.Message);
            }
            return resultModel;

        }
        public async Task<ResultModel<PersonModel>> Post(PersonModel personModel)
        {
            try
            {
                var personEntity = mapper.Map<Person>(personModel);
                var contacts = mapper.Map<List<Contact>>(personModel.Contacts);
                bool isSuccessful = dataAccess.Add(personEntity);
                personEntity.Contact = contacts;
                dataAccessIletisim.AddRange(contacts);
                IsSuccessful(isSuccessful);
            }
            catch (Exception ex)
            {
                resultModel.Message = string.Format("Başarısız:{0}", ex.Message);
            }
            return resultModel;

        }
        public async Task<ResultModel<PersonModel>> Delete(PersonModel personModel)
        {
            try
            {
                var personEntity = mapper.Map<Person>(personModel);
                bool isSuccessful = dataAccess.Remove(personEntity);
                IsSuccessful(isSuccessful);
            }
            catch (Exception ex)
            {
                resultModel.Message = string.Format("Başarısız:{0}", ex.Message);
            }
            return resultModel;
        }
        public async Task<ResultModel<ReportModel>> GetReportData()
        {
            ResultModel<ReportModel> reportSonuc = new ResultModel<ReportModel>();
            try
            {
                List<ReportModel> reportModelList = new List<ReportModel>();
                var contactResult = dataAccessIletisim.GetAll();
                var list = contactResult.ToList();
                foreach (var item in list)
                {
                    ReportModel reportModel = new ReportModel();
                    var savedPhoneNumber = list.Where(x => x.Latitude == item.Latitude && x.Longitude == item.Longitude).Count();
                    var personNumber = list.Where(x => x.Latitude == item.Latitude && x.Longitude == item.Longitude).GroupBy(d => new { d.PersonId }, (key, group) => new { Key = key, Count = group.Count() }).Count();
                    reportModel.SavedPhoneNumber = savedPhoneNumber;
                    reportModel.SavedPerson = personNumber;
                    reportModel.Latitude = item.Latitude;
                    reportModel.Longitude = item.Longitude;
                    if (!reportModelList.Where(x => x.Longitude == item.Longitude && x.Latitude == item.Latitude).Any())
                    {
                        reportModelList.Add(reportModel);
                    }
                }
                reportSonuc.DataList = reportModelList;
                reportSonuc.Message = reportModelList.Count > 0 ? "Başarılı" : "Başarısız";

            }
            catch (Exception ex)
            {
                reportSonuc.Message = string.Format("Başarısız:{0}", ex.Message);
            }
            return reportSonuc;

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
