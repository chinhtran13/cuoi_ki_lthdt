using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace quan_ly_ban_hang
{
    public partial class Form6 : Form
    {
        QLYcuahangEntities db = new QLYcuahangEntities();
        List<KhuyenMai> dsKM = new List<KhuyenMai>();
        KhuyenMai km = null;
        public Form6()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            dsKM = db.KhuyenMais.ToList();

            dataGridView1.Columns.Add("MaKM", "Mã Khuyến Mãi");
            dataGridView1.Columns.Add("LoaiKM", "Loại Khuyến Mãi");
            dataGridView1.Columns.Add("NgayBatDau", "Ngày Bắt Đầu");
            dataGridView1.Columns.Add("NgayKetThuc", "Ngày Kết Thúc");
            dataGridView1.Columns.Add("ComboKM", "Combo Khuyến Mãi");
            dataGridView1.Columns.Add("PhanTramGiam", "Phần Trăm Giảm");

            dtgridviewload();
            DateTime d = DateTime.Now;
            txtMaKM.Text = "KM" + d.ToString("yyMMddHHmmss");

            comboBox1.Visible = false;
            lblCombo.Visible = false;

            List<SanPham> dsSP = db.SanPhams.ToList();
            comboBox1.DataSource = dsSP;
            comboBox1.DisplayMember = "TenSP";
        }
        void dtgridviewload()
        {
            foreach (KhuyenMai a in dsKM)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(dataGridView1);
                row.Cells[0].Value = a.MaKM + "";
                row.Cells[1].Value = a.LoaiKM;
                row.Cells[2].Value = a.NgayBatDau;
                row.Cells[3].Value = a.NgayKetThuc;
                row.Cells[4].Value = a.ComboKM;
                row.Cells[5].Value = a.PhanTramGiam + "%";

                // Thêm dòng mới vào dataGridView1
                dataGridView1.Rows.Add(row);
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaKM.Text) || string.IsNullOrWhiteSpace(txtMaKM.Text)) return;
            string makm = txtMaKM.Text;
            List<KhuyenMai> list = dsKM.Where(t => t.MaKM == makm).ToList();
            if (list.Count > 0)
            {
                MessageBox.Show("Khuyến mãi này đã có. Vui lòng kiểm tra lại mã");
                return;
            }
            KhuyenMai km = new KhuyenMai();
            km.MaKM = makm;
            km.NgayBatDau = dateTimePicker2.Value;
            km.NgayKetThuc = dateTimePicker1.Value;
            if (rdbtnNgay.Checked)
            {
                km.LoaiKM = "Ngay";
                km.PhanTramGiam = 30;
            }
            else if (rdbtnCombo.Checked)
            {
                km.LoaiKM = "Combo";
                km.PhanTramGiam = 50;
            }
            km.ComboKM = comboBox1.Text;
            dsKM.Add(km);



            db.KhuyenMais.Add(km);
            db.SaveChanges();

            dtgridviewload();
            DateTime d = DateTime.Now;
            txtMaKM.Text = "KM" + d.ToString("yyMMddHHmmss");

            dataGridView1.Rows.Clear();
            dtgridviewload();
        }

        private void rdbtnCombo_CheckedChanged(object sender, EventArgs e)
        {
            comboBox1.Visible = true;
            lblCombo.Visible = true;
        }

        private void rdbtnNgay_CheckedChanged(object sender, EventArgs e)
        {
            comboBox1.Visible = false;
            lblCombo.Visible = false;
            comboBox1.Text = "";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string value = txtTimKM.Text.ToLower();

            foreach(DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells["MaKM"].Value != null)
                {
                    string maKM = row.Cells["MaKM"].Value.ToString().ToLower(); // Chuyển giá trị MaHD về chữ thường

                    // So sánh giá trị nhập với MaHD, nếu không khớp thì ẩn row đó
                    if (!maKM.StartsWith(value))
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
