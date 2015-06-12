using Dynamic_Event_Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Web;

namespace Dynamic_Events_API.Models
{
    public class BarcodeModel
    {
        public string BarcodeNo { get; set; }
        public Nullable<int> EmpId { get; set; }
        public string EmpName { get; set; }
        public Nullable<bool> IsActive { get; set; }

        public static async Task<IQueryable<BarcodeModel>> Get()
        {
            try
            {
                //using (DITS_EventEntities e = new DITS_EventEntities())
                //{

                DITS_EventEntities e = new DITS_EventEntities();
                IQueryable<BarcodeModel> query = (from a in e.M_Barcode
                                                  join b in e.M_Employee on a.EmpId equals b.EmpId into ps
                                                  from b in ps.DefaultIfEmpty()
                                                  select new BarcodeModel
                                               {
                                                   BarcodeNo = a.BarcodeNo,
                                                   EmpId = a.EmpId,
                                                   EmpName = b.EmpName,
                                                   IsActive = a.IsActive
                                               });

                return query;


                //}
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}