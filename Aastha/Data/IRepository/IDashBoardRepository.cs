using System.Collections.Generic;

namespace Aastha.Data.IRepository
{
    public interface IDashBoardRepository
    {
        Dictionary<string, decimal> CalculateMonthlyExpense();
        Dictionary<string, decimal> CalculateWeeklyExpense();
        void CurrentAnnualReport();
    }
}