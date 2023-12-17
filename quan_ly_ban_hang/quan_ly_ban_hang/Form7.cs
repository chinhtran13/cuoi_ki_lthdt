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
        QLYcuahangEntities2 db = new QLYcuahangEntities2();
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
            //xoa het
            dataGridViewDoAn.Rows.Clear();

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
        private void btnThem_Click_1(object sender, EventArgs e)
        {
            //kiểm tra chỉ cho add 1 dòng
            if (!(sanPham is null) && sanPham.MaSP == string.Format(txtMaSP.Text.Trim())) return;

            //Kiểm tra dữ liệu trển form
            if (string.IsNullOrEmpty(txtMaSP.Text) || string.IsNullOrWhiteSpace(txtMaSP.Text)) return;
            if (string.IsNullOrEmpty(txtTenSP.Text) || string.IsNullOrWhiteSpace(txtTenSP.Text)) return;
            if (int.Parse(txtSoLuong.Text) < 0) return;
            if (double.Parse(txtDonGia.Text) < 0) return;

            //Kiểm tra du lieu đã có hay chưa
            string masp = txtMaSP.Text;
            string tensp = txtTenSP.Text;
            List<SanPham> list = dsSanPham.Where(t => t.MaSP == masp || t.TenSP == tensp).ToList();
            if (list.Count > 0)
            {
                MessageBox.Show("Đã bị trùng dữ liệu mã sản phẩm hoặc tên sản phẩm");
                return;
            }

            //xl them
            sanPham = new SanPham();
            sanPham.MaSP = masp;
            sanPham.TenSP = tensp;
            sanPham.SoLuong = int.Parse(txtSoLuong.Text);
            sanPham.Gia = double.Parse(txtDonGia.Text);
            if (comboBoxLoaiSP.SelectedIndex == 0)
                sanPham.LoaiSP = "Do An";
            else sanPham.LoaiSP = "Do Uong";

            //thêm vào ds loai sach
            dsSanPham.Add(sanPham);

            //thêm vào lưới
            DataGridViewRow row = new DataGridViewRow();
            if (comboBoxLoaiSP.SelectedIndex == 0)
            {
                row.CreateCells(dataGridViewDoAn);
                row.Cells[0].Value = masp;
                row.Cells[1].Value = tensp;
                row.Cells[2].Value = int.Parse(txtSoLuong.Text);
                row.Cells[3].Value = double.Parse(txtDonGia.Text);
                dataGridViewDoAn.Rows.Add(row);
            }
            //thêm vào database
            db.SanPhams.Add(sanPham);
            //luu thay doi
            db.SaveChanges();
        }

        private void btnSua_Click_1(object sender, EventArgs e)
        {
            //xem san pham co ton tai hay khong
            if (sanPham == null) return;
            //kiem tra xem ma san pham co thay doi khong
            if (txtMaSP.Text.Trim() != sanPham.MaSP)
            {
                MessageBox.Show("Không thể sửa đổi mã sản phẩm.");
                return;
            }

            //ktra ten san pham co ton tai chua
            string tensp = txtTenSP.Text.Trim();
            List<SanPham> x = dsSanPham.Where(a => a.TenSP == tensp).ToList();
            if (x.Count > 0)
            {
                MessageBox.Show("có rồi, tên khác đi");
                return;
            }
            //cap nhat ten moi
            sanPham.TenSP = txtTenSP.Text;
            sanPham.SoLuong = int.Parse(txtSoLuong.Text);
            sanPham.Gia = float.Parse(txtDonGia.Text);
            //luu thay doi
            db.SaveChanges();
            //load lai datagridview
            loadDataSanPham(dsSanPham);
        }

        private void btnXoa_Click_1(object sender, EventArgs e)
        {
            //kiểm tra còn dòng nào ko
            if (dsSanPham.Count == 0) return;
            //lấy dòng hiện tại
            DataGridViewRow row = dataGridViewDoAn.CurrentRow;
            //ktra xem co click vao dong nao khong
            if (row == null) return;
            //lấy chỉ số của dòng đang chọn
            int id = row.Index;
            //ktra xem co hop ly khong
            if (dsSanPham.Count == 0 || id >= dsSanPham.Count) return;
            //xoa khoi danh sach
            dsSanPham.RemoveAt(id);
            //xoa khoi datagridview
            dataGridViewDoAn.Rows.RemoveAt(id);
            //xoa khoi co so du lieu
            db.SanPhams.Remove(sanPham);
            //luu thay doi
            db.SaveChanges();
        }

        private void Form7_Load(object sender, EventArgs e)
        {
            //mac dinh comboBox
            comboBoxLoaiSP.SelectedIndex = 0;
            //lay danh sach san pham
            dsSanPham = db.SanPhams.ToList();
            //hien thi tren datagridview
            loadDataSanPham(dsSanPham);
            //hien thong tin len cac text khi click vao
            if (sanPham != null)
            {
                loadTTDoAn();
                loadTTDoUong();
            }
        }

        private void dataGridViewThucUong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //lấy dòng hiện tại
            DataGridViewRow row = dataGridViewDoAn.CurrentRow;
            // lấy chỉ số của dòng đang chọn
            int id = row.Index;
            if (id >= dsSanPham.Count) return;
            // lấy sản phẩm tương ứng trong danh sách sản phẩm
            sanPham = dsSanPham.ElementAt(id);
            txtMaSP.Text = sanPham.MaSP.ToString();
            txtTenSP.Text = sanPham.TenSP;
            txtSoLuong.Text = sanPham.SoLuong.ToString();
            txtDonGia.Text = sanPham.Gia.ToString();
            // hiển thị thông tin lên trên các box
            txtMaSP.Text = sanPham.MaSP.ToString();
            txtTenSP.Text = sanPham.TenSP;
            txtSoLuong.Text = sanPham.SoLuong.ToString();
            txtDonGia.Text = sanPham.Gia.ToString();
        }

        private void dataGridViewDoAn_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            //lấy dòng hiện tại
            DataGridViewRow row = dataGridViewDoAn.CurrentRow;
            // lấy chỉ số của dòng đang chọn
            int id = row.Index;
            if (id >= dsSanPham.Count) return;
            // lấy sản phẩm tương ứng trong danh sách sản phẩm
            sanPham = dsSanPham.ElementAt(id);
            txtMaSP.Text = sanPham.MaSP.ToString();
            txtTenSP.Text = sanPham.TenSP;
            txtSoLuong.Text = sanPham.SoLuong.ToString();
            txtDonGia.Text = sanPham.Gia.ToString();
            // hiển thị thông tin lên trên các box
            txtMaSP.Text = sanPham.MaSP.ToString();
            txtTenSP.Text = sanPham.TenSP;
            txtSoLuong.Text = sanPham.SoLuong.ToString();
            txtDonGia.Text = sanPham.Gia.ToString();
        }
    }
}
