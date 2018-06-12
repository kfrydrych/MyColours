using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyColours.Website.Common.Security
{
    public interface IWebApiAuthenticator
    {
        bool IsClientAuthenticated { get; }

        void Authenticate(string username, string password);
    }
}
