using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CHXD.Class
{
    internal class Functions
    {
        public static SqlConnection con;
        public static void Connect()
        {
            con = new SqlConnection();
            con.ConnectionString = Properties.Settings.Default.CHXDConnectionString;
            if (con.State != ConnectionState.Open)
            {
                con.Open();
                MessageBox.Show("Ket noi thanh cong!");
            }
            else MessageBox.Show("Ket noi that bai!");
        }
        public static void Disconnect()
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
                con.Dispose();
                con = null;
            }
        }
        //Lấy dữ liệu vào bảng
        public static DataTable GetDataToTable(string sql)
        {
            SqlDataAdapter dap = new SqlDataAdapter(sql, con); //Định nghĩa đối tượng thuộc lớp SqlDataAdapter
            //Tạo đối tượng thuộc lớp SqlCommand
            dap.SelectCommand = new SqlCommand();
            dap.SelectCommand.Connection = Functions.con; //Kết nối cơ sở dữ liệu
            dap.SelectCommand.CommandText = sql; //Lệnh SQL
            //Khai báo đối tượng table thuộc lớp DataTable
            DataTable table = new DataTable();
            dap.Fill(table);
            return table;
        }
        //Hàm kiểm tra khoá trùng
        public static bool CheckKey(string sql)
        {
            SqlDataAdapter dap = new SqlDataAdapter(sql, con);
            DataTable table = new DataTable();
            dap.Fill(table);
            if (table.Rows.Count > 0)
                return true;
            else return false;
        }
        //Hàm thực hiện câu lệnh SQL
        public static void RunSQL(string sql)
        {
            SqlCommand cmd; //Đối tượng thuộc lớp SqlCommand
            cmd = new SqlCommand();
            cmd.Connection = con; //Gán kết nối
            cmd.CommandText = sql; //Gán lệnh SQL
            try
            {
                cmd.ExecuteNonQuery(); //Thực hiện câu lệnh SQL
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            cmd.Dispose();//Giải phóng bộ nhớ
            cmd = null;
        }
    }
}
