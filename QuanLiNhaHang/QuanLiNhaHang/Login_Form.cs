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
    public partial class Login_Form : Form
    {
        public Login_Form()
        {
            InitializeComponent();
        }
        public static int ID;
        MY_DB mydb = new MY_DB();
        public static int NhanVienID { get; private set; }
        public static void SetNhanVienID(int userID)
        { NhanVienID = userID; }
        //  NhanVien nhanvien = new NhanVien();
        private void buttonLogin_Click(object sender, EventArgs e)
        {
            MY_DB mY_DB = new MY_DB();
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();
            if (radioButtonQL.Checked == true)
            {
                SqlCommand command = new SqlCommand("SELECT * FROM login WHERE username = @User and password =@Pass", mydb.getConnection);
                command.Parameters.Add("@User", SqlDbType.VarChar).Value = textBoxUser.Text;
                command.Parameters.Add("@Pass", SqlDbType.VarChar).Value = textBoxPass.Text;
                adapter.SelectCommand = command;
                adapter.Fill(table);
                
                string h = DateTime.Now.Hour.ToString();
                int HourInt = Convert.ToInt32(h);
                if (HourInt >= 7 && HourInt <= 11)
                {
                    if (textBoxUser.Text == "cong")
                    {
                        MessageBox.Show("Khong phai ca lam cua quan ly cong.");
                    }
                    else if ((table.Rows.Count > 0))
                    {
                        FormMainQL form1 = new FormMainQL();
                        form1.Show(this);
                        //this.DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        MessageBox.Show("No", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    if (textBoxUser.Text == "tinh")
                    {
                        MessageBox.Show("Khong phai ca lam cua quan ly tinh.");
                    }
                    else if ((table.Rows.Count > 0))
                    {
                        FormMainQL form1 = new FormMainQL();
                        form1.Show(this);
                        //this.DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        MessageBox.Show("No", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            if (radioButtonNV.Checked == true)
            {
                SqlCommand command = new SqlCommand("SELECT * FROM employee WHERE username = @User and pass =@Pass", mydb.getConnection);
                command.Parameters.Add("@User", SqlDbType.VarChar).Value = textBoxUser.Text;
                command.Parameters.Add("@Pass", SqlDbType.VarChar).Value = textBoxPass.Text;
                adapter.SelectCommand = command;
                adapter.Fill(table);
                int id=Convert.ToInt32(table.Rows[0][0].ToString());
                SetNhanVienID(id);
                if ((table.Rows.Count > 0))
                {
                  //  ID = Convert.ToInt32(table.Rows[0]["Id"].ToString());
                    FormMain form1 = new FormMain();
                 
                    form1.Show(this);
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("No", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            
        }

        private void textBoxUser_Leave(object sender, EventArgs e)
        {
            if (textBoxUser.Text == "")
            {
                textBoxUser.Text = "UserName";
                textBoxUser.ForeColor = Color.Black;
            }
        }

        private void textBoxUser_Enter(object sender, EventArgs e)
        {
            if (textBoxUser.Text == "UserName")
            {
                textBoxUser.Text = "";
                textBoxUser.ForeColor = Color.Black;
            }
        }

        private void textBoxPass_Leave(object sender, EventArgs e)
        {
            if (textBoxPass.Text == "")
            {
                textBoxPass.Text = "PassWord";
                textBoxPass.ForeColor = Color.Black;
            }
        }

        private void textBoxPass_Enter(object sender, EventArgs e)
        {
            if (textBoxPass.Text == "PassWord")
            {
                textBoxPass.Text = "";
                textBoxPass.ForeColor = Color.Black;
            }
        }
        int flag = 0;
        private void pictureBoxAnPass_Click(object sender, EventArgs e)
        {
            if (flag == 0)
            {
                textBoxPass.UseSystemPasswordChar = false;
                flag = 1;
            }
            else
            {
                textBoxPass.UseSystemPasswordChar = true;
                flag = 0;
            }
        }
        public int IDKey = ID;

        private void buttonclose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Login_Form_Load(object sender, EventArgs e)
        {
            textBoxUser.ForeColor = Color.Black;
            textBoxUser.Text = "UserName";
            textBoxUser.Leave += new EventHandler(textBoxUser_Leave);
            textBoxUser.Enter += new EventHandler(textBoxUser_Enter);

            textBoxPass.ForeColor = Color.Black;
            textBoxPass.Text = "PassWord";
            textBoxPass.Leave += new EventHandler(textBoxPass_Leave);
            textBoxPass.Enter += new EventHandler(textBoxPass_Enter);
        }

        private void textBoxUser_Click(object sender, EventArgs e)
        {
            textBoxUser.BackColor = Color.White;
            panel3.BackColor = Color.White;
            panel4.BackColor = SystemColors.Control;
            textBoxPass.BackColor = SystemColors.Control;
        }

        private void textBoxPass_Click(object sender, EventArgs e)
        {
            textBoxPass.UseSystemPasswordChar = true;
            textBoxPass.BackColor = Color.White;
            panel4.BackColor = Color.White;
            textBoxUser.BackColor = SystemColors.Control;
            panel3.BackColor = SystemColors.Control;
        }

        private void radioButtonQL_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
