using MyColours.Website.Core.Domain.Products;
using MyColours.Website.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace MyColours.Website.Persistance.Repositories
{
    public class TransactionRepository : Repository<Transaction>, ITransactionRepository
    {
        public TransactionRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public ApplicationDbContext MyColoursDbContext => Context as ApplicationDbContext;

        public override Transaction Get(int id)
        {
            return MyColoursDbContext.Transactions
                .Include(x => x.TransactionType)
                .SingleOrDefault(x => x.Id == id);

        }

        public override IEnumerable<Transaction> GetAll()
        {
            return MyColoursDbContext.Transactions
                .Include(x => x.TransactionType)
                .AsEnumerable();
        }

        public Transaction GetTransactionWithProducts(int id)
        {
            return MyColoursDbContext.Transactions
                .Include(t => t.TransactionType)
                .Include(l => l.Products.Select(p => p.Product).Select(m => m.Manufacturer))
                .Include(l => l.Products.Select(p => p.Product).Select(m => m.ProductType))
                .SingleOrDefault(x => x.Id == id);
        }
    }
}
