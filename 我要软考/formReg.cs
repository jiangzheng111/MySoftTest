using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using BLL;
using 我要软考;

namespace UI
{
    public partial class formReg : Form
    {
        public formReg()
        {
            InitializeComponent();

        }
        //public BLL.bll bll = new BLL.bll();
        int i = 60;//一分钟
        bool isBtnGet = false;//判断btnGet是否被点击过
        string statcEmail = string.Empty;
        private void btnReg_Click(object sender, EventArgs e)
        {
            statcEmail = bll.insertUser(txtName.Text.ToString().Trim(), txtPwd.Text.ToString().Trim(), txtEmail.Text.ToString().Trim(), txtCode.Text.ToString().Trim());
            if (statcEmail == MODEL.TextString.emailSuccessful)
            {
                btnReg.Text = "返回登录";
                    formLogin formlogin = new formLogin();
                    formlogin.Show();
                    this.Hide();
            }

            MessageBox.Show(statcEmail, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void formReg_Load(object sender, EventArgs e)
        {

            btnReg.Enabled = false;
            txtName.Text = "昵称";
            txtPwd.Text = "密码";
            txtCode.Text = "邮箱验证码";
            txtEmail.Text = "邮箱";

            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is TextBox)
                {
                    ctrl.ForeColor = Color.FromArgb(193, 193, 193);
                }
            }
        }

        private void txtName_MouseClick(object sender, MouseEventArgs e)
        {
            txtName.Text = null;
            txtName.ForeColor = Color.Black;
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

        private void timer1_Tick(object sender, EventArgs e)
        {
            i--;
            linkGet.Text = i.ToString() + "s";
            if (i == 0)
            {
                timer1.Enabled = false;
                linkGet.Text = "获取";
                isBtnGet = false;
                i = 60;
            }
        }
        Point mouseOff;//鼠标移动位置变量
        bool leftFlag;//标记是否为左键
        private void Reg_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                mouseOff = new Point(-e.X, -e.Y); //得到变量的值
                leftFlag = true;                  //点击左键按下时标注为true;
            }
        }
        private void Reg_MouseMove(object sender, MouseEventArgs e)
        {
            if (leftFlag)
            {
                Point mouseSet = Control.MousePosition;
                mouseSet.Offset(mouseOff.X, mouseOff.Y);  //设置移动后的位置
                Location = mouseSet;
            }
        }
        private void Reg_MouseUp(object sender, MouseEventArgs e)
        {
            if (leftFlag)
            {
                leftFlag = false;//释放鼠标后标注为false;
            }
        }

        private void linkGet_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (bll.isEmpty(txtEmail.Text, txtCode.Text, txtName.Text))
            { MessageBox.Show(MODEL.TextString.empty); return; }
            var email = bll.emailFormat(txtEmail.Text.ToString().Trim());
            if (email == MODEL.TextString.emailError)
            {
                MessageBox.Show(email);
                return;
            } if (!isBtnGet)
            {
                MessageBox.Show("发送中");
                //var a=判断邮箱是否存在（邮箱）
                //存在则mbox（该邮箱已注册）return ，否则就执行下面的
                timer1.Enabled = true;
                btnReg.Enabled = true;
                var emailTheme = MODEL.TextString.insertTheme;
                myTool.sendEmail sendEmail = new myTool.sendEmail();
                myTool.sendEmail.randomCode();
                var statcEmail = sendEmail.sendemail(txtEmail.Text, txtCode.Text, emailTheme);
                //MessageBox.Show(email);
                isBtnGet = true;
            }
        }

        private void txtCode_MouseLeave(object sender, EventArgs e)
        {
            if (txtCode.Text.ToString().Trim()==null&&bll.isEmailcode(txtCode.Text.ToString().Trim()))
            {
                pictureBox4.Visible = false;
                pictureBox5.Visible = true;
            }
            else
            {
                pictureBox4.Visible = true;
                pictureBox5.Visible = false;
            }
        }
    }
}
