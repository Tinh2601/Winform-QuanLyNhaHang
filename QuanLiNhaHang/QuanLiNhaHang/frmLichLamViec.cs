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
    public partial class frmLichLamViec : Form
    {
        public frmLichLamViec()
        {
            InitializeComponent();
        }
        FOOD food = new FOOD();
        private void frmLichLamViec_Load(object sender, EventArgs e)
        {
            dataGridView1.ReadOnly = true;
            SqlCommand command = new SqlCommand("SELECT employee.msnv, Thu2, Thu3, Thu4, Thu5, Thu6, Thu7, CN FROM Chiaca RIGHT JOIN employee ON Chiaca.id = employee.msnv and Chiaca.id =" + Login_Form.NhanVienID);
            dataGridView1.DataSource = food.getEmployee(command);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable tableCa = new DataTable();
            adapter.Fill(tableCa);
            dataGridView1.DataSource = tableCa;

            //     for (int i = 0; i < tableCa.Rows.Count; i++)
            //   {
            //for (int j = 1; j < tableCa.Columns.Count; j++)
            //{
            //    if (Convert.ToInt32(tableCa.Rows[0][j].ToString()) == 3)
            //    {
            //        dataGridView1.Rows[0].Cells[j].Value = "Ca1, Ca2";

            //    }
            //    else if (Convert.ToInt32(tableCa.Rows[0][j].ToString()) == 2)
            //    {
            //        dataGridView1.Rows[0].Cells[j].Value = "Ca1, Ca3";
            //    }
            //    else
            //    {
            //        dataGridView1.Rows[0].Cells[j].Value = "Ca2, Ca3";
            //    }
            //}
        }


    }
}

