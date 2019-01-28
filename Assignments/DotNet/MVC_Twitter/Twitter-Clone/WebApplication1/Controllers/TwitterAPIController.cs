using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace TwitterClone_MVC_WebAPI.Controllers
{
    public class TwitterAPIController : ApiController
    {
        // GET: api/TwitterAPI
        
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/TwitterAPI/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/TwitterAPI
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/TwitterAPI/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/TwitterAPI/5
        public void Delete(int id)
        {
        }
    }
}
