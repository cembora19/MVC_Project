using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace StoreApp.Areas.Admin.controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]

    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            TempData["info"] = $"Welcome back, {DateTime.Now.ToShortDateString()}";
            return View();
        }
    }
}