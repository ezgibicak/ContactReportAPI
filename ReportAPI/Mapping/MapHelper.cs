using AutoMapper;
using Common.Model;
using ReportAPI.Entity;

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
