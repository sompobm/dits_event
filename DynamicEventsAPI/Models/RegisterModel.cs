using Dynamic_Event_Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Web;

namespace Dynamic_Events_API.Models
{
    public class RegisterModel
    {
        public string BarcodeNo { get; set; }
        public string EmpName { get; set; }
        public string CompanyName { get; set; }
        public Nullable<bool> IsStatus { get; set; }

        public static async Task<IQueryable<RegisterModel>> Get(string barcodeNo)
        {
            try
            {
                DITS_EventEntities e = new DITS_EventEntities();
                //IQueryable<RegisterModel> query = (from barcode in e.M_Barcode
                //                                   join activity in e.T_Activity
                //                                   on barcode.BarcodeNo equals activity.BarcodeNo into psActivity
                //                                   from activity in psActivity.DefaultIfEmpty()
                //                                   join employee in e.M_Employee on barcode.EmpId equals employee.EmpId into ps
                //                                   from employee in ps.DefaultIfEmpty()
                //                                   join company in e.M_Company on employee.CompanyNo equals company.CompanyNo into ps2
                //                                   from company in ps2.DefaultIfEmpty()
                //                                   where barcode.BarcodeNo.Equals(barcodeNo) && activity.ActivityNo.Equals("A01")
                //                                   select new RegisterModel
                //                                   {
                //                                       BarcodeNo = barcode.BarcodeNo,
                //                                       EmpName = employee.EmpName,
                //                                       CompanyName = company.CompanyName,
                //                                       IsStatus = activity.ActivityDateTime == null ? false : true
                //                                   });

                IQueryable<RegisterModel> query = e.Database.SqlQuery<RegisterModel>("SELECT M_Barcode.BarcodeNo, T_Activity.ActivityDateTime, " +
                                                    " M_Employee.EmpName, M_Company.CompanyNo, " +
                                                    " (case when T_Activity.ActivityDateTime is null then CAST(0 as bit) else  CAST(1 as bit) end ) as IsStatus " +
                                                    " FROM M_Barcode LEFT OUTER JOIN " +
                                                    " T_Activity ON M_Barcode.BarcodeNo = T_Activity.BarcodeNo  " +
                                                    " AND T_Activity.ActivityNo = N'A01' LEFT OUTER JOIN" +
                                                    " M_Employee ON M_Barcode.EmpId = M_Employee.EmpId LEFT OUTER JOIN" +
                                                    " M_Company ON M_Employee.CompanyNo = M_Company.CompanyNo " +
                                                    " WHERE M_Barcode.BarcodeNo ='" + barcodeNo + "'").AsQueryable();
                return query;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static async Task<IQueryable<RegisterModel>> Set(string barcodeNo)
        {
            try
            {
                DITS_EventEntities e = new DITS_EventEntities();
                T_Activity obj = e.T_Activity.Where(x => x.BarcodeNo == barcodeNo && x.ActivityNo == "A01").FirstOrDefault();
                obj.ActivityDateTime = DateTime.Now;
                e.SaveChanges();

                IQueryable<RegisterModel> query = e.Database.SqlQuery<RegisterModel>("SELECT M_Barcode.BarcodeNo, T_Activity.ActivityDateTime, " +
                                                     " M_Employee.EmpName, M_Company.CompanyNo, " +
                                                     " (case when T_Activity.ActivityDateTime is null then CAST(0 as bit) else  CAST(1 as bit) end ) as IsStatus " +
                                                     " FROM M_Barcode LEFT OUTER JOIN " +
                                                     " T_Activity ON M_Barcode.BarcodeNo = T_Activity.BarcodeNo  " +
                                                     " AND T_Activity.ActivityNo = N'A01' LEFT OUTER JOIN" +
                                                     " M_Employee ON M_Barcode.EmpId = M_Employee.EmpId LEFT OUTER JOIN" +
                                                     " M_Company ON M_Employee.CompanyNo = M_Company.CompanyNo " +
                                                     " WHERE M_Barcode.BarcodeNo ='" + barcodeNo + "'").AsQueryable();
                return query;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}