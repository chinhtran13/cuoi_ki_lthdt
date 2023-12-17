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
    public partial class Form1 : Form
    {
        QLYcuahangEntities db = new QLYcuahangEntities();
        public HoaDon activeHD;
        List<HoaDon> dsHoaDon;
        Form2 form2 = new Form2();
        Form3 form3;
        Form4 form4;
        public Form1()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button4 = new System.Windows.Forms.Button();
            this.btn_Xoa_All = new System.Windows.Forms.Button();
            this.lbl_TongSauKM = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lbl_Tong = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btn_Xoa = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Teal;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Location = new System.Drawing.Point(2, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(918, 103);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(101, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(129, 39);
            this.label1.TabIndex = 1;
            this.label1.Text = "Nhân Viên";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(798, 29);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(91, 39);
            this.button1.TabIndex = 0;
            this.button1.Text = "Menu";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.PaleTurquoise;
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.textBox1);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.button3);
            this.panel2.Controls.Add(this.button2);
            this.panel2.Location = new System.Drawing.Point(1, 107);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(185, 604);
            this.panel2.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(11, 503);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(163, 23);
            this.label7.TabIndex = 4;
            this.label7.Text = "Nhập Số ĐT Khách Hàng";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(11, 534);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(163, 26);
            this.textBox1.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label2.Location = new System.Drawing.Point(31, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(123, 23);
            this.label2.TabIndex = 2;
            this.label2.Text = "Thêm Sản Phẩm";
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(11, 105);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(163, 44);
            this.button3.TabIndex = 1;
            this.button3.Text = "THỨC UỐNG";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(11, 52);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(163, 44);
            this.button2.TabIndex = 0;
            this.button2.Text = "ĐỒ ĂN";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.Color.PaleTurquoise;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4});
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle8;
            this.dataGridView1.GridColor = System.Drawing.Color.Teal;
            this.dataGridView1.Location = new System.Drawing.Point(451, 107);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(465, 484);
            this.dataGridView1.TabIndex = 2;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Mã Sản Phẩm";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Tên Sản Phẩm";
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Số lượng";
            this.Column3.Name = "Column3";
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Đơn Giá";
            this.Column4.Name = "Column4";
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.LightSeaGreen;
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button4.Location = new System.Drawing.Point(710, 644);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(199, 58);
            this.button4.TabIndex = 3;
            this.button4.Text = "Thanh Toán";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // btn_Xoa_All
            // 
            this.btn_Xoa_All.Location = new System.Drawing.Point(797, 610);
            this.btn_Xoa_All.Name = "btn_Xoa_All";
            this.btn_Xoa_All.Size = new System.Drawing.Size(70, 28);
            this.btn_Xoa_All.TabIndex = 5;
            this.btn_Xoa_All.Text = "Xoá tất cả";
            this.btn_Xoa_All.UseVisualStyleBackColor = true;
            this.btn_Xoa_All.Click += new System.EventHandler(this.btn_Xoa_All_Click);
            // 
            // lbl_TongSauKM
            // 
            this.lbl_TongSauKM.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_TongSauKM.Location = new System.Drawing.Point(451, 661);
            this.lbl_TongSauKM.Name = "lbl_TongSauKM";
            this.lbl_TongSauKM.Size = new System.Drawing.Size(252, 41);
            this.lbl_TongSauKM.TabIndex = 6;
            this.lbl_TongSauKM.Text = "0";
            this.lbl_TongSauKM.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Teal;
            this.label4.Location = new System.Drawing.Point(447, 641);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(223, 20);
            this.label4.TabIndex = 12;
            this.label4.Text = "Tổng tiền sau khuyến mãi: ";
            // 
            // lbl_Tong
            // 
            this.lbl_Tong.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Tong.Location = new System.Drawing.Point(537, 610);
            this.lbl_Tong.Name = "lbl_Tong";
            this.lbl_Tong.Size = new System.Drawing.Size(167, 23);
            this.lbl_Tong.TabIndex = 13;
            this.lbl_Tong.Text = "0";
            this.lbl_Tong.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(447, 594);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(93, 20);
            this.label6.TabIndex = 8;
            this.label6.Text = "Tổng Tiền:";
            // 
            // btn_Xoa
            // 
            this.btn_Xoa.Location = new System.Drawing.Point(873, 610);
            this.btn_Xoa.Name = "btn_Xoa";
            this.btn_Xoa.Size = new System.Drawing.Size(36, 28);
            this.btn_Xoa.TabIndex = 14;
            this.btn_Xoa.Text = "Xoá";
            this.btn_Xoa.UseVisualStyleBackColor = true;
            this.btn_Xoa.Click += new System.EventHandler(this.button7_Click);
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(959, 723);
            this.Controls.Add(this.btn_Xoa);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lbl_Tong);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lbl_TongSauKM);
            this.Controls.Add(this.btn_Xoa_All);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "Form1";
            this.Text = "Trang Chủ";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void button7_Click(object sender, EventArgs e)
        {
            foreach(CTHD cthd in activeHD.CTHDs)
            {
                if(cthd.MaSP == SelectRow.Cells[0].Value)
                {
                    activeHD.CTHDs.Remove(cthd);
                    Form_Update();
                    break;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            form2.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            form3 = new Form3(activeHD,this);
            form3.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            form4 = new Form4(activeHD,this);
            form4.ShowDialog();
        }

        DataGridViewRow SelectRow;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            SelectRow = dataGridView1.Rows[e.RowIndex];
        }

        public void Form_Update()
        {
            dataGridView1.Rows.Clear();
                foreach (CTHD cthd in activeHD.CTHDs)
                {
                cthd.TongTien = cthd.DonGia * cthd.SL;
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(dataGridView1);
                row.Cells[0].Value = cthd.MaSP;
                foreach (SanPham item in db.SanPhams)
                {
                    if (item.MaSP == cthd.MaSP)
                    {
                        row.Cells[1].Value = item.TenSP;
                    }
                }

                row.Cells[2].Value = cthd.SL;
                row.Cells[3].Value = cthd.TongTien;
                dataGridView1.Rows.Add(row);
                }
            double sumtrc_KM = 0, sumsau_KM = 0;
                foreach(CTHD cthd in activeHD.CTHDs)
                {
                sumtrc_KM += cthd.TongTien;
                }
            double phanTramKM = 0;
            lbl_Tong.Text = sumtrc_KM.ToString();
            foreach(KhuyenMai Km in db.KhuyenMais)
            {
                if(Km.NgayBatDau.Year <= DateTime.UtcNow.Year & Km.NgayKetThuc.Year >= DateTime.UtcNow.Year)
                {
                    if(Km.NgayBatDau.Year != DateTime.UtcNow.Year & Km.NgayKetThuc.Year != DateTime.UtcNow.Year)
                    {
                        phanTramKM += Km.PhanTramGiam;
                        activeHD.KhuyenMai = Km;
                        break;
                    }
                    if(Km.NgayBatDau.Month <= DateTime.UtcNow.Month & Km.NgayKetThuc.Month >= DateTime.UtcNow.Month)
                    {
                        if(Km.NgayBatDau.Month != DateTime.UtcNow.Month & Km.NgayKetThuc.Month != DateTime.UtcNow.Month)
                        {
                            phanTramKM += Km.PhanTramGiam;
                            activeHD.KhuyenMai = Km;
                            break;
                        }
                        if(Km.NgayBatDau.Day <= DateTime.UtcNow.Day & Km.NgayKetThuc.Day >= DateTime.UtcNow.Day)
                        {
                            phanTramKM += Km.PhanTramGiam;
                            activeHD.KhuyenMai = Km;
                            break;
                        }
                    }
                }
            }
            lbl_TongSauKM.Text = (sumtrc_KM - (sumtrc_KM * (phanTramKM/100))).ToString();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dsHoaDon = db.HoaDons.ToList();
            new_HD();
            foreach (CTHD cthd in activeHD.CTHDs)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(dataGridView1);
                row.Cells[0].Value = cthd.MaSP;
                foreach(SanPham item in db.SanPhams)
                {
                    if(item.MaSP == cthd.MaSP)
                    {
                        row.Cells[1].Value = item.TenSP;
                    }
                }
               
                row.Cells[2].Value = cthd.SL;
                row.Cells[3].Value = cthd.SanPham.Gia * cthd.SL;
                dataGridView1.Rows.Add(row);
            }
        }
        private void new_HD()
        {
            if (dsHoaDon.Count <= 0)
            {
                activeHD = new HoaDon();
                activeHD.MaHD = "HD1";
                activeHD.NgayTao = DateTime.UtcNow;
            }
            else
            {
                activeHD = new HoaDon();
                activeHD.MaHD = "HD" + (db.HoaDons.Count() + 1).ToString();
                activeHD.NgayTao = DateTime.UtcNow;

            }
        }
        private void btn_Xoa_All_Click(object sender, EventArgs e)
        {
            activeHD.CTHDs.Clear();
            Form_Update();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            HoaDon addHoaDon = new HoaDon();
            addHoaDon.MaKM = activeHD.MaKM;
            addHoaDon.MaHD = activeHD.MaHD;
            addHoaDon.MaNV = "NV1";
            foreach(NhanVien nhanvien in db.NhanViens)
            {
                if(addHoaDon.MaNV == nhanvien.MaNV)
                {
                    addHoaDon.NhanVien = nhanvien;
                }
            }
            addHoaDon.NgayTao = activeHD.NgayTao;
            foreach(CTHD cthd in activeHD.CTHDs)
            {
                if(cthd.MaHD == addHoaDon.MaHD) 
                {
                    addHoaDon.CTHDs.Add(cthd);
                }
                
            }
            addHoaDon.TrangThai = "Chua Hoan Thanh";
            if (string.IsNullOrEmpty(textBox1.Text))
            {
               addHoaDon.SDT = "0987654321";
            }else
                addHoaDon.SDT = textBox1.Text;
            foreach(ThanhVien thanhvien in db.ThanhViens)
            {
                if(addHoaDon.SDT == thanhvien.SDTTV)
                {
                    addHoaDon.ThanhVien = thanhvien;
                }
            }
            db.HoaDons.Add(addHoaDon);
            db.SaveChanges();
            new_HD();
            Form_Update();
        }
    }
}
