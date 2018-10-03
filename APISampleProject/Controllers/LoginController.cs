using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace APISampleProject.Controllers
{

    public class LoginController : ApiController
    {
        public bool Login(string username, string password)
        {
            string apiUsername = Convert.ToString(ConfigurationManager.AppSettings["ApiUsername"]);
            string apiPassword = Convert.ToString(ConfigurationManager.AppSettings["ApiPassword"]);

            if (apiUsername == username.ToLower() && apiPassword == password)
            {
                return true;
            }
            else
            return false;
        }
    }
}
