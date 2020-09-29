using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace BaiTapLon
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-TAH3T3C\SQLEXPRESS;Initial Catalog=QuanLyKhachSan;Integrated Security=True");
            try
            {
                conn.Open();
                string tk = txtUser.Text;
                string mk = txtPassword.Text;
                string sql = "SELECT * FROM TaiKhoan WHERE username='"+tk+"' AND password='"+mk+"'";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader dta = cmd.ExecuteReader();
                if (dta.Read()==true)
                {
                    MessageBox.Show("Đăng nhập thành công","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    new Form1().Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Tài khoản hoặc mật khẩu ko chính xách", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtUser.Clear();
                    txtPassword.Clear();
                    txtUser.Focus();
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show("Lỗi kết nối");
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
