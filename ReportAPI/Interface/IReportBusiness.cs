using Common.Model;
using Microsoft.AspNetCore.Mvc;
using ReportAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReportAPI.Interface
{
    public interface IReportBusiness
    {
        Task<SonucModel<ReportModel>> Get();
        Task<SonucModel<ReportModel>> Post();
        Task<SonucModel<ReportModel>> Update(List<Guid> liste);
    }
}
