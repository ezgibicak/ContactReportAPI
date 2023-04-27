using Common.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReportAPI.Business.Abstract
{
    public interface IReportBusiness
    {
        Task<ResultModel<ReportModel>> Get();
        Task<ResultModel<ReportModel>> Post();
        Task<ResultModel<ReportModel>> Update(List<Guid> list);
    }
}
