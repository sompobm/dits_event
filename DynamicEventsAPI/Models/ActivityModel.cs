using Dynamic_Event_Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Web;

namespace Dynamic_Events_API.Models
{
    public class ActivityModel
    {
        public static async Task<IQueryable<M_Activity>> Get()
        {
            try
            {
                DITS_EventEntities e = new DITS_EventEntities();
                e.Configuration.LazyLoadingEnabled = false;
                IQueryable<M_Activity> query = e.M_Activity.AsQueryable();
                return query;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}