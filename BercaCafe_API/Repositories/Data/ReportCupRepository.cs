using APIDapper.Models;
using BercaCafe_API.Models;
using BercaCafe_API.Repositories.Interfaces;
using BercaCafe_API.ViewModels;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;

namespace BercaCafe_API.Repositories.Data
{
    public class ReportCupRepository : IReportCupRepository
    {
        public IConfiguration _configuration;  

        public ReportCupRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        DynamicParameters parameters = new DynamicParameters();

        public IEnumerable<ReportByCupVM> Get(DateTime fromDate, DateTime thruDate)
        {
            using (SqlConnection connection = new SqlConnection(_configuration["ConnectionStrings:BercaCafe"]))
            {
                var spName = "spReportSummaryCupNew";
                parameters.Add("@fromDate", fromDate);
                parameters.Add("@thruDate", thruDate);
                var cup = connection.Query<ReportByCupVM>(spName, parameters, commandType: CommandType.StoredProcedure);
                return cup;

            }
        }
    }
}
