﻿using System;
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
    public class RepliesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RepliesController(ApplicationDbContext context)
        {
            _context = context;
        }

        
        // GET: DForum/Replies
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Replies.Include(r => r.Comment);
            return View(await applicationDbContext.ToListAsync());
        }

        [Authorize(Roles = "AppAdmin")]
        public async Task<IActionResult> AdminView()
        {
            var applicationDbContext = _context.Replies.Include(r => r.Comment);
            return View(await applicationDbContext.ToListAsync());
        }
        //public async Task<IActionResult> Index(string SearchString)
        //{
        //    ViewData["CurrentFilter"] = SearchString;
        //    var replies = from r in _context.Replies
        //                  select r;
        //    if (!String.IsNullOrEmpty(SearchString))
        //    {
        //        replies = replies.Where(r => r.ReplyDescription.Contains(SearchString));
        //    }
        //    return View(replies);
        //}

        [Authorize(Roles = "AppAdmin")]
        // GET: DForum/Replies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reply = await _context.Replies
                .Include(r => r.Comment)
                .FirstOrDefaultAsync(m => m.ReplyId == id);
            if (reply == null)
            {
                return NotFound();
            }

            return View(reply);
        }

        [Authorize]
        // GET: DForum/Replies/Create
        public IActionResult Create()
        {
            ViewData["CommentId"] = new SelectList(_context.Comments, "CommentId", "CommentDescription","RepliedBy");
            return View();
        }
        [Authorize]
        public IActionResult UserView()
        {
            return View();
        }

        // POST: DForum/Replies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ReplyId,ReplyDescription,ReplyDateTime,CommentId", "RepliedBy")] Reply reply)
        {
            if (ModelState.IsValid)
            {
                _context.Add(reply);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CommentId"] = new SelectList(_context.Comments, "CommentId", "CommentDescription", reply.CommentId, "RepliedBy");
            return View(reply);
        }

        [Authorize(Roles = "AppAdmin")]
        // GET: DForum/Replies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reply = await _context.Replies.FindAsync(id);
            if (reply == null)
            {
                return NotFound();
            }
            ViewData["CommentId"] = new SelectList(_context.Comments, "CommentId", "CommentDescription", reply.CommentId, "RepliedBy");
            return View(reply);
        }

        [Authorize(Roles = "AppAdmin")]
        // POST: DForum/Replies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ReplyId,ReplyDescription,ReplyDateTime,CommentId,RepliedBy")] Reply reply)
        {
            if (id != reply.ReplyId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reply);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReplyExists(reply.ReplyId))
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
            ViewData["CommentId"] = new SelectList(_context.Comments, "CommentId", "CommentDescription", reply.CommentId, "RepliedBy");
            return View(reply);
        }

        [Authorize(Roles = "AppAdmin")]
        // GET: DForum/Replies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reply = await _context.Replies
                .Include(r => r.Comment)
                .FirstOrDefaultAsync(m => m.ReplyId == id);
            if (reply == null)
            {
                return NotFound();
            }

            return View(reply);
        }

        [Authorize(Roles = "AppAdmin")]
        // POST: DForum/Replies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var reply = await _context.Replies.FindAsync(id);
            _context.Replies.Remove(reply);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReplyExists(int id)
        {
            return _context.Replies.Any(e => e.ReplyId == id);
        }
    }
}
