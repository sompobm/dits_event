using Dynamic_Event_Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Web;



namespace Dynamic_Events_API.Models
{

    public class ZoneModel
    {

        public string ZoneNo { get; set; }
        public string ZoneName { get; set; }
        public string CompanyNo { get; set; }
        public string CompanyName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static async Task<IQueryable<ZoneModel>> Get()
        {
            try
            {
                //using (DITS_EventEntities e = new DITS_EventEntities())
                //{

                DITS_EventEntities e = new DITS_EventEntities();
                IQueryable<ZoneModel> query = (from a in e.T_Zone
                                               join b in e.M_Company on a.CompanyNo equals b.CompanyNo into ps
                                               from b in ps.DefaultIfEmpty()
                                               select new ZoneModel
                                               {
                                                   ZoneNo = a.ZoneNo,
                                                   ZoneName = a.ZoneName,
                                                   CompanyNo = a.CompanyNo,
                                                   CompanyName = b.CompanyName
                                               });

                return query;


                //}
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static async Task<T_Zone> Get(string zoneNo, string companyNo)
        {
            try
            {
                using (DITS_EventEntities e = new DITS_EventEntities())
                {
                    var result = e.T_Zone.Where(x => x.ZoneNo == zoneNo && x.CompanyNo == companyNo).FirstOrDefault();
                    return result;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }


}