using System;
using System.Data;
using System.Data.SqlClient;

namespace QuanLiNhaHang
{
    internal class BILL
    {
        MY_DB mydb = new MY_DB();
        public bool insertBill( int idTable, string status)
        {
            SqlCommand command = new SqlCommand("INSERT INTO Bill (idTable,status)" +
                 " VALUES(@idTable, @status)", mydb.getConnection);

            command.Parameters.Add("@idTable", SqlDbType.Int).Value = idTable;
            command.Parameters.Add("@status", SqlDbType.VarChar).Value = status;

            mydb.openConnection();
            // Ex de tra ve so dong bi tac dong: insert, update, delete
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
        public bool updateCount(int id, float count)
        {
            SqlCommand command = new SqlCommand("UPDATE Bill SET CountBill=@count WHERE idTable=@id", mydb.getConnection);

            command.Parameters.Add("@id", SqlDbType.Int).Value = id;
            command.Parameters.Add("@count", SqlDbType.Float).Value = count;

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
        public bool insertBillInfo(int idBill, int idFood)
        {
            SqlCommand command = new SqlCommand("INSERT INTO BillInfo (idBill,idFood)" +
                 " VALUES(@idBill, @idFood)", mydb.getConnection);

            command.Parameters.Add("@idBill", SqlDbType.Int).Value = idBill;
            command.Parameters.Add("@idFood", SqlDbType.Int).Value = idFood;

            mydb.openConnection();
            // Ex de tra ve so dong bi tac dong: insert, update, delete
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

        public bool updateBill(DateTime DateCheckOut, int idTable, string status,float count)
        {
            SqlCommand command = new SqlCommand("UPDATE Bill SET DateCheckOut=@DateCheckOut,status=@status,CountBill=@count WHERE status='Chua thanh toán' and idTable=@idTable", mydb.getConnection);

            command.Parameters.Add("@idTable", SqlDbType.Int).Value = idTable;
            command.Parameters.Add("@DateCheckOut", SqlDbType.DateTime).Value = DateCheckOut;
            command.Parameters.Add("@status", SqlDbType.VarChar).Value = status;
            command.Parameters.Add("@count", SqlDbType.Float).Value = count;


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
        public DataTable getTable(SqlCommand command)
        {
            command.Connection = mydb.getConnection;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }


        public bool deleteBill(int id)
        {
            SqlCommand command = new SqlCommand("DELETE FROM Bill WHERE id = @id", mydb.getConnection);

            command.Parameters.Add("@id", SqlDbType.Int).Value = id;
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
        public DataTable getHoaDon(SqlCommand command)
        {
            command.Connection = mydb.getConnection;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }
    }
}
