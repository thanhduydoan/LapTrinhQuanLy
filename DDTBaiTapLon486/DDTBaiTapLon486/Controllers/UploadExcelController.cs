using DDTBaiTapLon486.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DDTBaiTapLon486.Controllers
{
    public class UploadExcelController : Controller
    {
        private BtlDbContext db = new BtlDbContext();
        ExcelProcess excelPro = new ExcelProcess();
        // GET: UploadExcel
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(HttpPostedFileBase file)
        {
            DataTable dt = CopyDataFromExcelFile(file);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                var ps = new Person();
                ps.PersonId = dt.Rows[i][0].ToString();
                ps.PersonName = dt.Rows[i][1].ToString();
                ps.Address = dt.Rows[i][2].ToString();
                db.Persons.Add(ps);
            }
            db.SaveChanges();
            return RedirectToAction("Index", "Person");
            //OverWriteFastData(dt);
            //return View();
        }

        public DataTable CopyDataFromExcelFile(HttpPostedFileBase file)
        {
            string fileExtention = file.FileName.Substring(file.FileName.IndexOf("."));
            string _FileName = "danhsachperson" + fileExtention;
            string _path = Path.Combine(Server.MapPath("~/Uploads/Excels"), _FileName);
            file.SaveAs(_path);
            DataTable dt = excelPro.ReadDataFromExcelFile(_path, true);
            return dt;
        }
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["BtlDbContext"].ConnectionString);
        private void OverWriteFastData(DataTable dt)
        {
            SqlBulkCopy bulkcopy = new SqlBulkCopy(con);
            bulkcopy.DestinationTableName = "Person";
            bulkcopy.ColumnMappings.Add(0, "PersonId");
            bulkcopy.ColumnMappings.Add(1, "PersonName");
            bulkcopy.ColumnMappings.Add(2, "Address");
            con.Open();
            bulkcopy.WriteToServer(dt);
            con.Close();
        }
    }
}