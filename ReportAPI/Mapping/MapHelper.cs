using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Common.Model;
using ReportAPI.Entity;
using ReportAPI.Model;

namespace ReportAPI.Mapping
{
    public class MapHelper:Profile
    {
        public MapHelper()
        {
            CreateMap<ReportModel, Report>().ReverseMap();
        }
    }
}
