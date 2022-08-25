using MajorPrjt.Web.Models;
using System.Collections.Generic;

namespace MajorPrjt.Web.Areas.User.ViewModels
{
    public class CompleteForumView
    {
        public Topic Topics { get; set; }
        public Comment Comments { get; set; }
        public Reply Replies { get; set; }
    }
}
