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
    public partial class Form7 : Form
    {
        QLYcuahangEntities db = new QLYcuahangEntities();
        List<SanPham> dsSanPham = new List<SanPham>();
        SanPham sanPham = null;
        public Form7()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        void loadDataSanPham(List<SanPham> a)
        {
            dataGridViewDoAn.Columns.Add("MaSP", "Mã sản phẩm");
            dataGridViewDoAn.Columns.Add("TenSP", "Tên sản phẩm");
            dataGridViewDoAn.Columns.Add("Gia", "Giá");
            dataGridViewDoAn.Columns.Add("SoLuong", "Số lượng");
            foreach (SanPham b in a)
            {
                if (b.LoaiSP == "Do An")
                {
                    DataGridViewRow row = new DataGridViewRow();
                    row.CreateCells(dataGridViewDoAn);
                    row.Cells[0].Value = b.MaSP + "";
                    row.Cells[1].Value = b.TenSP + "";
                    row.Cells[2].Value = b.Gia;
                    row.Cells[3].Value = b.SoLuong;
                    dataGridViewDoAn.Rows.Add(row);
                }
                else
                {
                    DataGridViewRow row = new DataGridViewRow();
                    row.CreateCells(dataGridViewThucUong);
                    row.Cells[0].Value = b.MaSP + "";
                    row.Cells[1].Value = b.TenSP + "";
                    row.Cells[2].Value = b.Gia;
                    row.Cells[3].Value = b.SoLuong;
                    dataGridViewThucUong.Rows.Add(row);
                }
            }
        }
        void loadTTDoAn()
        {
            txtMaSP.Text = sanPham.MaSP + "";
            txtTenSP.Text = sanPham.TenSP + "";
            txtSoLuong.Text = sanPham.SoLuong + "";
            txtDonGia.Text = sanPham.Gia + "";
            comboBoxLoaiSP.SelectedIndex = 0;
        }
        void loadTTDoUong()
        {
            txtMaSP.Text = sanPham.MaSP + "";
            txtTenSP.Text = sanPham.TenSP + "";
            txtSoLuong.Text = sanPham.SoLuong + "";
            txtDonGia.Text = sanPham.Gia + "";
            comboBoxLoaiSP.SelectedIndex = 1;
        }

        private void Form7_Load(object sender, EventArgs e)
        {
            //lay danh sach san pham
            dsSanPham = db.SanPhams.ToList();
            //hien thi tren datagridview
            loadDataSanPham(dsSanPham);
            //hien thong tin len cac text khi click vao
            loadTTDoAn();
            loadTTDoUong();
        }
    }
}
