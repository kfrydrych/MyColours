using CQRS.Core.Commands;
using MyColours.Website.Core.Common;
using MyColours.Website.Core.Repositories;
using MyColours.Website.Persistance.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyColours.Website.Persistance
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }
        public IProductRepository Products => new ProductRepository(_context);

        public ITransactionRepository Transactions => new TransactionRepository(_context);

        public UnitOfWorkResult Complete()
        {
            try
            {
                return _context.SaveChanges() > 0 
                    ? UnitOfWorkResult.Updated 
                    : UnitOfWorkResult.NoChanges;
            }
            catch (Exception ex)
            {
                return UnitOfWorkResult.Error;
            }
            
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}