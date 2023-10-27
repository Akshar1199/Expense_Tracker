using Expense_Tracker_System.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Options;
using Microsoft.EntityFrameworkCore;

namespace Expense_Tracker_System.Controllers
{
    [Authorize]
    public class DashboardController : Controller
    {
        private readonly ApplicationDbContext _context;
        public DashboardController(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<ActionResult> Index(string option)
        {
           
            DateTime StartDate, EndDate;

            if (option == "monthly")
            {
                // Last 1 Month Transactions
                
                StartDate = DateTime.Today.AddMonths(-1);
                EndDate = DateTime.Today;
            }
            else if (option == "weekly")
            {
                // Last 1 Week Transactions
                
                StartDate = DateTime.Today.AddDays(-7);
                EndDate = DateTime.Today;
            }
            else
            {
                // Handle other cases or provide a default date range
                // For example, if option is not provided or invalid, use the default date range for a month:
                StartDate = DateTime.Today.AddMonths(-1);
                EndDate = DateTime.Today;
            }


            List<Transaction> SelectedTransactions = await _context.Transactions
               .Include(x => x.Category)
               .Where(y => y.Date >= StartDate && y.Date <= EndDate)
               .ToListAsync();


            // Total Income
            int TotalIncome = SelectedTransactions
                .Where(i => i.Category.Type == "Income")
                .Sum(j => j.Amount);

            ViewBag.TotalIncome = TotalIncome.ToString("#,##0.00");
            ViewBag.Income = TotalIncome;

            


            // Total Expense
            int TotalExpense = SelectedTransactions
                .Where(i => i.Category.Type == "Expense")
                .Sum(j => j.Amount);

            ViewBag.Expense = TotalExpense;

            ViewBag.TotalExpense= TotalExpense.ToString("#,##0.00");


            // Balance Amount ( Total Income - Total Expense )
            int Balance = TotalIncome - TotalExpense;

            ViewBag.Balance = Balance.ToString("#,##0.00");

            ViewBag.Balnce = Balance;

            

            DateTime RecentStartDate = DateTime.Today.AddDays(-5);
            DateTime RecentEndDate = DateTime.Today;

            List<Transaction> RecentTransactions = await _context.Transactions
               .Include(x => x.Category)
               .Where(y => y.Date >= RecentStartDate && y.Date <= RecentEndDate)
               .ToListAsync();

            ViewBag.RecentTransactions = RecentTransactions;

            return View(SelectedTransactions);
        }
    }
}

