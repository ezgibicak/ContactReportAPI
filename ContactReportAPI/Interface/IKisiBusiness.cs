using ContactAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactAPI.Interface
{
    public interface IKisiBusiness
    {
        Task<SonucModel<KisiModel>> Get();
        Task<SonucModel<KisiModel>> Post(KisiModel kisi);
        Task<SonucModel<KisiModel>> Delete(KisiModel kisi);
    }
}
