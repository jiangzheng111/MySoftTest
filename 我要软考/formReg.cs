using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace UI
{
    public partial class formReg : Form
    {
        public formReg()
        {
            InitializeComponent();
        }
        public BLL.bll bll = new BLL.bll();
        int i = 61;//一分钟
        bool isBtnGet = false;//判断btnGet是否被点击过
        private void btnGet_Click(object sender, EventArgs e)
        {

            var email = bll.emailCode(txtEmail.Text.ToString().Trim());
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
                var emailTheme = MODEL.TextString.theme;
                myTool.sendEmail sendEmail = new myTool.sendEmail();
                myTool.sendEmail.randomCode();
                var statcEmail = sendEmail.sendemail(txtEmail.Text, txtCode.Text, emailTheme);
                MessageBox.Show(email);
                isBtnGet = true;
            }
        }
        private void btnReg_Click(object sender, EventArgs e)
        {
            //timer1.Enabled = true;
            var statcEmail = string.Empty; ;
            statcEmail = bll.insert(txtName.Text.ToString().Trim(), txtPwd.Text.ToString().Trim(), txtEmail.Text.ToString().Trim(), txtCode.Text.ToString().Trim());
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
                    ctrl.ForeColor = Color.AntiqueWhite;
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
            btnGet.Text = i.ToString() + "s";
            if (i == 0)
            {
                timer1.Enabled = false;
                btnGet.Text = "获取";
                isBtnGet = false;
                i = 61;
            }
        }
    }
}
