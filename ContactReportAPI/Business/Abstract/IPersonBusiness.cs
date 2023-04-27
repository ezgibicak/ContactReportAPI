using Common.Model;
using ContactAPI.Model;
using System.Threading.Tasks;

namespace ContactAPI.Business.Abstract
{
    public interface IPersonBusiness
    {
        Task<ResultModel<PersonModel>> Get();
        Task<ResultModel<PersonModel>> Post(PersonModel personModel);
        Task<ResultModel<PersonModel>> Delete(PersonModel personModel);
        Task<ResultModel<ReportModel>> GetReportData();
    }
}
