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
    public class ActivityController : ApiController
    {
        [HttpGet]
        [ResponseType(typeof(List<M_Activity>))]
        public async Task<IHttpActionResult> Get(int page, int start, int limit, string sort)
        {
            try
            {
                IQueryable<M_Activity> query = await ActivityModel.Get();
                var result = ExtNetGridHelper.ToGrid<M_Activity>(query, page, start, limit, sort);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [ResponseType(typeof(List<ActivityModel>))]
        public async Task<IHttpActionResult> CheckStatus(string barcodeNo)
        {
            try
            {
                IQueryable<ActivityModel> query = await ActivityModel.CheckStatus(barcodeNo);
                return Ok(query.ToList());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
