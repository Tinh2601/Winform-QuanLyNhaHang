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
using Aspose.Words;
using Aspose.Words.Tables;
using ThuVienWinform.Report.AsposeWordExtension;

namespace QuanLiNhaHang
{
    public partial class frmQuanLyLuongNhanVien : Form
    {
        public frmQuanLyLuongNhanVien()
        {
            InitializeComponent();
        }
        MY_DB mydb = new MY_DB();
        DataTable dsNhanVien = new DataTable();
        DataTable msNhanVien = new DataTable();
        DataTable timeLamViec = new DataTable();

        public void DanhSachNhanVien()
        {
            SqlCommand command = new SqlCommand("select * from employee" , mydb.getConnection);
            mydb.openConnection();
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = command;
            adapter.Fill(dsNhanVien);
        }

        public void MaSoNhanVien()
        {
            SqlCommand command = new SqlCommand("select MSNV from employee", mydb.getConnection);
            mydb.openConnection();
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = command;
            adapter.Fill(msNhanVien);
        }

        public void TimeLamViec(int msnv,DateTime date)
        {
            SqlCommand command = new SqlCommand("SELECT sum(DATEDIFF(hour,timeCheckIn,timeCheckOut )) as time from ChamCong where msnv="+ msnv +" and dateWork=@date", mydb.getConnection);
            command.Parameters.Add("@date", SqlDbType.DateTime).Value = date;
            mydb.openConnection();
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = command;
            adapter.Fill(timeLamViec);
        }

        private void frmQuanLyLuongNhanVien_Load(object sender, EventArgs e)
        {
            
            dataGridView1.Columns.Add("id", "Mã số nhân viên");//tên biến và tên hiển thị
            dataGridView1.Columns.Add("fname", "Tên nhân viên");
            dataGridView1.Columns.Add("lname", "Lương");
            dataGridView1.Columns.Add("lname", "Thời gian làm việc");
            dataGridView1.Columns.Add("lname", "Ngày");
            
            DanhSachNhanVien();
            int i = 0;
            foreach (DataRow row in dsNhanVien.Rows)
            {
                dataGridView1.Rows.Add((DataGridViewRow)dataGridView1.Rows[0].Clone());
                timeLamViec.Clear();
                int id= Convert.ToInt32(row["MSNV"].ToString());
                string name = row["name"].ToString();
                DateTime dateTime = DateTime.Now;
                dataGridView1.Rows[i].Cells[0].Value = Convert.ToString(id);
                dataGridView1.Rows[i].Cells[1].Value = Convert.ToString(name);
                dataGridView1.Rows[i].Cells[4].Value = dateTime.ToString("yyyy-MM-dd");

                DateTime date = DateTime.Now;

                SqlCommand command = new SqlCommand("SELECT count(DATEDIFF(hour,timeCheckIn,timeCheckOut )) as time from ChamCong where msnv="+id +" and dateWork='" + date.ToString("yyyy-MM-dd") + "'", mydb.getConnection);
                mydb.openConnection();
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = command;
                adapter.Fill(timeLamViec);

                foreach (DataRow row1 in timeLamViec.Rows)
                {
                    string time = row1["time"].ToString();
                    dataGridView1.Rows[i].Cells[3].Value = time;
                }

                float hour = Convert.ToInt32(dataGridView1.Rows[i].Cells[3].Value.ToString());
                // lương nhân viên
                if (hour == 8)
                {
                    dataGridView1.Rows[i].Cells[2].Value  = "400.000 VNĐ";
                }
                else if (hour < 8 && hour >= 7)
                {
                    dataGridView1.Rows[i].Cells[2].Value = "300.000 VNĐ";
                }
                else if (hour < 7 && hour >= 6)
                {
                    dataGridView1.Rows[i].Cells[2].Value = "200.000 VNĐ";
                }
                else if (hour < 6 && hour >= 5)
                {
                    dataGridView1.Rows[i].Cells[2].Value = "100.000 VNĐ";
                }
                else if (hour < 5 && hour >= 4)
                {
                    dataGridView1.Rows[i].Cells[2].Value = "0 VNĐ";
                }
                else if (hour < 4 && hour >= 3)
                {
                    dataGridView1.Rows[i].Cells[2].Value = "0 VNĐ Bạn bị phạt 100.000 VNĐ VNĐ";
                }
                else if (hour < 3 && hour >= 2)
                {
                    dataGridView1.Rows[i].Cells[2].Value = "0 VNĐ Bạn bị phạt 200.000 VNĐ";
                }
                else if (hour < 2 && hour >= 1)
                {
                    dataGridView1.Rows[i].Cells[2].Value = "0 VNĐ Bạn bị phạt 300.000 VNĐ";
                }
                else
                {
                    dataGridView1.Rows[i].Cells[2].Value = "0 VNĐ Bạn bị phạt 400.000 VNĐ";
                }

                i++;
                
                
            }

            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Document baoCao = new Document("wordd\\danhsachmonhoc.doc");




            Table Bangdiem = baoCao.GetChild(NodeType.Table, 0, true) as Table;//Lấy bảng thứ 1 trong file mẫu
            int hangHienTai = 1;
            //DataTable ressult = new DataTable();
            // ressult = score.getAVGResultByScore();
            int SoMonHoc = dataGridView1.Rows.Count;
            Bangdiem.InsertRows(hangHienTai, hangHienTai, SoMonHoc-2);

            for (int i = 0; i < SoMonHoc-1; i++)
            {
                // int i = 1;
                int a = i + 1;
                Bangdiem.PutValue(hangHienTai, 0, dataGridView1.Rows[i].Cells[0].Value.ToString());
                Bangdiem.PutValue(hangHienTai, 1, dataGridView1.Rows[i].Cells[1].Value.ToString());
                Bangdiem.PutValue(hangHienTai, 2, dataGridView1.Rows[i].Cells[2].Value.ToString());
                Bangdiem.PutValue(hangHienTai, 3, dataGridView1.Rows[i].Cells[3].Value.ToString());
                Bangdiem.PutValue(hangHienTai, 4, dataGridView1.Rows[i].Cells[4].Value.ToString());
             //   Bangdiem.PutValue(hangHienTai, 5, dataGridView1.Rows[i].Cells[3].Value.ToString());


                hangHienTai++;
            }

    

            baoCao.SaveAndOpenFile("Luong.doc");
        }
    }
}
