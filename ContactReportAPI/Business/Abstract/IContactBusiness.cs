using Common.Model;
using ContactAPI.Model;
using System.Threading.Tasks;

namespace ContactAPI.Business.Abstract
{
    public interface IContactBusiness
    {
        Task<ResultModel<ContactModel>> Post(ContactModel contactModel);
        Task<ResultModel<ContactModel>> Delete(ContactModel contactModel);
    }
}
