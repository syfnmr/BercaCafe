using BercaCafe_API.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Net;

namespace BercaCafe_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportCupsController : ControllerBase
    {
        private readonly IReportCupRepository reportCupRepository;

        public ReportCupsController(IReportCupRepository reportCupRepository)
        {
            this.reportCupRepository = reportCupRepository;
        }

        [HttpGet]
        public ActionResult Get(DateTime fromDate, DateTime thruDate) { 
            var rCup = reportCupRepository.Get(fromDate, thruDate);

            if (rCup.Count() != 0)
            {
                return StatusCode(200, new { StatusCode = HttpStatusCode.OK, message = "Data Ditemukan", result = rCup });
            }
            else { 
                
                return StatusCode(404, new { StatusCode = HttpStatusCode.NotFound, message = "Data Tidak Ditemukan", result = rCup });
            }
        }
    }
}
