using Dynamic_Event_Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Web;

namespace Dynamic_Events_API.Models
{
    public class EmployeeModel
    {


        public int EmpId { get; set; }
        public string EmpCardNo { get; set; }
        public string CompanyNo { get; set; }
        public string EmpName { get; set; }
        public string CompanyName { get; set; }
        public Nullable<bool> IsActive { get; set; }


        public static async Task<IQueryable<EmployeeModel>> Get()
        {
            try
            {
                DITS_EventEntities e = new DITS_EventEntities();
                IQueryable<EmployeeModel> query = (from a in e.M_Employee
                                                   join b in e.M_Company on a.CompanyNo equals b.CompanyNo into ps
                                                   from b in ps.DefaultIfEmpty()
                                                   select new EmployeeModel
                                               {
                                                   EmpId = a.EmpId,
                                                   EmpCardNo = a.EmpCardNo,
                                                   EmpName = a.EmpName,
                                                   CompanyNo = a.CompanyNo,
                                                   CompanyName = b.CompanyName,
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