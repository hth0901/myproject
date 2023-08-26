using Microsoft.AspNetCore.Mvc;

namespace OpenDataSite.Areas.AdminTool.Controllers
{
    [Area("AdminTool")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult TableDemo()
        {
            return View();
        }
    }
}
