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
    public class RegisterController : ApiController
    {
        [HttpGet]
        [ResponseType(typeof(List<M_Activity>))]
        public async Task<IHttpActionResult> Get(string barcodeNo)
        {
            try
            {
                IQueryable<RegisterModel> query = await RegisterModel.Get(barcodeNo);
                return Ok(query.ToList().FirstOrDefault());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [ResponseType(typeof(List<M_Activity>))]
        public async Task<IHttpActionResult> Set(string barcodeNo)
        {
            try
            {
                IQueryable<RegisterModel> query = await RegisterModel.Set(barcodeNo);
                return Ok(query.ToList().FirstOrDefault());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        
    }
}