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

        QLYcuahangEntities db = new QLYcuahangEntities();
        SanPham doUong = null;
        public Form4()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
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
            gridDoUong.Columns.Add("IdDoAn", "Mã Đồ Ăn");
            gridDoUong.Columns.Add("TenDoAn", "Tên Đồ Ăn");
            gridDoUong.Columns.Add("SoLuongDoAn", "Số Lượng");
            gridDoUong.Columns.Add("GiaDoAn", " Giá Tiền");
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
    }
}
