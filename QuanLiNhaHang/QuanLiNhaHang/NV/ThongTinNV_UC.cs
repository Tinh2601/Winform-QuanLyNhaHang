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
    public partial class ThongTinNV_UC : Form
    {
        public ThongTinNV_UC()
        {
            InitializeComponent();
        }
    //    NhanVien nhanvien = new NhanVien();
        MY_DB mydb = new MY_DB();
        Login_Form login = new Login_Form();
        public int check = 0;
      //  Login_Form acc = new AccountNV();

        private void ThongTinNV_UC_Load(object sender, EventArgs e)
        {
            int name = login.IDKey;
            SqlCommand command = new SqlCommand(" SELECT employee.MSNV, employee.name, employee.bdate, employee.gender, employee.phone,employee.pass,employee.address, employee.gmail ,  employee.picture FROM employee " +
                "where employee.MSNV= " +Login_Form.NhanVienID,mydb.getConnection);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            TextBoxID.Text = table.Rows[0]["MSNV"].ToString();
            if (table.Rows.Count > 0)
            {
                TextBoxLName.Text = table.Rows[0]["name"].ToString();
               TextBoxAddress.Text = table.Rows[0]["address"].ToString();
                textBoxPhone.Text = table.Rows[0]["phone"].ToString();
                textBoxDoiMK.Text = table.Rows[0]["pass"].ToString();
              //  textBoxCMND.Text = table.Rows[0]["MSNV"].ToString();
                textBoxMail.Text = table.Rows[0]["gmail"].ToString();
                if (table.Rows[0]["gender"].ToString() == "Female    ")
                {
                    Female.Checked = true;
                }
                else
                {
                    Male.Checked = true;
                }
                
                if (table.Rows[0]["bdate"].ToString().Trim() != "" && table.Rows[0]["picture"].ToString().Trim() != "")
                {
                    DateTimePickerBirth.Value = (DateTime)table.Rows[0]["bdate"];
                    byte[] pic = (byte[])table.Rows[0]["picture"];
                    MemoryStream picture = new MemoryStream(pic);
                    PictureBoxNV.Image = Image.FromStream(picture);
                }
            }

           


        }
        bool verif()
        {
            if (
                 (TextBoxLName.Text.Trim() == "")
                || (TextBoxLName.Text.Trim() == "")
                || (textBoxPhone.Text.Trim() == "")
                || (TextBoxAddress.Text.Trim() == "")
                
                || (textBoxMail.Text.Trim() == "")
                || (PictureBoxNV.Image == null))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void ButtonRemove_Click(object sender, EventArgs e)
        {
            
            //if (Convert.ToInt32(TextBoxID.Text.Trim()) != login.IDKey)
            //{
            //    MessageBox.Show("Bạn Không Có Quyền Edit ID Staff Khác", "Edit Student", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //}
            //else
            //{
            //    try
            //    {
            //        int NhanVienID = Convert.ToInt32(TextBoxID.Text);
            //        //string TenNV = 
            //        if ((MessageBox.Show("Bạn có muốn xóa Nhân Viên này!!!", "Xóa Nhân Viên", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
            //        {
            //            if (nhanvien.deleteNhanVien(NhanVienID))
            //            {
            //                acc.deleteAccount(NhanVienID);
            //                nhanvien.deleteChiaCa(NhanVienID);
            //                nhanvien.deleteLuongNV(NhanVienID);
            //                nhanvien.deleteTimeLV(NhanVienID);
            //                MessageBox.Show("Xóa Nhân Viên", "Xóa Nhân Viên", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //                TextBoxID.Text = "";
            //                TextBoxFName.Text = "";
            //                TextBoxLName.Text = "";
            //                TextBoxAddress.Text = "";
            //                TextBoxPhone.Text = "";
            //                DateTimePickerBirth.Value = DateTime.Now;
            //                PictureBoxNV.Image = null;
            //            }
            //            else
            //            {
            //                MessageBox.Show("Không xóa nhân viên được", "Xóa nhân viên", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //            }
            //        }
            //    }
            //    catch
            //    {
            //        MessageBox.Show("Nhập tên Nhân Viên", "Xóa nhân viên", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    }
            //}
            //MessageBox.Show("Bạn Đã Hết Quyền Truy Cập, Mời Bạn Logout", "Logout", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void ButtonEdit_Click(object sender, EventArgs e)
        {
            NHANVIEN nhanvien = new NHANVIEN();
            int id = Convert.ToInt32(TextBoxID.Text);

            string lname = TextBoxLName.Text;
           // string lname = txbUsername.Text;
            DateTime bdate = DateTimePickerBirth.Value;
            string phone = textBoxPhone.Text;
            string adrs = TextBoxAddress.Text;
            string pass = textBoxDoiMK.Text;
            string gmail = textBoxMail.Text;
            string gender = "Male";
            if (Female.Checked)
            {
                gender = "Female";
            }

            MemoryStream pic = new MemoryStream();
            int born_year = DateTimePickerBirth.Value.Year;
            int this_year = DateTime.Now.Year;

            if ((this_year - born_year) < 10 || (this_year - born_year) > 100)
            {
                MessageBox.Show("The Employee Age Must Be Between 10 and 100 year", "Invalid Birth Date", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (verif())
            {

                PictureBoxNV.Image.Save(pic, PictureBoxNV.Image.RawFormat);
                if (nhanvien.updateStudent(id,  lname, bdate, gender, phone,pass, adrs, gmail, pic))
                {

                    MessageBox.Show("Employee Update", "Update Employee", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Error", "Update Employee", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
            }
            else
            {
                MessageBox.Show("Empty Fields", "Update Employee", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void ButtonUploadImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "Select Image(*.jpg; *.png; *.gif)| *.jpg; *.png; *.gif";
            if ((opf.ShowDialog() == DialogResult.OK))
            {
                PictureBoxNV.Image = Image.FromFile(opf.FileName);
            }
        }

        private void buttonDoiMK_Click(object sender, EventArgs e)
        {
            NHANVIEN nhanvien = new NHANVIEN();
           
                int id;
                string mkhau = textBoxDoiMK.Text;


                if (verif())
                {
                    try
                    {
                        id = Convert.ToInt32(TextBoxID.Text);

                        if (nhanvien.updatePass(id, mkhau))
                        {
                            MessageBox.Show("Staff Information Updated", "Edit Staff", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Error", "Edit Staff", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Edit Staff", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else
                {
                    MessageBox.Show("Empty Fields", "Edit Staff", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            
        }

        private void TextBoxPhone_Leave(object sender, EventArgs e)
        {
            if (textBoxPhone.Text == "")
            {
                textBoxPhone.Text = "Số Điện Thoại";
                textBoxPhone.ForeColor = Color.Black;
            }
        }

        private void TextBoxPhone_Enter(object sender, EventArgs e)
        {
            if (textBoxPhone.Text == "Số Điện Thoại")
            {
                textBoxPhone.Text = "";
                textBoxPhone.ForeColor = Color.Black;
            }
        }

        private void TextBoxAddress_Leave(object sender, EventArgs e)
        {
            if (TextBoxAddress.Text == "")
            {
                TextBoxAddress.Text = "Địa Chỉ";
                TextBoxAddress.ForeColor = Color.Black;
            }
        }

        private void TextBoxAddress_Enter(object sender, EventArgs e)
        {
            if (TextBoxAddress.Text == "Địa Chỉ")
            {
                TextBoxAddress.Text = "";
                TextBoxAddress.ForeColor = Color.Black;
            }
        }

       

        private void textBoxMail_Leave(object sender, EventArgs e)
        {
            if (textBoxMail.Text == "")
            {
                textBoxMail.Text = "Gmail";
                textBoxMail.ForeColor = Color.Black;
            }
        }

        private void textBoxMail_Enter(object sender, EventArgs e)
        {
            if (textBoxMail.Text == "Gmail")
            {
                textBoxMail.Text = "";
                textBoxMail.ForeColor = Color.Black;
            }
        }
    }
}
