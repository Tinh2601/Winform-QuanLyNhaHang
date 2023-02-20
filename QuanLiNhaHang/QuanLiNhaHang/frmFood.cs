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
    public partial class frmFood : Form
    {
        public frmFood()
        {
            InitializeComponent();
        }
        FOOD food = new FOOD();
        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                float gt = Convert.ToInt32(txbgt.Text);

                string ma = txbtma.Text;
                if (verif())
                {
                    if (!food.foodExits(ma))
                    {
                        if (food.insertFood(ma, gt))
                        {

                            MessageBox.Show("Thêm thành công", "Thêm món ăn", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Reload();
                        }
                        else
                        {
                            MessageBox.Show("Error", "Thêm món ăn", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Error", "Thêm món ăn", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Empty Fields", "Thêm món ăn", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception )
            {
                MessageBox.Show("Không thể thêm được vui lòng thử lại !", "Thêm món ăn", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                float gt = Convert.ToInt32(txbgt.Text);

                string ma = txbtma.Text;



                if (verif())
                {

                    if (food.updateFood(ma, gt))
                    {

                        MessageBox.Show("Update thành công", "Add Món ăn", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Reload();
                    }
                    else
                    {
                        MessageBox.Show("Error", "Update Món ăn", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Empty Fields", "Update Món ăn", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch(Exception )
            {
                MessageBox.Show("Đã xảy lỗi vui lòng thử lại", "Update Món ăn", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        bool verif()
        {
            if ((txbtma.Text.Trim() == "")
                || (txbgt.Text.Trim() == ""))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public void Reload()
        {
            FOOD nhanvien = new FOOD();
            SqlCommand command = new SqlCommand("select * from Food");

            dataGridView1.ReadOnly = true;
            // xử lý hình ảnh
            DataGridViewImageColumn pisCol = new DataGridViewImageColumn();
            // khởi tạo đối tượng làm việc với dạng hình ảnh

            dataGridView1.DataSource = nhanvien.getEmployee(command);



            dataGridView1.AllowUserToAddRows = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                string ma = txbtma.Text;

                if ((MessageBox.Show("Bạn thực sự muốn xóa món ăn này không", "Xóa Món ăn", MessageBoxButtons.YesNo, MessageBoxIcon.Question)) == DialogResult.Yes)
                {
                    if (food.deleteEmployee(ma))
                    {
                        MessageBox.Show("Đã xóa thành công", "Xóa Món ăn", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Reload();
                    }
                    else
                    {
                        MessageBox.Show("Món ăn chưa được xóa", "Xóa Món ăn", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
            catch (Exception )
            {
                        MessageBox.Show("Không thể xóa vui lòng thử lại", "Xóa Món ăn", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        public void fillGrid(SqlCommand command)
        {
            FOOD nhanvien = new FOOD();


            dataGridView1.ReadOnly = true;
            // xử lý hình ảnh
            DataGridViewImageColumn pisCol = new DataGridViewImageColumn();
            // khởi tạo đối tượng làm việc với dạng hình ảnh

            dataGridView1.DataSource = nhanvien.getEmployee(command);



            dataGridView1.AllowUserToAddRows = false;

        }
        private void frmFood_Load(object sender, EventArgs e)
        {
            fillGrid(new SqlCommand("SELECT * FROM Food"));
        }

        private void btsltp_Click(object sender, EventArgs e)
        {
            KiemTraSLForm kiemTraSLForm = new KiemTraSLForm();
            kiemTraSLForm.ShowDialog();

        }

        private void txbtma_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
