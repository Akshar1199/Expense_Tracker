using Expense_Tracker_System.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
        public async Task<ActionResult> Index()
        {
            // Last 1 Month Transactions
            DateTime StartDate = DateTime.Today.AddDays(-28);
            DateTime EndDate = DateTime.Today;

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

            return View(SelectedTransactions);


        }
    }
}

