using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace MyColours.Website.Common.Security
{
    public class WebConfigAuthenticator : IWebApiAuthenticator
    {
        private readonly string _userName;
        private readonly string _password;

        public WebConfigAuthenticator()
        {
            _userName = ConfigurationManager.AppSettings["API_Login"];
            _password = ConfigurationManager.AppSettings["API_Password"];
        }

        public bool IsClientAuthenticated { get; private set; }

        public void Authenticate(string username, string password)
        {
           IsClientAuthenticated = (username == _userName) && (password == _password);
        }
    }
}