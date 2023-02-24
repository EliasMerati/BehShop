using BehShop.Application.Interfaces.Context;
using BehShop.Common.Convertor;
using BehShop.Domain.Attributes;
using Microsoft.EntityFrameworkCore;

namespace BehShop.Persistance.Contexts
{

    public class DatabaseContext : DbContext, IDatabaseContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) 
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var entitytype in modelBuilder.Model.GetEntityTypes())
            {
                if (entitytype.ClrType.GetCustomAttributes(typeof(AuditableAttribute), true).Length > 0)
                {
                    modelBuilder.Entity(entitytype.Name).Property<DateTime>("InsertTime");
                    modelBuilder.Entity(entitytype.Name).Property<DateTime?>("UpdateTime");
                    modelBuilder.Entity(entitytype.Name).Property<DateTime?>("RemoveTime");
                    modelBuilder.Entity(entitytype.Name).Property<bool>("IsRemoved");
                }
            }

            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            var modifiedEntries = ChangeTracker.Entries()
                .Where(p => p.State is EntityState.Added or
                EntityState.Modified or
                EntityState.Deleted);
            foreach (var item in modifiedEntries)
            {
                var entityType = item.Context.Model.FindEntityType(item.Entity.GetType());
                var inserted = entityType.FindProperty("InsertTime");
                var updated = entityType.FindProperty("UpdateTime");
                var removed = entityType.FindProperty("RemoveTime");
                var isremoved = entityType.FindProperty("IsRemoved");
                if (item.State is EntityState.Added && inserted != null)
                {
                    item.Property("InsertTime").CurrentValue = DateTime.Now.Date();
                }
                if (item.State is EntityState.Modified && updated != null)
                {
                    item.Property("UpdateTime").CurrentValue = DateTime.Now.Date();
                }
                if (item.State is EntityState.Deleted && removed != null && isremoved != null)
                {
                    item.Property("RemoveTime").CurrentValue = DateTime.Now.Date();
                    item.Property("IsRemoved").CurrentValue = true;
                }
            }

            return base.SaveChanges();
        }
    }
}
