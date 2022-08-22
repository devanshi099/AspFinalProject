
using Microsoft.EntityFrameworkCore;
using MajorPrjt.Web.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace MajorPrjt.Web.Data
{

    public class ApplicationDbContext : IdentityDbContext
    //public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        { }
        public DbSet<Topic> Topics { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Reply> Replies { get; set; }

        


    }

}
