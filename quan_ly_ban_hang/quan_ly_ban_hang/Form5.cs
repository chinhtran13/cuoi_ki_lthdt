using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace quan_ly_ban_hang
{
    public partial class Form5 : Form
    {

        QLYcuahangEntities db = new QLYcuahangEntities();
        List<HoaDon> dsHoadon = new List<HoaDon>();
        List<CTHD> dscthd = new List<CTHD>();
        HoaDon hd = null;
        CTHD cthd = null;
        public Form5()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            dsHoadon = db.HoaDons.ToList();
            dscthd = db.CTHDs.ToList();

            dataGridView1.Columns.Add("MaHD", "Mã Hoá Đơn");
            dataGridView1.Columns.Add("MaSP", "Mã Sản Phẩm");
            dataGridView1.Columns.Add("SL", "Số lượng");
            dataGridView1.Columns.Add("DonGia", "Đơn Giá");
            dataGridView1.Columns.Add("Tong Tien", "Tổng Tiền");



            dataGridView2.Columns.Add("MaHD", "Mã Hoá Đơn");
            dataGridView2.Columns.Add("NgayTao", "Ngày Tạo");
            dataGridView2.Columns.Add("SDT", "Số ĐT");
            dataGridView2.Columns.Add("MaNV", "Mã Nhân Viên");
            dataGridView2.Columns.Add("MaKM", "Mã Khuyến Mãi");
            dataGridView2.Columns.Add("TrangThai", "Chi Tiết Hoá Đơn");

            dtgridview2load();


        }
        void dtgridview2load()
        {
            List<HoaDon> hoadon = db.HoaDons.ToList();
            // Clear existing rows in dataGridView2

            foreach (HoaDon a in dsHoadon)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(dataGridView2);
                row.Cells[0].Value = a.MaHD + "";
                row.Cells[1].Value = a.NgayTao;
                row.Cells[2].Value = a.SDT;
                row.Cells[3].Value = a.MaNV;
                row.Cells[4].Value = a.MaKM;
                row.Cells[5].Value = a.TrangThai;
                dataGridView2.Rows.Add(row);
            }
            
        }

        void dtgridview1load()
        {
            // Clear existing rows in dataGridView1
            dataGridView1.Rows.Clear();


            List<CTHD> filteredCTHDs = dscthd.Where(ct => ct.MaHD == hd.MaHD).ToList();
            foreach (CTHD a in filteredCTHDs)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(dataGridView1);
                row.Cells[0].Value = a.MaHD + "";
                row.Cells[1].Value = a.MaSP;
                row.Cells[2].Value = a.SL;
                row.Cells[3].Value = a.DonGia + " VNĐ";
                row.Cells[4].Value = a.TongTien + " VNĐ";
                dataGridView1.Rows.Add(row);
            }
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1.Rows.Clear();
            DataGridViewRow row = dataGridView2.CurrentRow;
            int index = row.Index;

            if (index >= dsHoadon.Count) return;

            hd = dsHoadon[index];
            cthd = dscthd.FirstOrDefault(ct => ct.MaHD == hd.MaHD);

            if (cthd != null)
            {
                // Nếu tìm thấy CTHD với MaHD giống với hd.MaHD, hiển thị lên dataGridView1
                dtgridview1load();
                
            }
            else
            {
                // Nếu không tìm thấy CTHD tương ứng, có thể thông báo hoặc xử lý theo ý bạn
                MessageBox.Show("Không tìm thấy chi tiết hóa đơn tương ứng.");
            }


            
        }
        private void txtTimHD_TextChanged(object sender, EventArgs e)
        {
            string value = txtTimHD.Text.ToLower(); // Chuyển giá trị nhập về chữ thường để không phân biệt in hoa

            foreach (DataGridViewRow row in dataGridView2.Rows)
            {
                if (row.Cells["MaHD"].Value != null)
                {
                    string maHD = row.Cells["MaHD"].Value.ToString().ToLower(); // Chuyển giá trị MaHD về chữ thường

                    // So sánh giá trị nhập với MaHD, nếu không khớp thì ẩn row đó
                    if (!maHD.StartsWith(value))
                    {
                        row.Visible = false;
                    }
                    else
                    {
                        row.Visible = true;
                    }
                }
            }
        }

    }
}
