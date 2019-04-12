using BackEndApiDemo.Business;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Configuration;
using System.Web.Http;

namespace BackEndApiDemo.Controllers
{
    [Authorize]
    
    public class ValuesController : ApiController
    {
        // GET api/values
        public IEnumerable<string> Get()
        {
            string stringConnection = String.Empty;
            if (ConfigurationManager.AppSettings["Mode"]== "Development")
            {
                stringConnection = ConfigurationManager.AppSettings["SQLConnectionString"].ToString();
            }
            else
            {
                stringConnection= WebConfigurationManager.ConnectionStrings["MyDbConnection"].ConnectionString;
            }
            
            ValueBusiness valBus = new ValueBusiness(stringConnection);
            string[] results = valBus.GetAllValues();
            //return new string[] { "value1", "value2" };
            return results;
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
