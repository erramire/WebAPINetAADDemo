using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.IdentityModel.Clients.ActiveDirectory;

namespace BackEndApiDemo.Controllers
{
    public class AuthController : ApiController
    {
        

        // GET api/auth/GetToken
        
        public async Task<string> GetToken()
        {

            AuthenticationContext authContext = new AuthenticationContext("https://login.microsoftonline.com/" + ConfigurationManager.AppSettings["ida:Tenant"], true);
            ClientCredential credential = new ClientCredential(ConfigurationManager.AppSettings["ida:ClientID"], ConfigurationManager.AppSettings["ida:Password"]);

            AuthenticationResult result = await authContext.AcquireTokenAsync(ConfigurationManager.AppSettings["ida:ClientID"], credential);
            return result.AccessToken;

        }
    }
}
