using CQRS.Core.Commands;
using MyColours.Website.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyColours.Website.Core.Common
{
    public interface IUnitOfWork : IDisposable
    {
        IProductRepository Products { get; }
        ITransactionRepository Transactions { get; }
        UnitOfWorkResult Complete();
    }
}