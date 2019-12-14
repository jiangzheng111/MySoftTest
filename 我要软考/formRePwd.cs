using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BLL;
using 我要软考;

namespace UI
{
    public partial class formRePwd : Form
    {
        public formRePwd()
        {
            InitializeComponent();
        }

        private void formRePwd_Load(object sender, EventArgs e)
        {
            txtEmail.Text = "邮箱";
            txtPwd.Text = "密码";
            txtCode.Text = "验证码";
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is TextBox)
                {
                    ctrl.ForeColor = Color.FromArgb(193, 193, 193);
                }
            }
        }
        private void txtPwd_MouseClick(object sender, MouseEventArgs e)
        {

            txtPwd.PasswordChar = '●';
            txtPwd.Text = null;
            txtPwd.ForeColor = Color.Black;

        }

        private void txtEmail_MouseClick(object sender, MouseEventArgs e)
        {
            txtEmail.Text = null;
            txtEmail.ForeColor = Color.Black;
        }
        private void txtCode_MouseClick(object sender, MouseEventArgs e)
        {
            txtCode.Text = null;
            txtCode.ForeColor = Color.Black;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var thisemailFormat = bll.emailFormat(txtEmail.Text.ToString().Trim());
            if (txtEmail.Text == string.Empty || txtPwd.Text == string.Empty || txtCode.Text == string.Empty || thisemailFormat == MODEL.TextString.emailCode)
            {
                MessageBox.Show(thisemailFormat);
                return;
            }
            var email = bll.emailFormat(txtEmail.Text.ToString().Trim());
            if (email == MODEL.TextString.emailError)
            {
                MessageBox.Show(email);
                return;
            }
            if (!isLinkGet)
            {
                var emailTheme = MODEL.TextString.updateTheme;
                myTool.sendEmail sendEmail = new myTool.sendEmail();
                myTool.sendEmail.randomCode();
                var statcEmail = sendEmail.sendemail(txtEmail.Text, txtCode.Text, emailTheme);
                timer1.Enabled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var stringMsg = bll.updatePwd(txtEmail.Text.ToString().Trim(),
                txtCode.Text.ToString().Trim(),
                txtPwd.Text.ToString().Trim());
            MessageBox.Show(stringMsg);
            if (stringMsg == MODEL.TextString.updateSuccessful)
            {
                button1.Text = "返回登录";
                formLogin formlogin = new formLogin();
                formlogin.Show();
                this.Hide();
            }
        }

        int i = 60;//一分钟
        bool isLinkGet = false;//判断btnGet是否被点击过
        private void timer1_Tick(object sender, EventArgs e)
        {
            i--;
            linkGet.Text = i.ToString() + "s";
            if (i == 0)
            {
                timer1.Enabled = false;
                linkGet.Text = "获取";
                isLinkGet = false;
                i = 60;
            }
        }

        Point mouseOff;//鼠标移动位置变量
        bool leftFlag;//标记是否为左键
        private void Login_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                mouseOff = new Point(-e.X, -e.Y); //得到变量的值
                leftFlag = true;                  //点击左键按下时标注为true;
            }
        }
        private void Login_MouseMove(object sender, MouseEventArgs e)
        {
            if (leftFlag)
            {
                Point mouseSet = Control.MousePosition;
                mouseSet.Offset(mouseOff.X, mouseOff.Y);  //设置移动后的位置
                Location = mouseSet;
            }
        }
        private void Login_MouseUp(object sender, MouseEventArgs e)
        {
            if (leftFlag)
            {
                leftFlag = false;//释放鼠标后标注为false;
            }
        }

        private void miN_MAX_EXIT1_Load(object sender, EventArgs e)
        {
            miN_MAX_EXIT1.btnMax.Enabled = false;
        }
    }
}
