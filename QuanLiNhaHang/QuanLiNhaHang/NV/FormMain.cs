using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLiNhaHang
{
    public partial class FormMain : Form
    {
        MY_DB mydb = new MY_DB();
        public FormMain()
        {
            InitializeComponent();
            customizeDesing();
        }
        private void customizeDesing()
        {
            
        }

        private void hideSubMenu()
        {
            
        }

        private void showSubMenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                hideSubMenu();
                subMenu.Visible = true;
            }
            else
            {
                subMenu.Visible = false;
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Start();
            labelTime.Text = DateTime.Now.ToLongTimeString();
        }
        private void FormMain_Load(object sender, EventArgs e)
        {
            // pictureBox1.Image = Image.FromFile("../../images/Picture1.png");
            timer1.Start();
       
            labelTime.Text = DateTime.Now.ToLongTimeString();
            labelDate.Text = DateTime.Now.ToLongDateString();
        }
       
        private void ButtonAddStd_Click(object sender, EventArgs e)
        {
            
        }

        private void ButtonStdList_Click(object sender, EventArgs e)
        {
            
        }

        private void ButtonStatics_Click(object sender, EventArgs e)
        {
            
        }

        private void ButtonEditRemoveStd_Click(object sender, EventArgs e)
        {
            
        }

        private void ButtonManagerStd_Click(object sender, EventArgs e)
        {
            
        }

        private void ButtonPrintStd_Click(object sender, EventArgs e)
        {
            

        }

        private void ButtonAddCourse_Click(object sender, EventArgs e)
        {
            
        }

        private void ButtonRemoveCourse_Click(object sender, EventArgs e)
        {
            
        }

        private void ButtonEditCourse_Click(object sender, EventArgs e)
        {
            
        }

        private void ButtonManagerCourse_Click(object sender, EventArgs e)
        {
            
        }

        private void ButtonStudent_Click(object sender, EventArgs e)
        {
         //   showSubMenu(PanelSubStudent);
        }

        private void ButtonCourse_Click(object sender, EventArgs e)
        {
           // showSubMenu(PanelSubCourse);
        }

        private void ButtonScore_Click(object sender, EventArgs e)
        {
          //  showSubMenu(PanelSubScore);
        }

        private void ButtonPrintfCourse_Click(object sender, EventArgs e)
        {
            
        }

        private void ButtonAddScore_Click(object sender, EventArgs e)
        {
            
        }

        private void ButtonRemoveScore_Click(object sender, EventArgs e)
        {
           
        }

        private void ButtonManagerScore_Click(object sender, EventArgs e)
        {
            
        }

        private void ButttonAvg_Click(object sender, EventArgs e)
        {
            
        }

        private void ButtonPrint_Click(object sender, EventArgs e)
        {
            
        }

        private void ButtonResult_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
          ;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            frmChamCong frmChamCong = new frmChamCong();
            frmChamCong.Show();
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmTableFood frmTableFood  = new frmTableFood();
            frmTableFood.Show();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                frmLichLamViec frmLichLamViec = new frmLichLamViec();
                frmLichLamViec.Show();
            }
            catch (Exception )
            {
                MessageBox.Show("Da xay ra loi!");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            frmLuongNhanVien frmLuongNhanVien = new frmLuongNhanVien();
            frmLuongNhanVien.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ThongTinNV_UC thongTinNV_UC = new ThongTinNV_UC();
            thongTinNV_UC.Show();
        }
    }
}
