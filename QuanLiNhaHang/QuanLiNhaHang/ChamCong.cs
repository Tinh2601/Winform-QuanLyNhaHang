using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiNhaHang
{
    internal class ChamCong
    {
        MY_DB mydb = new MY_DB();


        
        public bool kiemtra(DateTime datetime)
        {

            SqlCommand command = new SqlCommand("select * from ChamCong where msnv=" + Login_Form.NhanVienID+" and dateWork='"+datetime.ToString("yyyy-MM-dd")+ "' and timeCheckOut is NULL", mydb.getConnection);
            command.Parameters.Add("@datetime", SqlDbType.DateTime).Value = datetime;
            mydb.openConnection();
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = command;
            DataTable table = new DataTable();
            adapter.Fill(table);
            if ((table.Rows.Count > 0))
            {
                mydb.closeConnection();
                return false;
            }
            else
            {
                mydb.closeConnection();
                return true;
            }
        }
        public bool checkIn(DateTime datetime)
        {

            SqlCommand command = new SqlCommand("insert into ChamCong (msnv,dateWork,timeCheckIn) values (" + Login_Form.NhanVienID + ",'"+ datetime.ToString("yyyy-MM-dd") + "',@datetime) ", mydb.getConnection);
            command.Parameters.Add("@datetime", SqlDbType.DateTime).Value = datetime;
            mydb.openConnection();
            if ((command.ExecuteNonQuery() == 1))
            {
                mydb.closeConnection();
                return true;
            }
            else
            {
                mydb.closeConnection();
                return false;
            }
        }


        public bool checkOut(DateTime datetime)
        {
            
            SqlCommand command = new SqlCommand("UPDATE ChamCong SET timeCheckOut =@datetime  WHERE msnv=" + Login_Form.NhanVienID + "and timeCheckOut is null ", mydb.getConnection);
            command.Parameters.Add("@datetime", SqlDbType.DateTime).Value = datetime;
            mydb.openConnection();
            if ((command.ExecuteNonQuery() == 1))
            {
                mydb.closeConnection();
                return true;
            }
            else
            {
                mydb.closeConnection();
                return false;
            }
        }

    }
}
