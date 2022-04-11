using System;
using System.Collections.Generic;
using System.Linq;
using Aastha.Data.IRepository;
using Aastha.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Aastha.Data.Repository
{
    public class DashBoardRepository : IDashBoardRepository
    {
        private readonly AasthaContext _context;

        public DashBoardRepository(AasthaContext context)
        {
            _context = context;
        }
        public Dictionary<string, decimal> CalculateMonthlyExpense()
        {
            List<FeeCollection> lstCollection = new List<FeeCollection>();

            Dictionary<string, decimal> dictAnnuallySum = new Dictionary<string, decimal>();

            decimal feesum = _context.FeeCollection_Master.Where
                (fc => fc.Transaction_Date > DateTime.Now.AddYears(-1))
                .Select(fc => fc.Paid_Amount)
                .Sum();

            decimal collection = _context.FeeCollection_Master
            .Where(td => td.Transaction_Date > DateTime.Now.AddMonths(-3)
             && td.Transaction_Date < DateTime.Now.AddMonths(3))
            .Select(pa=>pa.Paid_Amount)
            .Sum();

            //var feesum = _context.FeeCollection_Master.FromSqlRaw("SELECT * FROM vw_CurrentAnnualReport");

            dictAnnuallySum.Add("Fee", feesum);
            dictAnnuallySum.Add("collection", collection);

            return dictAnnuallySum;
        }

        public void CurrentAnnualReport(){
            var feesum = _context.FeeCollection_Master.FromSqlRaw("SELECT * FROM vw_CurrentAnnualReport");
        }

        public Dictionary<string, decimal> CalculateWeeklyExpense()
        {
            throw new System.NotImplementedException();
        }
    }
}