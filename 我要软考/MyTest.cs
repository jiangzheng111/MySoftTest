using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Data.SqlClient;
using DAL;
//using System.Data.sqlite;
using UI;

namespace 我要软考
{
    public partial class MyTest : Form
    {
        public MyTest()
        {
            InitializeComponent();
        }
        string[] questionArray;//储存一道的所有数据
        //string[] numArray;
        int[] ruanjianshejishi_qBId = { 1, 2, 3, 4 };//标识有多少份题
        int[] chenxuyuan_qBId = { 5, 6 };//标识有多少份题
        string[] answerArray;//记录作答的记录
        string SuserEmail = "1316836373@qq.com";
        int qBId = 1;       //标识题库号
        int qId = 1;        //标识题号
        bool isPush = false; //标识是否点击提交
        bool collection;    //标识 是否是收藏
        ArrayList stateList = new ArrayList();//标识该题是否提交过
        public static string suseremail;
        public static string suseradmin;
        private void My_Load(object sender, EventArgs e)
        {
            isPanelFalse(false);
            panel5.Visible = false;
            //dataGridView1.DataSource = BLL.bll.getDataset();
            DataSet ds = new DataSet();
            using (SqlConnection CON = new SqlConnection(sqlLink.sqlcon()))
            {
                CON.Open();
                using (SqlCommand CMD = new SqlCommand("select * from Question", CON))
                {
                    SqlDataAdapter da = new SqlDataAdapter(CMD);
                    da.Fill(ds, "Question");
                    //da.Dispose();
                    CMD.Dispose();
                }
                CON.Close();
            }
        }

        //控制Pane的可视
        public void isPanelFalse(bool istrue)
        {
            panel1.Visible = istrue;
            panel2.Visible = istrue;
            panel3.Visible = istrue;
            panel4.Visible = istrue;
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
                //var qId = 2;
                questionArray = BLL.bll.loadPaper(qBId, qId);//根据这个去查这个题库的试卷
                fill(questionArray, false);
            }

        }

