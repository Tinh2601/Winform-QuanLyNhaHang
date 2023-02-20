using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiNhaHang
{
    internal class FOOD
    {
        MY_DB mydb = new MY_DB();
        public bool insertFood(string foodname,float price)
        {
            SqlCommand command = new SqlCommand("INSERT INTO Food (name,price)" +
                 " VALUES(@name, @price)", mydb.getConnection);
            command.Parameters.Add("@name", SqlDbType.NVarChar).Value = foodname;
            command.Parameters.Add("@price", SqlDbType.Float).Value = price;
            
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
        public bool foodExits(string name)
        {
            SqlCommand command = new SqlCommand("SELECT * FROM Food WHERE name=@name ", mydb.getConnection);
          
            command.Parameters.Add("@username", SqlDbType.NVarChar).Value = name;
            SqlDataAdapter adapter = new SqlDataAdapter(command);

            DataTable table = new DataTable();
            adapter.Fill(table);

            if ((table.Rows.Count == 0))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public bool updateFood(string foodname,float price)
        {
            SqlCommand command = new SqlCommand("UPDATE Food SET price = @price  WHERE name=@name", mydb.getConnection);

            command.Parameters.Add("@name", SqlDbType.NVarChar).Value = foodname;
            command.Parameters.Add("@price", SqlDbType.Float).Value = price;
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
        public DataTable getEmployee(SqlCommand command)
        {
            command.Connection = mydb.getConnection;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }

        public DataTable getAllCourse()
        {
            SqlCommand command = new SqlCommand("select * from Food", mydb.getConnection);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }

        public bool deleteEmployee(string name)
        {
            SqlCommand command = new SqlCommand("DELETE FROM Food WHERE name=@name", mydb.getConnection);

            command.Parameters.Add("@name", SqlDbType.NVarChar).Value = name;
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
