using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AuthServer.Core.UnitOfWork;
using Microsoft.EntityFrameworkCore;

namespace AuthServer.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext _dbContext;

        public UnitOfWork(AppDbContext appDbContext)
        {
            _dbContext = appDbContext;
        }

        public async Task CommitAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        public void Commit()
        {
            _dbContext.SaveChanges();
        }
    }
}
