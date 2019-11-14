using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Threading;
using 我要软考;

//要优化代码
namespace 我要软考
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();

        }
        private int btn_Click = 0; //标识是否点击
        Suser MySoftTest = null; //实例实体类
        private int SuserId = 0;
        private string suserName = string.Empty;
        private string suserPwd = string.Empty;

        //连接字符串字段
        private void btnLogin_Click(object sender, EventArgs e)
        {
           
            suserName = txtName.Text.ToString().Trim();
            suserPwd = txtPwd.Text.ToString().Trim();
            if (suserName == "" || suserPwd=="")
            {
                MessageBox.Show("请输入账号或密码！");
                return;
            }
            btn_Click = 1;
            sqlHerp sqlherp = new sqlHerp();
            string con = sqlherp.sqlcon();
            SqlConnection sqlcon = new SqlConnection(con);
            sqlcon.Open();
            using (SqlCommand sqlcmd = new SqlCommand("select * from Suser where SuserName =@susername and SuserPwd=@suserpwd", sqlcon))
            {
                sqlcmd.Parameters.AddWithValue("@susername", suserName);
                sqlcmd.Parameters.AddWithValue("@suserpwd", suserPwd);
                SqlDataReader dr = sqlcmd.ExecuteReader();
                if (dr.Read())
                {
                    if (MySoftTest == null)
                    {
                        MySoftTest = new Suser();
                    }
                    MySoftTest.SuserName = dr["SuserName"].ToString().Trim();
                    MySoftTest.SuserPwd = dr["SuserPwd"].ToString().Trim();
                    login_lbl();
                    My my = new My();
                    my.Show();
                }
                else
                {
                    MessageBox.Show("账号或密码错误!");
                    return;
                }
            }
            
            
            sqlcon.Close();

        }

        private void login_lbl()
        {
            label1.Visible = true;
            label1.Text = "正在连接服务器";
            if (btn_Click == 1)
            {
                for (int i = 1; i < 5; i++)
                {
                    Thread.Sleep(500);
                    Application.DoEvents();
                    label1.Text += " " + i.ToString();
                    Thread.Sleep(500);

                }
            }
            this.Hide();
            btn_Click = 0;
        }
    }
}
