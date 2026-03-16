using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using MvcBudgeting.Models;
using MvcBudgeting.Models.Context;

namespace MvcBudgeting.Controllers
{
    public class ExpenseSheetsController : Controller
    {
        private readonly MvcbudgetingContext _context;

        public ExpenseSheetsController(MvcbudgetingContext context)
        {
            _context = context;
        }

        // GET: ExpenseSheets
        //public async Task<IActionResult> Index()
        //{
        //    return View(await _context.ExpenseSheets.ToListAsync());
        //}
        public IActionResult Index()
        {
            return View(new List<ExpenseSheet>());
        }

        // GET: ExpenseSheets/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var expenseSheet = await _context.ExpenseSheets
                .FirstOrDefaultAsync(m => m.Id == id);
            if (expenseSheet == null)
            {
                return NotFound();
            }

            return View(expenseSheet);
        }

        // GET: ExpenseSheets/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ExpenseSheets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UserId,ExpenseDate,ExpenseCategory,ExpenseSubCategory,ExpenseAmount,ExpenseItem")] ExpenseSheet expenseSheet)
        {
            if (ModelState.IsValid)
            {
                _context.Add(expenseSheet);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(expenseSheet);
        }

        // GET: ExpenseSheets/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var expenseSheet = await _context.ExpenseSheets.FindAsync(id);
            if (expenseSheet == null)
            {
                return NotFound();
            }
            return View(expenseSheet);
        }

        // POST: ExpenseSheets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UserId,ExpenseDate,ExpenseCategory,ExpenseSubCategory,ExpenseAmount,ExpenseItem")] ExpenseSheet expenseSheet)
        {
            if (id != expenseSheet.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(expenseSheet);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExpenseSheetExists(expenseSheet.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(expenseSheet);
        }

        // GET: ExpenseSheets/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var expenseSheet = await _context.ExpenseSheets
                .FirstOrDefaultAsync(m => m.Id == id);
            if (expenseSheet == null)
            {
                return NotFound();
            }

            return View(expenseSheet);
        }

        // POST: ExpenseSheets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var expenseSheet = await _context.ExpenseSheets.FindAsync(id);
            if (expenseSheet != null)
            {
                _context.ExpenseSheets.Remove(expenseSheet);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ExpenseSheetExists(int id)
        {
            return _context.ExpenseSheets.Any(e => e.Id == id);
        }

        public IActionResult DisplayNewExpense()
        {
            return PartialView("/Views/ExpenseSheets/_Expense.cshtml", new ExpenseSheet());
        }

        public IActionResult TestPartial()
        {
            return PartialView("/Views/ExpenseSheets/_Test.cshtml");
        }
    }
}
