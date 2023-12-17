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
        QLYcuahangEntities db = new QLYcuahangEntities();
        SanPham doUong = null;
        public Form4(HoaDon active, Form1 mainForm)
        {
            active_HD = active;
            InitializeComponent();
            this.mainForm = mainForm;
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
        DataGridViewRow SelectRow;
        private void gridDoUong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            SelectRow = gridDoUong.Rows[e.RowIndex];
            foreach (SanPham item in dsDoUong)
            {
                if (item.MaSP == SelectRow.Cells["IdDoUong"].Value)
                {
                    doUong = item;
                }
            }
        }
        private void Form_Update()
        {
            dsDoUong = new List<SanPham>();
            if (gridDoUong.Rows.Count > 0)
            {
                gridDoUong.Rows.Clear();
            }

            foreach (SanPham sanPham in db.SanPhams)
            {
                if (sanPham.LoaiSP == "Do Uong" & sanPham.SoLuong > 0)
                {
                    dsDoUong.Add(sanPham);
                }
            }
            foreach (SanPham sanPham in dsDoUong)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(gridDoUong);
                row.Cells[0].Value = sanPham.MaSP;
                row.Cells[1].Value = sanPham.TenSP;
                row.Cells[2].Value = sanPham.SoLuong;
                row.Cells[3].Value = sanPham.Gia;
                gridDoUong.Rows.Add(row);
            }
        }
        private void btn_Them_Click(object sender, EventArgs e)
        {
            chitietHD = new CTHD();
            bool isExist = false;
            foreach (CTHD cthd in active_HD.CTHDs)
            {
                if (cthd.MaSP == doUong.MaSP)
                {
                    cthd.SL += 1;

                    foreach (SanPham item in db.SanPhams)
                    {
                        if (item.MaSP == cthd.SanPham.MaSP)
                        {
                            item.SoLuong -= 1;
                        }
                    }
                    mainForm.Form_Update();
                    Form_Update();
                    db.SaveChanges();
                    isExist = true;
                }
            }
            if (!isExist)
            {
                chitietHD.MaHD = active_HD.MaHD;
                chitietHD.MaSP = doUong.MaSP;
                chitietHD.DonGia = doUong.Gia;
                chitietHD.SL = 1;
                chitietHD.TongTien = chitietHD.DonGia * chitietHD.SL;
                foreach (SanPham item in db.SanPhams)
                {
                    if (item.MaSP == doUong.MaSP)
                    {
                        item.SoLuong -= 1;
                    }
                }
                active_HD.CTHDs.Add(chitietHD);
                mainForm.Form_Update();
                Form_Update();
                db.SaveChanges();
            }
        }
    }
}
