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
    public partial class Form3 : Form
    {
        List<SanPham> dsDoAn = new List<SanPham>();

        QLYcuahangEntities db = new QLYcuahangEntities();
        SanPham doAn = null;
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
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
                row.Cells[0].Value = sanPham.MaSP + "";
                row.Cells[1].Value = sanPham.TenSP + "";
                row.Cells[2].Value = sanPham.SoLuong + "";
                row.Cells[3].Value = sanPham.Gia + "";
                gridViewDoAn.Rows.Add(row);
            }

        }
        private void Form_Update_Search()
        {
            foreach (SanPham sanPham in db.SanPhams)
            {
                if(sanPham.LoaiSP == "Do An" & sanPham.TenSP.StartsWith(textBox1.ToString()))
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
                row.Cells[0].Value = sanPham.MaSP + "";
                row.Cells[1].Value = sanPham.TenSP + "";
                row.Cells[2].Value = sanPham.SoLuong + "";
                row.Cells[3].Value = sanPham.Gia + "";
                gridViewDoAn.Rows.Add(row);
            }
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Form_Update_Search();
        }
    }
}
