using Aastha.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;
using Aastha.Data.IRepository;

namespace Aastha.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IDashBoardRepository _repository;

        public HomeController(ILogger<HomeController> logger, IDashBoardRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

         public ActionResult ExpenseSummary()
        {
            return PartialView("_feeReport");
        }

        public JsonResult GetAnnualFee()
        {
            return new JsonResult(_repository.CalculateMonthlyExpense());
        }

        // public JsonResult GetWeeklyExpense()
        // {
        //     Dictionary<string, decimal> weeklyExpense = expenseService.CalculateWeeklyExpense();
        //     return new JsonResult(weeklyExpense);
        // }
    }
}
