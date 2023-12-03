using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SharedWeekends.MVC.Model.Enities;

namespace SharedWeekends.MVC.Model
{
    public class WeekendsDbContext : IdentityDbContext<User>, IWeekendsDbContext
    {
        public WeekendsDbContext(DbContextOptions<WeekendsDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Weekend> Weekends { get; set; }

        public virtual DbSet<Category> Categories { get; set; }

        public virtual DbSet<Like> Likes { get; set; }
    }
}
