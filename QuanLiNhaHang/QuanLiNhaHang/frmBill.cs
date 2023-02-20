using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using Aspose.Words;
using Aspose.Words.Tables;
using ThuVienWinform.Report.AsposeWordExtension;
namespace QuanLiNhaHang
{
    public partial class frmBill : Form
    {
        public frmBill()
        {
            InitializeComponent();
        }
        FOOD food = new FOOD();
        TABLEFOOD tablefood = new TABLEFOOD();
        BILL bill = new BILL();
        public static int vitri = 0;
        public static int tongtien;
        private void frmBill_Load(object sender, EventArgs e)
        {

            dataGridView2.Columns.Add("id", "ID món ăn");//tên biến và tên hiển thị
            dataGridView2.Columns.Add("fname", "Tên món");
            dataGridView2.Columns.Add("lname", "Giá tiền");
            reloadListBoxData();
        }

        void reloadListBoxData()
        {
            dataGridView1.ReadOnly = true;
            SqlCommand command = new SqlCommand("select * from Food");
            dataGridView1.DataSource = food.getEmployee(command);



            


            //LabelTotalCourses.Text = ("Total Course : " + COURSE.totalCourse());
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridView2.Rows.Add((DataGridViewRow)dataGridView1.Rows[0].Clone());
                dataGridView2.Rows[vitri].Cells[0].Value = Convert.ToString(dataGridView1.CurrentRow.Cells[0].Value);
                dataGridView2.Rows[vitri].Cells[1].Value = Convert.ToString(dataGridView1.CurrentRow.Cells[1].Value);
                dataGridView2.Rows[vitri].Cells[2].Value = Convert.ToString(dataGridView1.CurrentRow.Cells[2].Value);
                tongtien += Convert.ToInt32(dataGridView1.CurrentRow.Cells[2].Value);
                label4.Text = Convert.ToString(tongtien);
                vitri++;
            }
            catch (Exception )
            {
                MessageBox.Show("Please try again");
                dataGridView2.Rows.Clear();
                vitri=0;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tongtien -= Convert.ToInt32(dataGridView2.Rows[vitrixoa].Cells[2].Value);
            label4.Text = Convert.ToString(tongtien);
            dataGridView2.Rows.RemoveAt(vitrixoa);
            vitri--;
        }
        public static int vitrixoa;
        private void dataGridView2_Click(object sender, EventArgs e)
        {
            vitrixoa = Convert.ToInt32(dataGridView2.CurrentRow.Index.ToString());
        }

        private void button3_Click(object sender, EventArgs e)
        {

            int id = frmTableFood.TableID;
            string status = "Chưa thanh toán";
            if (tablefood.changeStatus(id, status) && bill.insertBill(frmTableFood.TableID, status))
            {

                MessageBox.Show("Đặt đồ ăn thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                SqlCommand command = new SqlCommand("select * from Bill where idTable=" + frmTableFood.TableID + " and status='Chưa thanh toán'");
                DataTable table = bill.getTable(command);

                int id_bill = Convert.ToInt32(table.Rows[0][0].ToString());
                
                for(int i =0;i<dataGridView2.Rows.Count;i++)
                {
                    int id_food=Convert.ToInt32(dataGridView2.Rows[i].Cells[0].Value);
                    bill.insertBillInfo(id_bill, id_food);
                }    
            }
            else
            {
                MessageBox.Show("Đặt đồ ăn không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int id = frmTableFood.TableID;
            string status = "Trong";
            float count = tongtien;
            SqlCommand command = new SqlCommand("select * from Bill where idTable=" + frmTableFood.TableID + " and status='Chưa thanh toán'");
            DataTable table = bill.getTable(command);
            DateTime date = DateTime.Now;
            int id_bill = Convert.ToInt32(table.Rows[0][0].ToString());
            string status2 = "Da thanh toan";
            for (int i = 0; i < dataGridView2.Rows.Count; i++)
            {
                int id_food = Convert.ToInt32(dataGridView2.Rows[i].Cells[0].Value);
                bill.insertBillInfo(id_bill, id_food);
            }
            if (tablefood.changeStatus(id, status) && bill.updateBill(date,frmTableFood.TableID, status2,count))
            {

                MessageBox.Show("Thanh toán thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                
            }
            else
            {
                MessageBox.Show("Thanh toán không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Document baoCao = new Document("wordd\\danhsachSV.doc");

            // DataTable dt = new DataTable();
            //   dataGridView1.DataSource = dt;

            baoCao.MailMerge.Execute(new[] { "Ho_Ten" }, new[] { label4.Text });
            Table Bangdiem = baoCao.GetChild(NodeType.Table, 0, true) as Table;//Lấy bảng thứ 1 trong file mẫu
            int hangHienTai = 1;
            //DataTable ressult = new DataTable();
            // ressult = score.getAVGResultByScore();
            int SoMonHoc = dataGridView2.Rows.Count;
            Bangdiem.InsertRows(hangHienTai, hangHienTai, SoMonHoc - 2);

            for (int i = 0; i < SoMonHoc - 1; i++)
            {
                // int i = 1;
                int a = i + 1;
                Bangdiem.PutValue(hangHienTai, 0, dataGridView2.Rows[i].Cells[0].Value.ToString());
                Bangdiem.PutValue(hangHienTai, 1, dataGridView2.Rows[i].Cells[1].Value.ToString());
                Bangdiem.PutValue(hangHienTai, 2, dataGridView2.Rows[i].Cells[2].Value.ToString());

                //   Bangdiem.PutValue(hangHienTai, 5, dataGridView1.Rows[i].Cells[3].Value.ToString());


                hangHienTai++;
            }
            //  baoCao.MailMerge.Execute(new[] { "Ho_Ten" }, new[] { label4.Text });


            baoCao.SaveAndOpenFile("Luong.doc");
        }
    }
}

