using APIDapper.Models;
using BercaCafe_API.Models;
using BercaCafe_API.ViewModels;
using System;
using System.Collections.Generic;

namespace BercaCafe_API.Repositories.Interfaces
{
    public interface IReportCupRepository
    {
        IEnumerable<ReportByCupVM> Get(DateTime fromDate, DateTime thruDate);

    }
}
