using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ContactAPI.Entity;
using ContactAPI.Model;

namespace ContactAPI.Mapping
{
    public class MapHelper:Profile
    {
        public MapHelper()
        {
            CreateMap<KisiModel, Kisi>().ReverseMap();
            CreateMap<İletisimModel, Iletisim>().ReverseMap();
        }
    }
}
