using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MajorPrjt.Web.Data;
using MajorPrjt.Web.Models;
using Microsoft.AspNetCore.Authorization;

namespace MajorPrjt.Web.Areas.DForum.Controllers
{
    
    [Area("DForum")]
    public class CategoriesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CategoriesController(ApplicationDbContext context)
        {
            _context = context;
        }

        
        // GET: DForum/Categories
        public async Task<IActionResult> Index()
        {
            return View(await _context.Categories.ToListAsync());
        }

        [Authorize(Roles = "AppAdmin")]
        public async Task<IActionResult> AdminView()
        {
            return View(await _context.Categories.ToListAsync());
        }

        [Authorize(Roles = "AppAdmin")]
        // GET: DForum/Categories/Details/5
        public async Task<IActionResult> Details(short? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = await _context.Categories
                .FirstOrDefaultAsync(m => m.CategoryId == id);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }
        [Authorize]
        // GET: DForum/Categories/Create
        public IActionResult Create()
        {
        
                    return View();
        }
        [Authorize]
        // GET: DForum/Categories/Create
        public IActionResult UserView()
        {
            return View();
        }

        // POST: DForum/Categories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CategoryId,CategoryName")] Category category)
        {
            if (ModelState.IsValid)
            {
                // Duplicate Entry Checking
                bool isFound = _context.Categories.Any(c => c.CategoryName == category.CategoryName);
                if (isFound)
                {
                    ModelState.AddModelError("CategoryName", "Already Existing!!!, Please add another category");
                }
                else
                {
                    _context.Add(category);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(category);
            
        }

        [Authorize(Roles = "AppAdmin")]
        // GET: DForum/Categories/Edit/5
        public async Task<IActionResult> Edit(short? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = await _context.Categories.FindAsync(id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        [Authorize(Roles = "AppAdmin")]
        // POST: DForum/Categories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(short id, [Bind("CategoryId,CategoryName")] Category category)
        {
            if (id != category.CategoryId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                // Duplicate Entry Checking for all the remaining records)
                bool isFound = await _context.Categories
                    .AnyAsync(c => c.CategoryId != category.CategoryId
                                   && c.CategoryName == category.CategoryName);
                if (isFound)
                {
                    ModelState.AddModelError("CategoryName", "Already Existing!!!, Please add another category");
                }
                else
                {
                    try
                    {
                        _context.Update(category);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!CategoryExists(category.CategoryId))
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
            }
            return View(category);
        }

        [Authorize(Roles = "AppAdmin")]
        // GET: DForum/Categories/Delete/5
        public async Task<IActionResult> Delete(short? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = await _context.Categories
                .FirstOrDefaultAsync(m => m.CategoryId == id);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        [Authorize(Roles = "AppAdmin")]
        // POST: DForum/Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(short id)
        {
            var category = await _context.Categories.FindAsync(id);
            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CategoryExists(short id)
        {
            return _context.Categories.Any(e => e.CategoryId == id);
        }
    }
}
