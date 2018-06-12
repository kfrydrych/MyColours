using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Core.Factories
{
    public interface IViewFactory
    {
        TView CreateView<TView>();
        TView CreateView<TInput, TView>(TInput input);
    }
}
