using Dynamic_Event_Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Web;



namespace Dynamic_Events_API.Models
{
    public class CompanyModel
    {
        public static async Task<IQueryable<M_Company>> Get()
        {
            try
            {
                DITS_EventEntities e = new DITS_EventEntities();
                IQueryable<M_Company> query = e.M_Company.AsQueryable();
                return query;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}