using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace quan_ly_ban_hang
{
    public partial class Form3 : Form
    {
        List<SanPham> dsDoAn = new List<SanPham>();
        Form1 mainForm;
        QLYcuahangEntities db = new QLYcuahangEntities();
        CTHD chitietHD = new CTHD();
        HoaDon hoaDon;
        HoaDon active_HD;
        SanPham doAn;
        public Form3(HoaDon active, Form1 mainForm)
        {
            active_HD = active;
            InitializeComponent();
            this.mainForm = mainForm;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form_Update_Search();
        }
        DataGridViewRow SelectRow;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            SelectRow = gridViewDoAn.Rows[e.RowIndex];
            foreach(SanPham item in dsDoAn)
            {
                if(item.MaSP == SelectRow.Cells["IdDoAn"].Value)
                {
                    doAn = item;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            hoaDon =active_HD;
            foreach (SanPham sanPham in db.SanPhams)
            {
                if (sanPham.LoaiSP == "Do An")
                {
                    dsDoAn.Add(sanPham);
                }
            }
            gridViewDoAn.Columns.Add("IdDoAn", "Mã Đồ Ăn");
            gridViewDoAn.Columns.Add("TenDoAn", "Tên Đồ Ăn");
            gridViewDoAn.Columns.Add("SoLuongDoAn", "Số Lượng");
            gridViewDoAn.Columns.Add("GiaDoAn", " Giá Tiền");
            foreach (SanPham sanPham in dsDoAn)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(gridViewDoAn);
                row.Cells[0].Value = sanPham.MaSP;
                row.Cells[1].Value = sanPham.TenSP;
                row.Cells[2].Value =    sanPham.SoLuong;
                row.Cells[3].Value = sanPham.Gia;
                gridViewDoAn.Rows.Add(row);
            }

        }
        private void Form_Update_Search()
        {
            dsDoAn = new List<SanPham>();
            if(gridViewDoAn.Rows.Count > 0)
            {
                gridViewDoAn.Rows.Clear();
            }
            
            foreach (SanPham sanPham in db.SanPhams)
            {
                if(sanPham.LoaiSP == "Do An" & sanPham.TenSP.ToLower().StartsWith(textBox1.Text.ToLower()))
                {
                    dsDoAn.Add(sanPham);
                }
            }
            foreach (SanPham sanPham in dsDoAn)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(gridViewDoAn);
                row.Cells[0].Value = sanPham.MaSP;
                row.Cells[1].Value = sanPham.TenSP;
                row.Cells[2].Value =    sanPham.SoLuong;
                row.Cells[3].Value =    sanPham.Gia;
                gridViewDoAn.Rows.Add(row);
            }
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Form_Update_Search();
        }
        private void Form_Update()
        {
            dsDoAn = new List<SanPham>();
            if (gridViewDoAn.Rows.Count > 0)
            {
                gridViewDoAn.Rows.Clear();
            }

            foreach (SanPham sanPham in db.SanPhams)
            {
                if (sanPham.LoaiSP == "Do An" & sanPham.SoLuong >0)
                {
                    dsDoAn.Add(sanPham);
                }
            }
            foreach (SanPham sanPham in dsDoAn)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(gridViewDoAn);
                row.Cells[0].Value = sanPham.MaSP;
                row.Cells[1].Value = sanPham.TenSP;
                row.Cells[2].Value = sanPham.SoLuong;
                row.Cells[3].Value = sanPham.Gia;
                gridViewDoAn.Rows.Add(row);
            }
        }
        private void btn_Them_Click(object sender, EventArgs e)
        {
            chitietHD = new CTHD();
            bool isExist = false;
            chitietHD.HoaDon = active_HD;
            foreach(CTHD cthd in active_HD.CTHDs) 
            {
                if(cthd.SanPham.MaSP == doAn.MaSP)
                {
                    cthd.SL += 1;
                   
                    foreach(SanPham item in db.SanPhams)
                    {
                        if(item.MaSP == cthd.SanPham.MaSP)
                        {
                            item.SoLuong += 1;
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
                chitietHD.SanPham = doAn;
                chitietHD.MaHD = chitietHD.HoaDon.MaHD;
                chitietHD.MaSP = chitietHD.SanPham.MaSP;
                chitietHD.DonGia = chitietHD.SanPham.Gia;
                chitietHD.SL = 1;
                chitietHD.TongTien = chitietHD.DonGia * chitietHD.SL;
                foreach (SanPham item in db.SanPhams)
                {
                    if (item.MaSP == chitietHD.SanPham.MaSP)
                    {
                        item.SoLuong += 1;
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
