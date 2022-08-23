using Microsoft.AspNetCore.Mvc;

namespace MajorPrjt.Web.Areas.DForum.Controllers
{
    public class AboutUsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
