using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using SharedWeekends.MVC.Model.Enities;

namespace SharedWeekends.MVC.Model
{
    public interface IWeekendsDbContext
    {
        DbSet<Weekend> Weekends { get; set; }

        DbSet<Category> Categories { get; set; }

        DbSet<Like> Likes { get; set; }

        DbSet<User> Users { get; set; }

        int SaveChanges();

        DbSet<TEntity> Set<TEntity>() where TEntity : class;

        EntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
    }
}
