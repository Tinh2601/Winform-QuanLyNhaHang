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
    public partial class frmThongKeDoanhThu : Form
    {
        public frmThongKeDoanhThu()
        {
            InitializeComponent();
        }
        FOOD food = new FOOD();
        private void frmThongKeDoanhThu_Load(object sender, EventArgs e)
        {
            DateTime dateTime = DateTime.Now;
            dateTimePicker1.Value = dateTime;
            label1.Text = dateTime.ToString("yyyy-MM-dd");
            dataGridView1.ReadOnly = true;
            SqlCommand command = new SqlCommand("select sum(CountBill) as 'Doanh thu'  from Bill where DateCheckOut='" + dateTime.ToString("yyyy-MM-dd") + "'");
            dataGridView1.DataSource = food.getEmployee(command);

            dataGridView2.ReadOnly = true;
            command = new SqlCommand("select count(Food.name) as 'Số lượng',name from BillInfo,Bill,Food where Bill.id=BillInfo.idBill and BillInfo.idFood=Food.id and Bill.DateCheckIn='"+dateTime.ToString("yyyy-MM-dd") + "'  group by(Food.name) order by count(Food.name) desc");
            dataGridView2.DataSource = food.getEmployee(command);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime dateTime = dateTimePicker1.Value;
            label1.Text = dateTime.ToString("yyyy-MM-dd");
            dataGridView1.ReadOnly = true;
            SqlCommand command = new SqlCommand("select sum(CountBill) as 'Doanh thu'  from Bill where DateCheckOut='" + dateTime.ToString("yyyy-MM-dd") + "'");
            dataGridView1.DataSource = food.getEmployee(command);

            dataGridView2.ReadOnly = true;
            command = new SqlCommand("select count(Food.name) as 'Số lượng',name from BillInfo,Bill,Food where Bill.id=BillInfo.idBill and BillInfo.idFood=Food.id and Bill.DateCheckIn='" + dateTime.ToString("yyyy-MM-dd") + "'  group by(Food.name) order by count(Food.name) desc");
            dataGridView2.DataSource = food.getEmployee(command);
        }
    }
}
