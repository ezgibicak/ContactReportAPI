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
            CreateMap<PersonModel, Person>().ReverseMap().ForMember(dest => dest.Contacts, opt => opt.MapFrom(src => src.Contact));
            CreateMap<ContactModel, Contact>().ReverseMap();
        }
    }
}
