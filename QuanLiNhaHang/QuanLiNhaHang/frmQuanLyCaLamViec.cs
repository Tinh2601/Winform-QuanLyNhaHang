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
    public partial class frmQuanLyCaLamViec : Form
    {
        public frmQuanLyCaLamViec()
        {
            InitializeComponent();
        }
        FOOD food = new FOOD();
        private void frmQuanLyCaLamViec_Load(object sender, EventArgs e)
        {
            DateTime dateTime = DateTime.Now;

            dataGridView1.ReadOnly = true;
            SqlCommand command = new SqlCommand("select  ChamCong.msnv as 'Mã số',employee.name as 'Tên',ChamCong.timeCheckIn as 'Thời gian CheckIn',ChamCong.timeCheckOut as 'Thời gian CheckOut',ChamCong.dateWork as 'Ngày làm việc ' from ChamCong,employee where employee.MSNV=ChamCong.msnv and dateWork='" + dateTime.ToString("yyyy-MM-dd") + "'");
            dataGridView1.DataSource = food.getEmployee(command);
        }


        private void btnSearch_Click(object sender, EventArgs e)
        {
            DateTime datetime = dateTimePicker1.Value;
            dataGridView1.ReadOnly = true;
            SqlCommand command = new SqlCommand("select  ChamCong.msnv as 'Mã số',employee.name as 'Tên',ChamCong.timeCheckIn as 'Thời gian CheckIn',ChamCong.timeCheckOut as 'Thời gian CheckOut',ChamCong.dateWork as 'Ngày làm việc ' from ChamCong,employee where employee.MSNV=ChamCong.msnv and dateWork='" + datetime.ToString("yyyy-MM-dd") + "'");
            dataGridView1.DataSource = food.getEmployee(command);
        }

        private void btnLuong_Click(object sender, EventArgs e)
        {
            frmQuanLyLuongNhanVien frmQuanLyLuongNhanVien = new frmQuanLyLuongNhanVien();
            frmQuanLyLuongNhanVien.Show();
        }
    }
}
