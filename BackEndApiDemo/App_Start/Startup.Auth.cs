using System;
using System.Collections.Generic;
using System.Configuration;
using System.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.ActiveDirectory;
using Owin;

namespace BackEndApiDemo
{
    public partial class Startup
    {
        // For more information on configuring authentication, please visit https://go.microsoft.com/fwlink/?LinkId=301864
        public void ConfigureAuth(IAppBuilder app)
        {

            //app.UseJwtBearerAuthentication(

            //    new Microsoft.Owin.Security.Jwt.JwtBearerAuthenticationOptions {
            //    //AllowedAudiences= new string[] { ConfigurationManager.AppSettings["ida:Audience"] },
            //    TokenHandler = Tokenhandler(),
            //    TokenValidationParameters = new TokenValidationParameters
            //    {
            //        ValidAudience = ConfigurationManager.AppSettings["ida:Audience"],
            //        ValidIssuer= "https://sts.windows.net/52dd3814-4288-429d-8815-15feec88f8de/"



            //    }

            //});

            app.UseWindowsAzureActiveDirectoryBearerAuthentication(
                new WindowsAzureActiveDirectoryBearerAuthenticationOptions
                {

                    Tenant = ConfigurationManager.AppSettings["ida:Tenant"],
                    TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidAudience = ConfigurationManager.AppSettings["ida:Audience"]
                    }
                });
        }

        private JwtSecurityTokenHandler Tokenhandler()
        {
            return new JwtSecurityTokenHandler();
        }
        //private Task AuthenticationFailed(AuthenticationFailedContext arg)
        //{
        //    // For debugging purposes only!
        //    var s = $"AuthenticationFailed: {arg.Exception.Message}";
        //    arg.Response.ContentLength = s.Length;
        //    arg.Response.Body.Write(Encoding.UTF8.GetBytes(s), 0, s.Length);
        //    return Task.FromResult(0);
        //}
        //private int funcione()
        //{
        //    throw new NotImplementedException();
        //}
    }
}
