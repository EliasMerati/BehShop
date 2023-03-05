using BehShop.Domain.Catalogs;
using Microsoft.EntityFrameworkCore;

namespace BehShop.Application.Interfaces.Context
{
    public interface IDatabaseContext
    {
        #region Entities
        DbSet<CatalogBrand> catalogBrands { get; set; }
        DbSet<CatalogType> catalogTypes { get; set; }
        #endregion


        int SaveChanges(bool AcceptAllChangeSuccess);
        int SaveChanges();
        Task<int> SaveChangesAsync(bool AcceptAllChangeSuccess, CancellationToken cancellationToken = new CancellationToken());
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken());

    }
}
