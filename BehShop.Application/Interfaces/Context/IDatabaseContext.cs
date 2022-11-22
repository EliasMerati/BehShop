using BehShop.Domain.Entities.User;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BehShop.Application.Interfaces.Context
{
    public interface IDatabaseContext
    {
        #region Entities
        #endregion


        int SaveChanges(bool AcceptAllChangeSuccess);
        int SaveChanges();
        Task<int> SaveChangesAsync(bool AcceptAllChangeSuccess, CancellationToken cancellationToken = new CancellationToken());
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken());

    }
}