        /// <summary>
        /// 读取数据填充到控件 
        /// </summary>
        /// <param name="thisquestionArray">问题的一系列的储存</param>
        /// <param name="isClear">是否点击了上下题，是则清空之前的数据</param>
        public void fill(string[] thisquestionArray, bool isClear)
        {
            if (isClear)
            {
                question.Text = string.Empty;
                parsing.Text = string.Empty;
                comments.Text = string.Empty;
            }
            lblqId.Text = "第" + thisquestionArray[0].ToString() + "题";
            rdoAnswerA.Text = "A. " + thisquestionArray[3].ToString();
            rdoAnswerB.Text = "B. " + thisquestionArray[4].ToString();
            rdoAnswerC.Text = "C. " + thisquestionArray[5].ToString();
            rdoAnswerD.Text = "D. " + thisquestionArray[6].ToString();
            string strQuestion = thisquestionArray[2];
            string strParsing = thisquestionArray[8];
            string strComments = thisquestionArray[9];
            string[] questionArray = strQuestion.Split(new char[] { '?' });
            string[] parsingArray = strParsing.Split(new char[] { '?' });
            string[] commentsArray = strComments.Split(new char[] { '?' });

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

        private void btnPush_Click(object sender, EventArgs e)
        {
            isPush = !isPush;//点击了提交
            if (isPush)
            {
                if (rdoAnswerA.Checked == false && rdoAnswerB.Checked == false && rdoAnswerC.Checked == false && rdoAnswerD.Checked == false)
                {
                    MessageBox.Show("你还没有选择答案哦");
                    return;
                }
                //判断是否答对  对

                //给当前的题赋值状态
                try
                {
                    if (stateList[qId - 1].ToString() == string.Empty)//如果当前的题号对应的状态值为空就给他赋值
                    {
                    }
                    if (stateList[qId-1].ToString()==false.ToString())
                    {
                        stateList[qId - 1] = true.ToString();
                    }
                }
                catch (Exception)
                {
                    stateList.Add(true.ToString()); //赋值 有点击
                }

                if (lblmyAnswer.Text == questionArray[7].ToString())
                {
                    if (stateList[qId - 1].ToString() == true.ToString())
                    {
                        btnPush.Enabled = false;
                        //btnPush.Enabled = false;
                        qId = int.Parse(questionArray[0].ToString());
                        lblanswer.Text = questionArray[7].ToString();
                        answerArray = BLL.bll.loadAnswer(int.Parse(questionArray[0].ToString()), int.Parse(questionArray[1].ToString()), SuserEmail, lblmyAnswer.Text);
                        picRight.Visible = true;
                        picwrong.Visible = false;
                        //numArray[qId] = true.ToString();
                        //stateList[qId - 1] = true.ToString();
                    }
                }
                //判断是否答对  错
                else
                {
                    //stateList.Add(true.ToString());//被点击了
                    if (stateList[qId - 1].ToString() == true.ToString())//被点击了
                    {
                        btnPush.Enabled = false;
                        //这要写入数据库，记录邮箱，题号，题库号，我的答案，是否错题，是否收藏。
                        //写入题号id，题库id，邮箱，错题
                        answerArray = BLL.bll.loadAnswer(int.Parse(questionArray[0].ToString()), int.Parse(questionArray[1].ToString()), SuserEmail, lblmyAnswer.Text);
                        picRight.Visible = false;
                        picwrong.Visible = true;
                        //numArray[qId] = true.ToString();
                        //stateList[qId - 1] = true.ToString();
                    }
                }
                //isPush = false;
                //btnPush.Enabled = !isPush;//isPush=true 相等于按钮不可用 取反表示按钮不可用
            }
        }
        //接下来重构算法
        private void btnUp_Click(object sender, EventArgs e)
        {
            if (isPush == true)//如果按钮没有被点击
            {
                if (stateList[qId - 2].ToString() != string.Empty)
                {
                    //MessageBox.Show("Test");
                }
                //stateList.Add(false.ToString());//初始化按钮是否被点击
                else
                {
                    stateList[qId - 1] = false;
                }
            }
            if (stateList[qId - 2].ToString() == true.ToString())
            {
                btnPush.Enabled = false;
            }
            if (stateList[qId-2].ToString()==false.ToString())
            {
                btnPush.Enabled = true;
            }
            if (qId <= 1)
            {
                questionArray = BLL.bll.loadPaper(qBId, qId);
                fill(questionArray, true);
                isPush = true;
                return;
            }
            if (qId > 1)
            {
                qId--;
                questionArray = BLL.bll.loadPaper(qBId, qId);
                fill(questionArray, true);
                //isPush = true;
                //btnPush.Enabled = !Convert.ToBoolean(stateList[qId - 2].ToString());
                lblanswer.Text = string.Empty;
                lblmyAnswer.Text = string.Empty;
                picRight.Visible = false;
                picwrong.Visible = false;
                rdoAnswerA.Checked = false;
                rdoAnswerB.Checked = false;
                rdoAnswerC.Checked = false;
                rdoAnswerD.Checked = false;
            }
            //else
            //{
            //    stateList[qId - 1] = true.ToString();
            //}
        }

        private void btnDowm_Click(object sender, EventArgs e)
        {
            //if (isPush==true)
            //{
            //    stateList.Add(false.ToString());//初始化按钮是否被点击 上下题，输入输出没有控制好
            //    if (stateList[qId-1].ToString()!=string.Empty)
            //    {
            //        stateList.Add(false.ToString());//初始化按钮是否被点击
            //    }
            //}
            //if (stateList[qId - 1].ToString() == true.ToString())
            //{
            ////btnPush.Enabled = false;
            //}

            try
            {
                if (stateList[qId].ToString() == string.Empty)//如果当前的题号对应的状态值为空就给他赋值
                {
                }
                //else
                //{
                //    stateList[qId] = isPush.ToString(); //如果不为空，则给他赋值  点击了
                //}
            }
            catch (Exception)
            {
                stateList.Add(false.ToString()); //赋值 没有点击
            }
            //要先判断按钮有没有被点击 再依据按钮的状态去写入当前题的状态
            //stateList.Add(false.ToString());
            if (qId >= 1)
            {
                qId++;
                questionArray = BLL.bll.loadPaper(qBId, qId);
                fill(questionArray, true);
                //isPush = true;      //要先判断数组这题的状态是不是等于空，是就给他复制
                //btnPush.Enabled = isPush;  //这个取值要给数组赋值  用对应的题号，对应的状态而取值    解析要根据是否依据提交答案而作出显示
                lblanswer.Text = string.Empty;
                lblmyAnswer.Text = string.Empty;
                picRight.Visible = false;
                picwrong.Visible = false;
                rdoAnswerA.Checked = false;
                rdoAnswerB.Checked = false;
                rdoAnswerC.Checked = false;
                rdoAnswerD.Checked = false;
            }
            try
            {
                btnPush.Enabled = !Convert.ToBoolean(stateList[qId - 1].ToString());
            }
            catch (Exception)
            {
                btnPush.Enabled = true;
            }
        }

        #region


        #endregion

        #region 移动窗体
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
        #endregion

        #region 控制选项，及选项文本
        /// <summary>
        /// 控制选项，及选项文本
        /// </summary>
        private void myAnswertxt()
        {
            isPush = !isPush;
            if (isPush)
            {
                if (rdoAnswerA.Checked == true)
                {
                    lblmyAnswer.Text = "A";
                }
                if (rdoAnswerB.Checked == true)
                {
                    lblmyAnswer.Text = "B";
                }
                if (rdoAnswerC.Checked == true)
                {
                    lblmyAnswer.Text = "C";
                }
                if (rdoAnswerD.Checked == true)
                {
                    lblmyAnswer.Text = "D";
                }
            }
        }

        private void rdoAnswerA_CheckedChanged(object sender, EventArgs e)
        {
            myAnswertxt();
        }

        private void rdoAnswerB_CheckedChanged(object sender, EventArgs e)
        {
            myAnswertxt();
        }

        private void rdoAnswerC_CheckedChanged(object sender, EventArgs e)
        {
            myAnswertxt();
        }

        private void rdoAnswerD_CheckedChanged(object sender, EventArgs e)
        {
            myAnswertxt();
        }
        #endregion

        private void miN_MAX_EXIT1_Load(object sender, EventArgs e)
        {
            miN_MAX_EXIT1.btnMax.Enabled = true;
        }

        private void tabPage5_Click(object sender, EventArgs e)
        {
            if (suseradmin == "true")
            {
                this.Hide();
                Form admin = new admin();
                admin.Show();
            }
            else
            {
                MessageBox.Show("请升级为管理员！");
            }
        }
    }
}
