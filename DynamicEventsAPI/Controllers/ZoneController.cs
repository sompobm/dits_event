using Dynamic_Event_Data;
using Dynamic_Events_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

using Dynamic_Events_API.Commons;

using System.Threading.Tasks;

namespace Dynamic_Events_API.Controllers
{

    public class ZoneController : ApiController
    {
        // GET api/values
        /// <summary>
        /// Get Zone
        /// </summary>
        /// <returns>List of Zone Object</returns>
        [HttpGet]
        [ResponseType(typeof(List<ZoneModel>))]
        public async Task<IHttpActionResult> Get(int page, int start, int limit,string sort)
        {
            try
            {
                IQueryable<ZoneModel> query = await  ZoneModel.Get();
                var result = ExtNetGridHelper.ToGrid<ZoneModel>(query, page, start, limit, sort);
                  
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/values/zoneNo
        /// <summary>
        /// Get Zone by ZoneNo
        /// </summary>
        /// <param name="zoneNo"></param>
        /// <param name="companyNo"></param>
        /// <returns>Zone Object</returns>
        [HttpGet]
        [ResponseType(typeof(T_Zone))]
        public async Task<IHttpActionResult> Get(string zoneNo, string companyNo)
        {
            try
            {
                return Ok(await ZoneModel.Get(zoneNo, companyNo));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        public void Post([FromBody]string value)
        {
        }

        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
