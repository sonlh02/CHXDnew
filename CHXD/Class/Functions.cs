
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Security.Cryptography.X509Certificates;
namespace CHXD.Class
{
    class Functions
    {
        public static SqlConnection con;
        public static void Connect()
        {
            con = new SqlConnection();
            con.ConnectionString = Properties.Settings.Default.QLBanHangConnectionString;
            if (con.State != ConnectionState.Open)
            {
                con.Open();
                MessageBox.Show("Ket noi thanh cong!");
            }
            else MessageBox.Show("Ket noi that bai!");
        }
        public static void Disconnect()
        {
            if(con.State== ConnectionState.Open)
            {
                con.Close();
                con.Dispose();
                con = null;
            }
        }
    }
}
