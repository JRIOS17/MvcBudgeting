using Microsoft.AspNetCore.Mvc;

namespace MvcBudgeting.Controllers
{
    public class ExpenseSheetController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
