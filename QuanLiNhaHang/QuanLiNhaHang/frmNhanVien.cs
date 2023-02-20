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
    public partial class frmNhanVien : Form
    {
        public frmNhanVien()
        {
            InitializeComponent();
        }
        NHANVIEN nhanvien = new NHANVIEN();
        public void XoaTxb()
        {
            txbgmail.Text = "";
            txbmanv.Text = "";
            txbName.Text = "";
            txbSDT.Text = "";
            txbUsername.Text = "";
            txtPass.Text = "";
            txbquequan.Text = "";
            pictureBox1.Image = null;
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(txbmanv.Text);
                nhanvien.insertCaLam(id);
                string name = txbName.Text;
                string pass = txtPass.Text;
                DateTime bdate = dtime.Value;
                string phone = txbSDT.Text;
                string adrs = txbquequan.Text;
                string username = txbUsername.Text;
                string gmail = txbgmail.Text;
                string gender = "Male";
                if (RadioButtonFemale.Checked)
                {
                    gender = "Female";
                }

                MemoryStream pic = new MemoryStream();
                int born_year = dtime.Value.Year;
                int this_year = DateTime.Now.Year;

                if ((this_year - born_year) < 10 || (this_year - born_year) > 100)
                {
                    MessageBox.Show("Độ tuổi không hợp lệ", "Thêm nhân viên", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (verif())
                {
                    if (!nhanvien.employeeExits(id,username))
                    {
                        pictureBox1.Image.Save(pic, pictureBox1.Image.RawFormat);
                        if (nhanvien.insertEmployee(id, name, bdate, gender, adrs, username, pass, phone, gmail, pic))
                        {
                            MessageBox.Show("Thêm nhân viên thành công", "Thêm nhân viên", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Reload();
                            XoaTxb();
                        }
                        else
                        {
                            MessageBox.Show("Error", "Thêm nhân viên", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Error", "Thêm nhân viên", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Empty Fields", "Add Student", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch(Exception)
            {
                MessageBox.Show("Đã xảy ra lỗi vui lòng thử lại", "Thêm Nhân viên", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(txbmanv.Text);
                string name = txbName.Text;
                string pass = txtPass.Text;
                DateTime bdate = dtime.Value;
                string phone = txbSDT.Text;
                string adrs = txbquequan.Text;
                string username = txbUsername.Text;
                string gmail = txbgmail.Text;
                string gender = "Male";
                if (RadioButtonFemale.Checked)
                {
                    gender = "Female";
                }

                MemoryStream pic = new MemoryStream();
                int born_year = dtime.Value.Year;
                int this_year = DateTime.Now.Year;

                if ((this_year - born_year) < 10 || (this_year - born_year) > 100)
                {
                    MessageBox.Show("Nhân viên phải trong độ tuổi từ 10->100", "Ngày sinh không hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (verif())
                {

                    pictureBox1.Image.Save(pic, pictureBox1.Image.RawFormat);
                    if (nhanvien.updateEmployee(id, name, bdate, gender, phone, adrs, username, pass, gmail, pic))
                    {
                        MessageBox.Show("Đã cập nhật thành công", "Update Nhân viên", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        XoaTxb();
                    }
                    else
                    {
                        MessageBox.Show("Lỗi rồi !", "Update Nhân viên", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                else
                {
                    MessageBox.Show("Empty Fields", "Update Nhân viên", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Update Nhân viên", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        bool verif()
        {
            if ((txbmanv.Text.Trim() == "")
                || (txbName.Text.Trim() == "")
                || (txbUsername.Text.Trim() == "")
                || (txbquequan.Text.Trim() == "")
                || (pictureBox1.Image == null) || (txbSDT.Text.Trim() == "") || (txbgmail.Text.Trim() == "") )
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                //  try
                //  {

                if ((MessageBox.Show("Bạn thật sự có muốn xóa nhân viên này", "Xóa nhân viên", MessageBoxButtons.YesNo, MessageBoxIcon.Question)) == DialogResult.Yes)
                {
                    if (nhanvien.deleteEmployee(id))
                    {
                        MessageBox.Show("Đã xóa nhân viên", "Xóa nhân viên", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Reload();
                    }
                    else
                    {
                        MessageBox.Show("Không thể xóa nhân viên", "Xóa nhân viên", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Đã xảy ra lỗi vui lòng thử lại", "Xóa Nhân viên", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand command = new SqlCommand("SELECT * FROM employee WHERE name LIKE'%" + txtSearch.Text + "%'");
                fillGrid(command);
            }
            catch(Exception ex)
            {
                MessageBox.Show("Xay ra loi");
            }
        }

        public void fillGrid(SqlCommand command)
        {
            NHANVIEN nhanvien = new NHANVIEN();

            dataGridView1.ReadOnly = true;
            // xử lý hình ảnh
            DataGridViewImageColumn pisCol = new DataGridViewImageColumn();
            // khởi tạo đối tượng làm việc với dạng hình ảnh
            dataGridView1.RowTemplate.Height = 80;
            dataGridView1.DataSource = nhanvien.getEmployee(command);

            pisCol = (DataGridViewImageColumn)dataGridView1.Columns[9];
            pisCol.ImageLayout = DataGridViewImageCellLayout.Stretch;

            dataGridView1.AllowUserToAddRows = false;

        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = " Select Image(*.jpg;*png;*gif)|*.jpg;*.png;*.gif";
            if ((opf.ShowDialog() == DialogResult.OK))
            {
                pictureBox1.Image = Image.FromFile(opf.FileName);
            }
        }
        public void Reload()
        {
            SqlCommand command = new SqlCommand("select * from employee");
            dataGridView1.ReadOnly = true;
            // xử lý hình ảnh
            DataGridViewImageColumn pisCol = new DataGridViewImageColumn();
            // khởi tạo đối tượng làm việc với dạng hình ảnh
            dataGridView1.RowTemplate.Height = 80;
            dataGridView1.DataSource = nhanvien.getEmployee(command);

            pisCol = (DataGridViewImageColumn)dataGridView1.Columns[9];
            pisCol.ImageLayout = DataGridViewImageCellLayout.Stretch;

            dataGridView1.AllowUserToAddRows = false;
        }
        private void frmNhanVien_Load(object sender, EventArgs e)
        {
            fillGrid(new SqlCommand("SELECT * FROM employee"));
        }

        private void btnChiaca_Click(object sender, EventArgs e)
        {
            Chiaca chiaca = new Chiaca();
            chiaca.Show();
        }

        private void btnQuanLy_Click(object sender, EventArgs e)
        {
            frmQuanLyCaLamViec frmQuanLyCaLamViec = new frmQuanLyCaLamViec();
            frmQuanLyCaLamViec.Show();
        }
    }
}
