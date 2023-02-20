using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLiNhaHang
{
    public partial class Chiaca : Form
    {
        public Chiaca()
        {
            InitializeComponent();
        }
        MY_DB mydb = new MY_DB();
        NHANVIEN nhanvien = new NHANVIEN();
        public DataTable showData(SqlCommand command)
        {
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }
        private void btchiaca_Click(object sender, EventArgs e)
        {
            
        }
        public void chiaCaNhanVien()
        {
            SqlCommand commandCa = new SqlCommand(" SELECT employee.msnv, Thu2, Thu3, Thu4, Thu5, Thu6, Thu7, CN FROM Chiaca RIGHT JOIN employee ON Chiaca.id = employee.msnv ", mydb.getConnection);
            SqlDataAdapter adapter = new SqlDataAdapter(commandCa);
            DataTable tableCa = new DataTable();
            adapter.Fill(tableCa);

            int n;
            Random rd = new Random();
            n = rd.Next(1, 4);
            for (int i = 0; i < tableCa.Rows.Count; i++)
            {
                for (int j = 1; j < tableCa.Columns.Count; j++)
                {
                    tableCa.Rows[i][j] = n;
                    n++;
                    if (n == 4)
                    {
                        n = 1;
                    }
                }

            }

            int a = Convert.ToInt32(tableCa.Rows[0]["MSNV"].ToString());
            string t2 = Convert.ToString(tableCa.Rows[0]["Thu2"].ToString());
            string t3 = Convert.ToString(tableCa.Rows[0]["Thu3"].ToString());
            string t4 = Convert.ToString(tableCa.Rows[0]["Thu4"].ToString());
            string t5 = Convert.ToString(tableCa.Rows[0]["Thu5"].ToString());
            string t6 = Convert.ToString(tableCa.Rows[0]["Thu6"].ToString());
            string t7 = Convert.ToString(tableCa.Rows[0]["Thu7"].ToString());
            string cn = Convert.ToString(tableCa.Rows[0]["CN"].ToString());
            if (nhanvien.updateCaLam(a, t2, t3, t4, t5, t6, t7, cn))
            {
                // MessageBox.Show("Update thành công !");
                MessageBox.Show("CHIA CA THÀNH CÔNG CHO NHÂN VIÊN!!!");
            }
            else
            {
                MessageBox.Show("CHIA CA THÀNH CÔNG CHO NHÂN VIÊN!!!");
            }
            dataGridView1.DataSource = tableCa;

            for (int i = 0; i < tableCa.Rows.Count; i++)
            {
                for (int j = 1; j < tableCa.Columns.Count; j++)
                {
                    if (Convert.ToInt32(tableCa.Rows[i][j].ToString()) == 3)
                    {
                        dataGridView1.Rows[i].Cells[j].Value = "Ca1, Ca2";

                    }
                    else if (Convert.ToInt32(tableCa.Rows[i][j].ToString()) == 2)
                    {
                        dataGridView1.Rows[i].Cells[j].Value = "Ca1, Ca3";
                    }
                    else
                    {
                        dataGridView1.Rows[i].Cells[j].Value = "Ca2, Ca3";
                    }
                }
            }

            dataGridView1.AllowUserToAddRows = false;
        }
        private void Chiaca_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'qLNHDataSet.Chiaca' table. You can move, or remove it, as needed.
            //this.chiacaTableAdapter.Fill(this.qLNHDataSet.Chiaca);
            chiaCaNhanVien();
        }

    }
}
