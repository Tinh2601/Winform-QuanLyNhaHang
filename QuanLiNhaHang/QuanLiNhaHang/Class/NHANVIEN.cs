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
    internal class NHANVIEN
    {
        MY_DB mydb = new MY_DB();
        public bool insertEmployee(int msnv, string name, DateTime bdate, string gender, string phone, string username, string pass, string address, string gmail, MemoryStream picture)
        {
            SqlCommand command = new SqlCommand("INSERT INTO employee (MSNV,  name,bdate, gender, phone,username,pass,address,gmail,picture)" +
                 " VALUES(@msnv, @n, @bdt, @gdr, @phn,@username,@pass, @adrs,@gmail, @pic)", mydb.getConnection);
            command.Parameters.Add("@msnv", SqlDbType.Int).Value = msnv;
            command.Parameters.Add("@n", SqlDbType.VarChar).Value = name;
            command.Parameters.Add("@username", SqlDbType.VarChar).Value = username;
            command.Parameters.Add("@bdt", SqlDbType.DateTime).Value = bdate;
            command.Parameters.Add("@gdr", SqlDbType.VarChar).Value = gender;
            command.Parameters.Add("@phn", SqlDbType.VarChar).Value = phone;
            command.Parameters.Add("@pass", SqlDbType.VarChar).Value = pass;
            command.Parameters.Add("@adrs", SqlDbType.VarChar).Value = address;
            command.Parameters.Add("@gmail", SqlDbType.VarChar).Value = gmail;
            command.Parameters.Add("@pic", SqlDbType.Image).Value = picture.ToArray();
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
        public bool employeeExits(int msnv,string username)
        {
            SqlCommand command = new SqlCommand("SELECT * FROM employee WHERE msnv=@student_id and username=@username", mydb.getConnection);
            command.Parameters.Add("@student_id", SqlDbType.Int).Value = msnv;
            command.Parameters.Add("@username", SqlDbType.NVarChar).Value = username;
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
        public bool updateEmployee(int msnv, string name, DateTime bdate, string gender, string phone, string username,string pass,string address,string gmail, MemoryStream picture)
        {
            SqlCommand command = new SqlCommand("UPDATE employee SET name=@n,bdate=@bdt,gender=@gdr,phone=@phn,username=@user,pass=@pass,address =@adrs,gmail = @gmail,picture=@pic WHERE MSNV=@msnv", mydb.getConnection);

            command.Parameters.Add("@msnv", SqlDbType.Int).Value = msnv;
            command.Parameters.Add("@n", SqlDbType.VarChar).Value = name;
            command.Parameters.Add("@user", SqlDbType.VarChar).Value = username;
            command.Parameters.Add("@bdt", SqlDbType.DateTime).Value = bdate;
            command.Parameters.Add("@gdr", SqlDbType.VarChar).Value = gender;
            command.Parameters.Add("@phn", SqlDbType.VarChar).Value = phone;
            command.Parameters.Add("@pass", SqlDbType.VarChar).Value = pass;
            command.Parameters.Add("@adrs", SqlDbType.VarChar).Value = address;
            command.Parameters.Add("@gmail", SqlDbType.VarChar).Value = gmail;
            command.Parameters.Add("@pic", SqlDbType.Image).Value = picture.ToArray();
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
        public bool updateStudent(int msnv, string name, DateTime bdate, string gender, string phone, string pass, string address, string gmail, MemoryStream picture)
        {
            SqlCommand command = new SqlCommand("UPDATE employee SET name=@n,bdate=@bdt,gender=@gdr,phone=@phn,pass=@pass,address =@adrs,gmail = @gmail,picture=@pic WHERE MSNV=@msnv", mydb.getConnection);

            command.Parameters.Add("@msnv", SqlDbType.Int).Value = msnv;
            command.Parameters.Add("@n", SqlDbType.VarChar).Value = name;

            command.Parameters.Add("@bdt", SqlDbType.DateTime).Value = bdate;
            command.Parameters.Add("@gdr", SqlDbType.VarChar).Value = gender;
            command.Parameters.Add("@phn", SqlDbType.VarChar).Value = phone;
            command.Parameters.Add("@pass", SqlDbType.VarChar).Value = pass;
            command.Parameters.Add("@adrs", SqlDbType.VarChar).Value = address;
            command.Parameters.Add("@gmail", SqlDbType.VarChar).Value = gmail;
            command.Parameters.Add("@pic", SqlDbType.Image).Value = picture.ToArray();
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
        public bool deleteEmployee(int id)
        {
            SqlCommand command = new SqlCommand("DELETE FROM employee WHERE MSNV = @ID", mydb.getConnection);

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
        public bool updatePass(int msnv, string pass)
        {
            SqlCommand command = new SqlCommand("UPDATE employee SET pass=@pass WHERE MSNV=@msnv", mydb.getConnection);

            command.Parameters.Add("@msnv", SqlDbType.Int).Value = msnv;

            command.Parameters.Add("@pass", SqlDbType.VarChar).Value = pass;

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
        public bool updateCaLam(int Id, string Thu2, string Thu3, string Thu4, string Thu5, string Thu6, string Thu7, string CN)
        {
            SqlCommand command = new SqlCommand("UPDATE Chiaca SET Thu2=@t2, Thu3=@t3, Thu4=@t4, Thu5=@t5, Thu6=@t6, Thu7=@t7, CN=@cn WHERE id=@id", mydb.getConnection);
            command.Parameters.Add("@id", SqlDbType.NChar).Value = Id;
            command.Parameters.Add("@t2", SqlDbType.NChar).Value = Thu2;
            command.Parameters.Add("@t3", SqlDbType.NChar).Value = Thu3;
            command.Parameters.Add("@t4", SqlDbType.NChar).Value = Thu4;
            command.Parameters.Add("@t5", SqlDbType.NChar).Value = Thu5;
            command.Parameters.Add("@t6", SqlDbType.NChar).Value = Thu6;
            command.Parameters.Add("@t7", SqlDbType.NChar).Value = Thu7;
            command.Parameters.Add("@cn", SqlDbType.NChar).Value = CN;
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
        public bool insertCaLam(int id)
        {
            SqlCommand command = new SqlCommand("insert into Chiaca (id) values (@id)", mydb.getConnection);
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
