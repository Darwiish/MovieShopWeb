using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MovieWebAPI.Controllers
{
    [Authorize]
    public class ValuesController : ApiController
    {
        /// <summary>
        /// No Movie
        /// </summary>
        /// <param ></param>
        /// <returns></returns>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        /// <summary>
        /// No Movie
        /// </summary>
        /// <param ></param>
        /// <returns></returns>
        public string Get(int id)
        {
            return "value";
        }

        /// <summary>
        /// No Movie
        /// </summary>
        /// <param ></param>
        /// <returns></returns>
        public void Post([FromBody]string value)
        {
        }

        /// <summary>
        /// No Movie
        /// </summary>
        /// <param ></param>
        /// <returns></returns>
        public void Put(int id, [FromBody]string value)
        {
        }

        /// <summary>
        /// No Movie
        /// </summary>
        /// <param ></param>
        /// <returns></returns>
        public void Delete(int id)
        {
        }
    }
}
