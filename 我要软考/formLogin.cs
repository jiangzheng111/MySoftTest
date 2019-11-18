﻿using System;
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
using MODEL;
using BLL;
using UI;

//要优化代码
namespace 我要软考
{
    public partial class Login : Form
    {
        private int btn_Click = 0; //标识是否点击
        private int suserId = 0;
        //private static int suserId = string.Empty;
        private static string suserPwd = string.Empty;
        string BllReturn;//存放来自BLL的返回值
        Suser MySoftTest = null; //实例实体类

        public Login()
        {
            InitializeComponent();
        }
        private void Login_Load(object sender, EventArgs e)
        {
            //btnMax.Click -= new System.EventHandler(this.miN_MAX_EXIT1.btnMax_Click);取消事件
            txtName.TextAlign = HorizontalAlignment.Center;
            //txtName.VerticalContentAlignment="Center;
            txtPwd.TextAlign = HorizontalAlignment.Center;
            txtPwd.PasswordChar = '*';
            btnMax.Enabled = false;
        }

        //验证账号
        private void btnLogin_Click(object sender, EventArgs e)
        {
            //txtName.Text.ToString().Trim()
            suserId =int.Parse(txtName.Text);
            suserPwd = txtPwd.Text.ToString().Trim();
            bll LoginBll = new bll();
            BllReturn = LoginBll.select(suserId, suserPwd);

            MessageBox.Show(BllReturn, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            if (BllReturn == "登录成功")
            {
                btn_Click = 1;
                Login_lbl();
                MyTest mytest = new MyTest();
                mytest.Show();
            }
            #region 没有使用返回字符串的代码
            ////switch (BllReturn)
            //{
            //    case 0:
            //        btn_Click = 1;
            //        Login_lbl();
            //        break;
            //    case 1:
            //        MessageBox.Show("账号或密码错误", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            //        break;
            //    case 2:
            //        MessageBox.Show("没有此账号", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        break;
            //}
            #endregion
            #region 没有使用三层架构
            //AdapterSql.Isql2005 c = new 我要软考.AdapterSql.Adapter1();
            //c.sql2005();
            //suserName = txtName.Text.ToString().Trim();
            //suserPwd = txtPwd.Text.ToString().Trim();
            //if (suserName == "" || suserPwd == "")
            //{
            //    MessageBox.Show("请输入账号或密码！");
            //    return;
            //}
            //btn_Click = 1;
            //sqlHerp sqlherp = new sqlHerp();
            //string con = sqlherp.sqlcon();
            //SqlConnection sqlcon = new SqlConnection(con);
            //sqlcon.Open();
            //using (SqlCommand sqlcmd = new SqlCommand("select * from Suser where SuserName =@susername and SuserPwd=@suserpwd", sqlcon))
            //{
            //    sqlcmd.Parameters.AddWithValue("@susername", suserName);
            //    sqlcmd.Parameters.AddWithValue("@suserpwd", suserPwd);
            //    SqlDataReader dr = sqlcmd.ExecuteReader();
            //    if (dr.Read())
            //    {
            //        if (MySoftTest == null)
            //        {
            //            MySoftTest = new Suser();
            //        }
            //        MySoftTest.SuserName = dr["SuserName"].ToString().Trim();
            //        MySoftTest.SuserPwd = dr["SuserPwd"].ToString().Trim();
            //        login_lbl();
            //        My my = new My();
            //        my.Show();
            //    }
            //    else
            //    {
            //        MessageBox.Show("账号或密码错误!");
            //        return;
            //    }
            //}


            //sqlcon.Close();
            #endregion
        }

        //加载服务器的字符串
        private void Login_lbl()
        {
            loginlbl.Visible = true;
            loginlbl.Text = "正在连接服务器";
            if (btn_Click == 1)
            {
                for (int i = 1; i < 5; i++)
                {
                    string dot = "·";
                    Thread.Sleep(500);
                    Application.DoEvents();
                    loginlbl.Text += " " + dot.Trim();
                    loginlbl.Text = loginlbl.Text.ToString().Trim();
                    Thread.Sleep(500);
                }
            }
            this.Hide();
            btn_Click = 0;
        }

        ////自定义最小最大化，关闭。
        //private void btnClose_Click(object sender, EventArgs e)
        //{
        //    Application.Exit();
        //}
        ////自定义最小最大化，关闭。
        //private void btnMax_Click(object sender, EventArgs e)
        //{
        //    if (this.WindowState == FormWindowState.Maximized)
        //    {
        //        this.WindowState = FormWindowState.Normal;
        //    }
        //    else
        //    {
        //        this.WindowState = FormWindowState.Maximized;
        //    }
        //}
        ////自定义最小最大化，关闭。
        //private void btnMin_Click(object sender, EventArgs e)
        //{
        //    this.WindowState = FormWindowState.Minimized;
        //}

        ////移动窗体

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

        //注册账号
        private void linkReg_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //Form.ActiveForm'
            formReg formreg = new formReg();
            formreg.Show();
        }

        //找回密码
        private void linkRePwd_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            formRePwd formrepwd = new formRePwd();
            formrepwd.Show();
        }
    }
}

//class MyMove
//{
//    Point mouseOff;//鼠标移动位置变量
//    bool leftFlag;//标记是否为左键
//    public void Login_MouseDown(object sender, MouseEventArgs e)
//    {
//        if (e.Button == MouseButtons.Left)
//        {
//            mouseOff = new Point(-e.X, -e.Y); //得到变量的值
//            leftFlag = true;                  //点击左键按下时标注为true;
//        }
//    }
//    public void Login_MouseMove(object sender, MouseEventArgs e)
//    {
//        if (leftFlag)
//        {
//            Point mouseSet = Control.MousePosition;
//            mouseSet.Offset(mouseOff.X, mouseOff.Y);  //设置移动后的位置
//           Form.ActiveForm.Location = mouseSet;
//        }
//    }
//    public void Login_MouseUp(object sender, MouseEventArgs e)
//    {
//        if (leftFlag)
//        {
//            leftFlag = false;//释放鼠标后标注为false;
//        }
//    }

//    internal void Login_MouseDown(object sender, EventArgs e)
//    {
//        throw new NotImplementedException();
//    }
//}