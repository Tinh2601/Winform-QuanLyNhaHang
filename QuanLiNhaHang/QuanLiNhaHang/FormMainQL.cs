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
    public partial class FormMainQL : Form
    {
        MY_DB mydb = new MY_DB();
        public FormMainQL()
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
            frmNhanVien frmNhanVien = new frmNhanVien();
            frmNhanVien.Show();
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmTableFood frmTableFood = new frmTableFood();
            frmTableFood.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            frmFood frmFood = new frmFood();    
            frmFood.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            frmQuanLyLuongNhanVien frmQuanLyLuongNhanVien = new frmQuanLyLuongNhanVien();
            frmQuanLyLuongNhanVien.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            frmThongKeDoanhThu frmThongKeDoanhThu = new frmThongKeDoanhThu();
            frmThongKeDoanhThu.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            frmQuanLyHoaDon frmQuanLyHoaDon = new frmQuanLyHoaDon();
            frmQuanLyHoaDon.Show();
        }
    }
}
