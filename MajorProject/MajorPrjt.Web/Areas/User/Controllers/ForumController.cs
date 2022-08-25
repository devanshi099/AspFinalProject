﻿using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MajorPrjt.Web.Data;
using MajorPrjt.Web.Areas.User.ViewModels;
using MajorPrjt.Web.Models;

namespace MajorPrjt.Web.Areas.User.Controllers
{
    [Area("User")]
    public class ForumController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ForumController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            // Populate the data for the drop-down select list
            List<Topic> topicDetails = _context.Topics.ToList();
            List<Comment> CommentDetails = _context.Comments.ToList();
            List<Reply> ReplyDetails = _context.Replies.ToList();

            var commonview = from t in topicDetails
                             join c in CommentDetails on t.TopicId equals c.CommentId into table1
                             from c in table1.DefaultIfEmpty()
                             join r in ReplyDetails on c.CommentId equals r.ReplyId into table2
                             from r in table2.DefaultIfEmpty()
                             select new CompleteForumView { Topics = t,Comments = c , Replies = r};
            List<CompleteForumView> x = commonview.ToList();
            return View(x);
        }
    }
}