using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Web;

namespace DDTBaiTapLon486.Models
{
    public class ExcelProcess
    {

        public DataTable ReadDataFromExcelFile(string filepath, bool removeRow0)
        {
            string connectionString = "";
            string fileExtension = filepath.Substring(filepath.Length - 4).ToLower();
            if (fileExtension.IndexOf("xlsx") < 0)
            {
                connectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + filepath + ";Extend Properties=Excel 8.0";
            }
            else
            {
                connectionString = "Provider = Microsoft.ACE.OLEDB.12.0; Data Source=" + filepath + ";Extend Properties=\"Excel 12.0 Xml;HDR=NO\"";
            }
            // Tạo đối tượng kết nối
            OleDbConnection oledbConn = new OleDbConnection(connectionString);
            DataTable data = null;
            //try
            {
                // Mở kết nối
                oledbConn.Open();

                // Tạo đối tượng OleDBCommand và query data từ sheet có tên "Sheet1"
                OleDbCommand cmd = new OleDbCommand("SELECT * FROM [Sheet1$]", oledbConn);

                // Tạo đối tượng OleDbDataAdapter để thực thi việc query lấy dữ liệu từ tập tin excel
                OleDbDataAdapter oleda = new OleDbDataAdapter();

                oleda.SelectCommand = cmd;

                // Tạo đối tượng DataSet để hứng dữ liệu từ tập tin excel
                DataSet ds = new DataSet();

                // Đổ đữ liệu từ tập excel vào DataSet
                oleda.Fill(ds);

                data = ds.Tables[0];
                if (removeRow0 == true)
                {
                    data.Rows.RemoveAt(0);
                }
            }
            //catch
            //{
            //}
            //finally
            //{
            //    // Đóng chuỗi kết nối
            //    oledbConn.Close();
            //}
            return data;
        }
    }
}
