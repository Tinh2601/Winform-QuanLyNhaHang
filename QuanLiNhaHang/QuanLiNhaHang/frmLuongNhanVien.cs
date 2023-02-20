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
    public partial class frmLuongNhanVien : Form
    {
        public frmLuongNhanVien()
        {
            InitializeComponent();
        }
        MY_DB mydb=new MY_DB();
        private void frmLuongNhanVien_Load(object sender, EventArgs e)
        {
            long time = 0;
            SqlCommand command = new SqlCommand("SELECT DATEDIFF(second,timeCheckIn,timeCheckOut ) as time from ChamCong where msnv="+Login_Form.NhanVienID,mydb.getConnection);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            foreach (DataRow dr in table.Rows)
            {
                time += Convert.ToInt32(dr["time"].ToString());
            }
            label2.Text = time.ToString() +"s";

            float hour=0;
            command = new SqlCommand("SELECT DATEDIFF(hour,timeCheckIn,timeCheckOut ) as time from ChamCong where msnv=" + Login_Form.NhanVienID, mydb.getConnection);
            adapter = new SqlDataAdapter(command);
            table = new DataTable();
            adapter.Fill(table);
            foreach (DataRow dr in table.Rows)
            {
                hour += Convert.ToInt32(dr["time"].ToString());
            }
            label3.Text = hour.ToString() + " h";

            if(hour==8)
            {
                label6.Text = "400.000 VNĐ";
            }    
            else if(hour < 8 && hour >=7)
            {
                label6.Text = "300.000 VNĐ";
            }
            else if (hour < 7 && hour >= 6)
            {
                label6.Text = "200.000 VNĐ";
            }
            else if (hour < 6 && hour >= 5)
            {
                label6.Text = "100.000 VNĐ";
            }
            else if (hour < 5 && hour >= 4)
            {
                label6.Text = "0 VNĐ";
            }
            else if (hour < 4 && hour >= 3)
            {
                label6.Text = "0 VNĐ Bạn bị phạt 100.000 VNĐ";
            }
            else if (hour < 3 && hour >= 2)
            {
                label6.Text = "0 VNĐ Bạn bị phạt 200.000 VNĐ";
            }
            else if (hour < 2 && hour >= 1)
            {
                label6.Text = "0 VNĐ Bạn bị phạt 300.000 VNĐ";
            }
            else
            {
                label6.Text = "0 VNĐ Bạn bị phạt 400.000 VNĐ";
            }
        }
    }
}
