using MyColours.Website.Core.Common;
using MyColours.Website.Core.Domain.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyColours.Website.Core.Repositories
{
    public interface ITransactionRepository : IRepository<Transaction>
    {
        Transaction GetTransactionWithProducts(int id);
    }
}
