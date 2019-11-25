using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace 我要软考
{
    public partial class MyTest : Form
    {
        public MyTest()
        {
            InitializeComponent();
        }

        int[] ruanjianshejishi_qBId = { 1, 2, 3, 4 };
        int[] chenxuyuan_qBId = { 5, 6 };
        private void My_Load(object sender, EventArgs e)
        {
            isPanelFalse(false);
            panel5.Visible = false;
        }

        public void isPanelFalse(bool istrue)
        {
            panel1.Visible = istrue;
            panel2.Visible = istrue;
            panel3.Visible = istrue;
            panel4.Visible = istrue;
        }
        public void fill(string[] a)
        {
            qId.Text = "第" + a[0].ToString() + "题";
            rdoAnswerA.Text = a[3].ToString();
            rdoAnswerB.Text = a[4].ToString();
            rdoAnswerC.Text = a[5].ToString();
            rdoAnswerD.Text = a[6].ToString();
            //parsing.Text = a[8].ToString();
            //comments.Text = a[9].ToString();
            string strquestion = a[2];
            string strparsing = a[8];
            string strcomments = a[9];
            string[] questionArray = strquestion.Split(new char[] { '?' });
            string[] parsingArray = strparsing.Split(new char[] { '?' });
            string[] commentsArray = strcomments.Split(new char[] { '?' });

            for (int i = 0; i < questionArray.Length; i++)
            {
                question.Text += questionArray[i].ToString() + "\n";
            }
            for (int i = 0; i < parsingArray.Length; i++)
            {
                parsing.Text += parsingArray[i].ToString() + "\n";
            }
            for (int i = 0; i < commentsArray.Length; i++)
            {
                comments.Text += commentsArray[i].ToString() + "\n";
            }

        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox1.Text)
            {
                case "软件设计师":
                    isPanelFalse(true);
                    label2.Text = BLL.bll.qbdaytype(ruanjianshejishi_qBId[0]).ToString();
                    label3.Text = BLL.bll.qbdaytype(ruanjianshejishi_qBId[1]).ToString();
                    label4.Text = BLL.bll.qbdaytype(ruanjianshejishi_qBId[2]).ToString();
                    label5.Text = BLL.bll.qbdaytype(ruanjianshejishi_qBId[3]).ToString();
                    break;

                case "程序员":
                    isPanelFalse(true);
                    label2.Text = BLL.bll.qbdaytype(chenxuyuan_qBId[0]).ToString();
                    label3.Text = BLL.bll.qbdaytype(chenxuyuan_qBId[1]).ToString();
                    //label6.Text = "002016年上半年软件设计师上午试卷             ";
                    //label8.Text = "";
                    break;
            }
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            if (label2.Text == BLL.bll.qbdaytype(ruanjianshejishi_qBId[0]).ToString())
            {
                isPanelFalse(false);
                panel5.Visible = true;
                var qBId = ruanjianshejishi_qBId[0];
                var qId = 2;
                string[] a = BLL.bll.loadPaper(qBId, qId);//根据这个去查这个题库的试卷
                //要
                fill(a);
                //MessageBox.Show(a[0] + "\n" + a[2]);
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
    }
}
