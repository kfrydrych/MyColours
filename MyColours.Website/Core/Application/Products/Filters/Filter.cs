using MyColours.Website.Core.Common;
using MyColours.Website.Core.ViewModels.Products;

namespace MyColours.Website.Core.Application.Products.Filters
{
    public abstract class Filter<TResult>
    {
        public abstract TResult FilterFromSource(IUnitOfWork unitOfWork);
    }
}