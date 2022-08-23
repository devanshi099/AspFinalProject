using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MajorPrjt.Web.Data;
using MajorPrjt.Web.Areas.User.ViewModels;

namespace MajorPrjt.Web.Areas.User.Controllers
{
    [Area("User")]
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            // Populate the data for the drop-down select list
            List<SelectListItem> categories = new List<SelectListItem>();
            categories.Add(new SelectListItem { Selected = true, Value = "", Text = "-- select a category --" });
            categories.AddRange(new SelectList(_context.Categories, "CategoryId", "CategoryName"));
            ViewData["CategoryId"] = categories.ToArray();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index([Bind("CategoryId")] UserForumViewModel model)
        {
            // Retrieve the Menu Items for the selected category
            var items = _context.Topics.Where(m => m.CategoryId == model.CategoryId);

            // Populate the data into the viewmodel object
            model.Topics = items.ToList();

            // Populate the data for the drop-down select list
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryName");

            // Display the View
            return View("Index", model);
        }



        public IActionResult CustomerView()
        {

            return RedirectToAction("Index");
        }
    }
}
