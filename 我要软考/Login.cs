using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace 我要软考
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
         //连接字符串字段
        private void btnLogin_Click(object sender, EventArgs e)
        {
            MessageBox.Show("正在连接服务器");
            sqlHerp sqlherp=new sqlHerp();
            string con =  sqlherp.sqlcon();
            SqlConnection sqlcon = new SqlConnection(con);
            sqlcon.Open();
            MessageBox.Show(""+sqlcon.State);
            sqlcon.Close();
        }
    }
}
