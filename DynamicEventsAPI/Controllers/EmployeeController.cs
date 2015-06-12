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
    public class EmployeeController : ApiController
    {

        [HttpGet]
        [ResponseType(typeof(List<EmployeeModel>))]
        public async Task<IHttpActionResult> Get(int page, int start, int limit, string sort)
        {
            try
            {
                IQueryable<EmployeeModel> query = await EmployeeModel.Get();
                var result = ExtNetGridHelper.ToGrid<EmployeeModel>(query, page, start, limit, sort);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
