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
    public partial class Form4 : Form
    {
        List<SanPham> dsDoUong = new List<SanPham>();
        CTHD chitietHD = new CTHD();
        Form1 mainForm;
        HoaDon hoaDon;
        HoaDon active_HD;
        QLYcuahangEntities2 db = new QLYcuahangEntities2();
        SanPham doUong = null;
        public Form4()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void Form_Update_Search()
        {
            dsDoUong = new List<SanPham>();
            if (gridDoUong.Rows.Count > 0)
            {
                gridDoUong.Rows.Clear();
            }
            foreach (SanPham sanPham in db.SanPhams)
            {
                if (sanPham.LoaiSP == "Do Uong" & sanPham.TenSP.ToLower().StartsWith(textBox1.Text.ToLower()))
                {
                    dsDoUong.Add(sanPham);
                }
            }
            gridDoUong.Columns.Add("IdDoUong", "Mã Đồ Uống");
            gridDoUong.Columns.Add("TenDoUong", "Tên Đồ Uống");
            gridDoUong.Columns.Add("SoLuongDoUong", "Số Lượng");
            gridDoUong.Columns.Add("GiaDoUong", " Giá Tiền");
            foreach (SanPham sanPham in dsDoUong)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(gridDoUong);
                row.Cells[0].Value = sanPham.MaSP + "";
                row.Cells[1].Value = sanPham.TenSP + "";
                row.Cells[2].Value = sanPham.SoLuong + "";
                row.Cells[3].Value = sanPham.Gia + "";
                gridDoUong.Rows.Add(row);
            }
        }
        private void Form4_Load(object sender, EventArgs e)
        {
            hoaDon = db.HoaDons.Last();
            foreach (SanPham sanPham in db.SanPhams)
            {
                if (sanPham.LoaiSP == "Do Uong")
                {
                    dsDoUong.Add(sanPham);
                }
            }
            gridDoUong.Columns.Add("IdDoUong", "Mã Đồ Uống");
            gridDoUong.Columns.Add("TenDoUong", "Tên Đồ Uống");
            gridDoUong.Columns.Add("SoLuongDoUong", "Số Lượng");
            gridDoUong.Columns.Add("GiaDoUong", " Giá Tiền");
            foreach (SanPham sanPham in dsDoUong)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(gridDoUong);
                row.Cells[0].Value = sanPham.MaSP + "";
                row.Cells[1].Value = sanPham.TenSP + "";
                row.Cells[2].Value = sanPham.SoLuong + "";
                row.Cells[3].Value = sanPham.Gia + "";
                gridDoUong.Rows.Add(row);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form_Update_Search();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Form_Update_Search();
        }
    }
}
