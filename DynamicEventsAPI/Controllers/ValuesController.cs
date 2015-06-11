using Dynamic_Event_Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace Dynamic_Events_API.Controllers
{
    /// <summary>
    /// เต้ย สุดหล่อ
    /// </summary>
    [Authorize ]
    public class ValuesController : ApiController
    { 
        // GET api/values
        /// <summary>
        /// Get Zone
        /// </summary>
        /// <returns>Zone Object</returns>
        [HttpGet]
        [ResponseType(typeof(List<T_Zone>))]
        [AllowAnonymous]
        public IHttpActionResult  Get()
        {
            try
            {
                using( DITS_EventEntities e = new DITS_EventEntities())
                {
                    return Ok(e.T_Zone.ToList());
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
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
