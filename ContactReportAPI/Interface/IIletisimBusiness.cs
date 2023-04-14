using ContactAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactAPI.Interface
{
    public interface IIletisimBusiness
    {
        Task<SonucModel<İletisimModel>> Post(İletisimModel iletisim);
        Task<SonucModel<İletisimModel>> Delete(İletisimModel iletisim);
    }
}
