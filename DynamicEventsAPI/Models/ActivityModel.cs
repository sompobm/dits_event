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
        public string BarcodeNo { get; set; }
        public string ActivityNo { get; set; }
        public string ActivityName { get; set; }

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

        public static async Task<IQueryable<ActivityModel>> CheckStatus(string barcodeNo)
        {
            try
            {

                DITS_EventEntities e = new DITS_EventEntities();
                IQueryable<ActivityModel> query = (from a in e.T_Activity
                                                   join b in e.M_Activity on a.ActivityNo equals b.ActivityNo into ps
                                                   from b in ps.DefaultIfEmpty()
                                                   where a.BarcodeNo.Equals(barcodeNo)
                                                   select new ActivityModel
                                                   {
                                                       BarcodeNo = a.BarcodeNo,
                                                       ActivityNo = a.ActivityNo,
                                                       ActivityName = b.ActivityName
                                                   });
                return query;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}