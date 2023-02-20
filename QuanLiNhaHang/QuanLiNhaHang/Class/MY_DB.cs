using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace QuanLiNhaHang
{
    internal class MY_DB
    {
        // cấu trúc kết nối dến csdl
        // tạo kết nối voi SQL 
        SqlConnection con = new SqlConnection(@"Data Source=(localdb)\ProjectModels;Initial Catalog=QLNH;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

        // get the connection : láy kết nối 
        public SqlConnection getConnection
        {
            get
            {
                return con;
            }
        }
        // open the connection : mo ket noi 
        public void openConnection()
        {
            if ((con.State == ConnectionState.Closed))// con,state để cho biết trạng thái 
            {
                con.Open();
            }
        }

        // close the connection: đóng kết nối (đóng lại để giải phóng tài nguyên )
        public void closeConnection()
        {
            if ((con.State == ConnectionState.Open))
            {
                con.Close();
            }
        }
    }
}
