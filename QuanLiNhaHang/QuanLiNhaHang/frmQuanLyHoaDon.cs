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
    public partial class frmQuanLyHoaDon : Form
    {
        public frmQuanLyHoaDon()
        {
            InitializeComponent();
        }
        FOOD food = new FOOD();
        private void frmQuanLyHoaDon_Load(object sender, EventArgs e)
        {
            dataGridView1.ReadOnly = true;
            SqlCommand command = new SqlCommand("select * from Bill");
            dataGridView1.DataSource = food.getEmployee(command);
        }
    }
}
