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
    public class BarcodeController : ApiController
    {
        [HttpGet]
        [ResponseType(typeof(List<BarcodeModel>))]
        public async Task<IHttpActionResult> Get(int page, int start, int limit, string sort)
        {
            try
            {
                IQueryable<BarcodeModel> query = await BarcodeModel.Get();
                var result = ExtNetGridHelper.ToGrid<BarcodeModel>(query, page, start, limit, sort);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
