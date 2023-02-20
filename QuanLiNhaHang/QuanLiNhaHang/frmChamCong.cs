using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLiNhaHang
{
    public partial class frmChamCong : Form
    {
        public frmChamCong()
        {
            InitializeComponent();
        }
        ChamCong chamcong = new ChamCong();
        private void button1_Click(object sender, EventArgs e)
        {
            DateTime date = DateTime.Now;
            if(chamcong.kiemtra(date))
            {
                if (chamcong.checkIn(date))
                {
                    MessageBox.Show("Check In thành công !");
                }
                else
                {
                    MessageBox.Show("Đã xảy ra lỗi vui lòng thử lại !");
                }
            }    
            else
            {
                MessageBox.Show("Bạn đã check in rồi !");
            }
              
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DateTime date2 = DateTime.Now;
            if (chamcong.checkOut(date2))
            {
                MessageBox.Show("Check Out thành công !");
            }
            else
            {
                MessageBox.Show("Bạn chưa check in !");
            }
        }

    }
}
