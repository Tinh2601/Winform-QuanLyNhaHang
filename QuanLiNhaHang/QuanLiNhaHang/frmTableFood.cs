using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QuanLiNhaHang
{
    public partial class frmTableFood : Form
    {

        public static int TableID { get; private set; }
        public static void SetTableID(int userID)
        { TableID = userID; }
        public frmTableFood()
        {
            InitializeComponent();
        }

        private void frmTableFood_Load(object sender, EventArgs e)
        {
            fillGrid(new SqlCommand("SELECT * FROM TableFood"));
        }
        public void fillGrid(SqlCommand command)
        {
            NHANVIEN nhanvien = new NHANVIEN();

            dataGridView1.ReadOnly = true;

            // khởi tạo đối tượng làm việc với dạng hình ảnh
            dataGridView1.RowTemplate.Height = 80;
            dataGridView1.DataSource = nhanvien.getEmployee(command);



            dataGridView1.AllowUserToAddRows = false;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            fillGrid(new SqlCommand("SELECT * FROM TableFood"));
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            TABLEFOOD tablefood = new TABLEFOOD();

            string name = txbName.Text;
            string status = txbStatus.Text;


            if (verif())
            {
                if (tablefood.insertTable( name, status))
                {

                    MessageBox.Show("Thêm bàn ăn thành công", "Thêm bàn ăn", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    fillGrid(new SqlCommand("SELECT * FROM TableFood"));
                }
                else
                {
                    MessageBox.Show("Error", "Thêm bàn ăn", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Empty Fields", "Thêm bàn ăn", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        bool verif()
        {
            if ((txbName.Text.Trim() == "")
                || (txbStatus.Text.Trim() == ""))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            TABLEFOOD tablefood = new TABLEFOOD();

            int id = Convert.ToInt32(txtID.Text);
            string name = txbName.Text;
            string status = txbStatus.Text;


            if (verif())
            {
                if (tablefood.updateTable(id,name, status))
                {

                    MessageBox.Show("Update bàn ăn", "Update bàn ăn", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    fillGrid(new SqlCommand("SELECT * FROM TableFood"));
                }
                else
                {
                    MessageBox.Show("Error", "Update bàn ăn", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Empty Fields", "Update bàn ăn", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            TABLEFOOD tablefood = new TABLEFOOD();
            int id = Convert.ToInt32(txtID.Text);
            if (tablefood.deleteTable(id))
            {

                MessageBox.Show("Xóa bàn ăn thành công", "Xóa bàn ăn", MessageBoxButtons.OK, MessageBoxIcon.Information);
                fillGrid(new SqlCommand("SELECT * FROM TableFood"));
            }
            else
            {
                MessageBox.Show("Error", "Xóa bàn ăn", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            SetTableID(id);
            frmBill showProfileContact = new frmBill();
            showProfileContact.Show(this);
        }
    }
}
