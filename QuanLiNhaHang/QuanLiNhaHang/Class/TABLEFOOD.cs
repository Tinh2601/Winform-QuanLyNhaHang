using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiNhaHang
{
    internal class TABLEFOOD
    {
        MY_DB mydb = new MY_DB();
        public bool insertTable(string name, string status)
        {
            SqlCommand command = new SqlCommand("INSERT INTO TableFood (name,status)" +
                 " VALUES(@name, @status)", mydb.getConnection);
            
            command.Parameters.Add("@name", SqlDbType.VarChar).Value = name;
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
        public bool updateTable(int id, string name, string status)
        {
            SqlCommand command = new SqlCommand("UPDATE TableFood SET name=@name,status=@status WHERE id=@id", mydb.getConnection);

            command.Parameters.Add("@name", SqlDbType.VarChar).Value = name;
            command.Parameters.Add("@status", SqlDbType.VarChar).Value = status;

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

        public bool changeStatus(int id, string status)
        {
            SqlCommand command = new SqlCommand("UPDATE TableFood SET status=@status WHERE id=@id", mydb.getConnection);

            command.Parameters.Add("@status", SqlDbType.VarChar).Value = status;
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

        public DataTable getTable(SqlCommand command)
        {
            command.Connection = mydb.getConnection;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }
        public bool deleteTable(int id)
        {
            SqlCommand command = new SqlCommand("DELETE FROM TableFood WHERE id = @id", mydb.getConnection);

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
    }
}
