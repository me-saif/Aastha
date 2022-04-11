using Aastha.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace Aastha.Controllers
{
    public class StudentReportController : Controller
    {
        private IReportService _reportService;

        public StudentReportController(IReportService reportService)
        {
            _reportService = reportService;
        }

        //[HttpGet("{reportName}/{reportType}/{lang}")]
        //https://localhost:44325/StudentReport/GetReport/UserDetails/xls/en
        [Route("StudentReport/GetReport/{reportName}/{reportType}/{lang}")]
        public IActionResult GetReport(string reportName, string reportType, string lang)
        {
            var reportNameWithLang = reportName + "_" + lang;
            var reportFileByteString = _reportService.GenerateReportAsync(reportNameWithLang, reportType);
            return File(reportFileByteString, MediaTypeNames.Application.Octet, getReportName(reportNameWithLang, reportType));
        }

        private string getReportName(string reportName, string reportType)
        {
            var outputFileName = reportName + ".pdf";

            switch (reportType.ToUpper())
            {
                default:
                case "PDF":
                    outputFileName = reportName + ".pdf";
                    break;

                case "XLS":
                    outputFileName = reportName + ".xls";
                    break;

                case "WORD":
                    outputFileName = reportName + ".doc";
                    break;
            }

            return outputFileName;
        }
    }
}