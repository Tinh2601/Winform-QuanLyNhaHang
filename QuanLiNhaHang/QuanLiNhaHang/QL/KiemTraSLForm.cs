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
    public partial class KiemTraSLForm : Form
    {
        public KiemTraSLForm()
        {
            InitializeComponent();
        }
        BILL hoadon = new BILL();
        private void KiemTraSLForm_Load(object sender, EventArgs e)
        {
            //lay thong tin tenmon
            comboBoxTenMon.DataSource = hoadon.getHoaDon(new SqlCommand("SELECT * FROM Food"));
            comboBoxTenMon.DisplayMember = "name";
            comboBoxTenMon.ValueMember = "id";

        }

        private void comboBoxTenMon_SelectedValueChanged(object sender, EventArgs e)
        {
            if (comboBoxTenMon.Text.Trim() == "Hu tieu nam vang")
            {
                labelCongThuc.Text = "Mỗi phần hủ tiếu nam vang cần: 10g Thịt, 20g gà, 5g Rau";
            }
            else if (comboBoxTenMon.Text.Trim() == "Hoanh thanh")
            {
                labelCongThuc.Text = "Mỗi thịt hung khói cần: 30g Thịt, 50g gà, 5g Rau";
            }
            else if (comboBoxTenMon.Text.Trim() == "Bun bo hue")
            {
                labelCongThuc.Text = "Mỗi phần Bún bò huế cần  : 20g Thịt, 10g gà, 15g Rau";
            }
            else
            {
                labelCongThuc.Text = "Mỗi Phần " + comboBoxTenMon.Text.Trim() + " Được Làm Từ: 15g Thịt, 15g gà, 10g Rau";
            }
        }
        public int TimMin(int a, int b, int c)
        {
            int min = a;
            if (min > b)
                min = b;
            if (min > c)
                min = c;
            return min;
        }
        private void buttonKtraSL_Click(object sender, EventArgs e)
        {
            if (textBoxTinhBot.Text == "" || textBoxThit.Text == "" || textBoxRau.Text == "")
            {
                MessageBox.Show("Không Thể Để Trống Dữ Liệu Input Kiểm Tra");
            }
            else if (textBoxRau.Text != "" && textBoxThit.Text != "" && textBoxRau.Text != "")
            {
                if (comboBoxTenMon.Text.Trim() == "Hu tieu nam vang")
                {
                    if (Convert.ToInt32(textBoxRau.Text) < 5 || Convert.ToInt32(textBoxTinhBot.Text) < 20 || Convert.ToInt32(textBoxThit.Text) < 10)
                    {
                        labelKtra.Text = "Nguyên Liệu Không Đủ Để Thực Hiện Phần Ăn " + comboBoxTenMon.Text.Trim();
                    }
                    else if (Convert.ToInt32(textBoxRau.Text) >= 5 && Convert.ToInt32(textBoxTinhBot.Text) >= 20 && Convert.ToInt32(textBoxThit.Text) >= 10)
                    {
                        int slrau = Convert.ToInt32(textBoxRau.Text) / 5;
                        int sltinhbot = Convert.ToInt32(textBoxTinhBot.Text) / 20;
                        int slthit = Convert.ToInt32(textBoxThit.Text) / 10;
                        int kq = TimMin(slrau, sltinhbot, slthit);
                        labelKtra.Text = "Ta Có Thể Tạo Ra " + kq + " Phần " + comboBoxTenMon.Text.Trim();

                    }
                }
                else if (comboBoxTenMon.Text.Trim() == "Thit hung khoi")
                {
                    if (Convert.ToInt32(textBoxRau.Text) < 5 || Convert.ToInt32(textBoxTinhBot.Text) < 50 || Convert.ToInt32(textBoxThit.Text) < 30)
                    {
                        labelKtra.Text = "Nguyên Liệu Không Đủ Để Thực Hiện Phần Ăn " + comboBoxTenMon.Text.Trim();
                    }
                    else if (Convert.ToInt32(textBoxRau.Text) >= 5 || Convert.ToInt32(textBoxTinhBot.Text) >= 50 || Convert.ToInt32(textBoxThit.Text) >= 30)
                    {
                        int slrau = Convert.ToInt32(textBoxRau.Text) / 5;
                        int sltinhbot = Convert.ToInt32(textBoxTinhBot.Text) / 50;
                        int slthit = Convert.ToInt32(textBoxThit.Text) / 30;
                        int kq = TimMin(slrau, sltinhbot, slthit);
                        labelKtra.Text = "Ta Có Thể Tạo Ra " + kq + " Phần " + comboBoxTenMon.Text.Trim();

                    }
                }
                else if (comboBoxTenMon.Text.Trim() == "Bun bo hue")
                {
                    if (Convert.ToInt32(textBoxRau.Text) < 15 || Convert.ToInt32(textBoxTinhBot.Text) < 10 || Convert.ToInt32(textBoxThit.Text) < 20)
                    {
                        labelKtra.Text = "Nguyên Liệu Không Đủ Để Thực Hiện Phần Ăn " + comboBoxTenMon.Text.Trim();
                    }
                    else if (Convert.ToInt32(textBoxRau.Text) >= 15 || Convert.ToInt32(textBoxTinhBot.Text) >= 10 || Convert.ToInt32(textBoxThit.Text) >= 20)
                    {
                        int slrau = Convert.ToInt32(textBoxRau.Text) / 15;
                        int sltinhbot = Convert.ToInt32(textBoxTinhBot.Text) / 10;
                        int slthit = Convert.ToInt32(textBoxThit.Text) / 20;
                        int kq = TimMin(slrau, sltinhbot, slthit);
                        labelKtra.Text = "Ta Có Thể Tạo Ra " + kq + " Phần " + comboBoxTenMon.Text.Trim();

                    }
                }
                else
                {
                    if (Convert.ToInt32(textBoxRau.Text) < 10 || Convert.ToInt32(textBoxTinhBot.Text) < 15 || Convert.ToInt32(textBoxThit.Text) < 15)
                    {
                        labelKtra.Text = "Nguyên Liệu Không Đủ Để Thực Hiện Phần Ăn " + comboBoxTenMon.Text.Trim();
                    }
                    else if (Convert.ToInt32(textBoxRau.Text) >= 10 || Convert.ToInt32(textBoxTinhBot.Text) >= 15 || Convert.ToInt32(textBoxThit.Text) >= 15)
                    {
                        int slrau = Convert.ToInt32(textBoxRau.Text) / 10;
                        int sltinhbot = Convert.ToInt32(textBoxTinhBot.Text) / 15;
                        int slthit = Convert.ToInt32(textBoxThit.Text) / 15;
                        int kq = TimMin(slrau, sltinhbot, slthit);
                        labelKtra.Text = "Ta Có Thể Tạo Ra " + kq + " Phần " + comboBoxTenMon.Text.Trim();

                    }
                }
            }
        }
    }
}
