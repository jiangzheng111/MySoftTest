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



// 现在差把状态读出来。如果第一作答了，点击了下一题再点击上一题时，应该把 作答的选项以对否展示出来，如果第一题没有作答，则点击下一题再点击上一题时，是没有作答的痕迹的。
//现在差把作答的选择和正确的选择进行对比，从而控制显示是否对错，以及某个选项是否被选中，还有字符串null如何处理
//先处理上下提的null的显示
//现在处理选项是否被选中，以及对错
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
        int[] ruanjianshejishi_qBId = { 1, 2, 3, 4 };//标识有多少软件设计师的题
        int[] chenxuyuan_qBId = { 5, 6 };//标识有多少份程序员的题
        string[] answerArray;//记录作答的记录
        string SuserEmail = "1316836373@qq.com";//测试用的邮箱，测试完可以删掉。
        int qBId = 1;       //标识题库号
        int qId = 1;        //标识题号
        bool isPush = true; //标识是否点击提交
        bool collection;    //标识 是否是收藏
        static int Morning = 75;   //上午题目总数
        static int Afternoon = 5;  //下午题总数

        ArrayList StateList = new ArrayList();//标识该题是否提交过
        ArrayList MyAnswerList = new ArrayList();//标识我作答的答案
        ArrayList TheRightAnswerList = new ArrayList();//标识正确答案

        public static string suseremail;
        public static string suseradmin;
        private void My_Load(object sender, EventArgs e)
        {
            isPanelFalse(false);
            panel5.Visible = false;
            parsing.Visible = false;//解析是否显示
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

        //控制用户选中的科目
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

        //控制科目的图片
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
            lblqId.Text = "第" + thisquestionArray[0].ToString() + "题 ";
            rdoAnswerA.Text = "A. " + thisquestionArray[3].ToString();
            rdoAnswerB.Text = "B. " + thisquestionArray[4].ToString();
            rdoAnswerC.Text = "C. " + thisquestionArray[5].ToString();
            rdoAnswerD.Text = "D. " + thisquestionArray[6].ToString();
            parsing.Text = "解析  ";
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
            btnConlletionText();
        }

        //点击了提交
        private void btnPush_Click(object sender, EventArgs e)
        {
            if (isPush)
            {
                if (rdoAnswerA.Checked == false && rdoAnswerB.Checked == false && rdoAnswerC.Checked == false && rdoAnswerD.Checked == false)
                {
                    MessageBox.Show("你还没有选择答案哦");
                    return;
                }
                //qId - 1在这里标识当前的题，从所周知数组的下标是从零开始的，qid是题号到数组里自然要减一。
                //给当前的题赋值是否作答的状态 true为作答，false为未作答
                try
                {
                    if (StateList[qId - 1].ToString() == string.Empty)//如果当前的题号对应的状态值为空就给他赋值
                    {
                    }
                    if (StateList[qId - 1].ToString() == false.ToString())//如果按钮被记录没有点击，则点击后要修改记录值为已点击
                    {
                        StateList[qId - 1] = true.ToString();
                    }
                }
                catch (Exception)
                {
                    StateList.Add(true.ToString()); //赋值 有作答
                }
                if (StateList[qId - 1].ToString() == true.ToString())
                {
                    try //如果这语句报错则执行下一条语句
                    {   //如果当前的数组下标对应的值没有进行赋值，则会执行catch这语句块里的赋值语句
                        MyAnswerList[qId - 1] = lblmyAnswer.Text;
                        TheRightAnswerList[qId - 1] = questionArray[7].ToString();

                    }
                    catch (Exception)
                    {
                        MyAnswerList.Add(lblmyAnswer.Text);//储存作答的选项
                        TheRightAnswerList.Add(questionArray[7].ToString());//储存正确的答案
                    }
                    switch (lblmyAnswer.Text)
                    {
                        case "A":
                            rdoAnswerA.Checked = true;
                            rdoAnswerB.Enabled = false;
                            rdoAnswerC.Enabled = false;
                            rdoAnswerD.Enabled = false;
                            break;
                        case "B":
                            rdoAnswerB.Checked = true;
                            rdoAnswerA.Enabled = false;
                            rdoAnswerC.Enabled = false;
                            rdoAnswerD.Enabled = false;
                            break;
                        case "C":
                            rdoAnswerA.Enabled = false;
                            rdoAnswerB.Enabled = false;
                            rdoAnswerC.Checked = true;
                            rdoAnswerD.Enabled = false;
                            break;
                        case "D":
                            rdoAnswerA.Enabled = false;
                            rdoAnswerB.Enabled = false;
                            rdoAnswerC.Enabled = false;
                            rdoAnswerD.Checked = true;
                            break;
                    }
                }
                //判断是否答对  对
                if (lblmyAnswer.Text == questionArray[7].ToString())
                {
                    if (StateList[qId - 1].ToString() == true.ToString())
                    {
                        btnPush.Enabled = false;
                        //btnPush.Enabled = false;
                        qId = int.Parse(questionArray[0].ToString());
                        lblanswer.Text = questionArray[7].ToString();
                        answerArray = BLL.bll.loadAnswer(int.Parse(questionArray[0].ToString()), int.Parse(questionArray[1].ToString()), SuserEmail, lblmyAnswer.Text);
                        picRight.Visible = true;
                        picwrong.Visible = false;
                        //numArray[qId] = true.ToString();
                        //StateList[qId - 1] = true.ToString();
                    }
                }
                //判断是否答对  错
                else
                {
                    //StateList.Add(true.ToString());//被点击了
                    if (StateList[qId - 1].ToString() == true.ToString())//被点击了
                    {
                        btnPush.Enabled = false;
                        lblanswer.Text = questionArray[7].ToString();
                        //这要写入数据库，记录邮箱，题号，题库号，我的答案，是否错题，是否收藏。
                        //写入题号id，题库id，邮箱，错题
                        answerArray = BLL.bll.loadAnswer(int.Parse(questionArray[0].ToString()), int.Parse(questionArray[1].ToString()), SuserEmail, lblmyAnswer.Text);
                        picRight.Visible = false;
                        picwrong.Visible = true;
                        //numArray[qId] = true.ToString();
                        //StateList[qId - 1] = true.ToString();
                    }
                }
                parsing.Visible = Convert.ToBoolean(StateList[qId - 1].ToString());//控制解析是否显示


                //isPush = false;
                //btnPush.Enabled = !isPush;//isPush=true 相等于按钮不可用 取反表示按钮不可用
            }
        }
        //接下来重构算法
        private void btnUp_Click(object sender, EventArgs e)
        {
            //现在要拦截题号=1时，不能点击上一题，或点击上一题没有反应
            if (qId == 1)
            {
                return;
            }
            if (isPush == true)//如果按钮没有被点击
            {
                if (StateList[qId - 2].ToString() != string.Empty)
                {
                    //MessageBox.Show("Test");
                }
                //StateList.Add(false.ToString());//初始化按钮是否被点击
                else
                {
                    StateList[qId - 1] = false.ToString();
                }
                parsing.Visible = Convert.ToBoolean(StateList[qId - 2].ToString());//控制解析是否显示
            }

            if (StateList[qId - 2].ToString() == true.ToString())
            {
                btnPush.Enabled = false;
                switch (lblmyAnswer.Text)
                {
                    case "A":
                        rdoAnswerA.Checked = true;
                        rdoAnswerB.Enabled = false;
                        rdoAnswerC.Enabled = false;
                        rdoAnswerD.Enabled = false;
                        break;
                    case "B":
                        rdoAnswerB.Checked = true;
                        rdoAnswerA.Enabled = false;
                        rdoAnswerC.Enabled = false;
                        rdoAnswerD.Enabled = false;
                        break;
                    case "C":
                        rdoAnswerA.Enabled = false;
                        rdoAnswerB.Enabled = false;
                        rdoAnswerC.Checked = true;
                        rdoAnswerD.Enabled = false;
                        break;
                    case "D":
                        rdoAnswerA.Enabled = false;
                        rdoAnswerB.Enabled = false;
                        rdoAnswerC.Enabled = false;
                        rdoAnswerD.Checked = true;
                        break;
                }
            }
            if (StateList[qId - 2].ToString() == false.ToString())
            {
                btnPush.Enabled = true;
                rdoAnswerA.Enabled = true;
                rdoAnswerB.Enabled = true;
                rdoAnswerC.Enabled = true;
                rdoAnswerD.Enabled = true;
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
                //btnPush.Enabled = !Convert.ToBoolean(StateList[qId - 2].ToString());
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
                if (MyAnswerList[qId - 1].ToString() == string.Empty)//如果当前的题并没有作答，则会报错，执行报错catch方法体里面的语句
                {
                }
                else//如果当前的题已经作答过，则将作答的选择展示出来
                {
                    lblmyAnswer.Text = MyAnswerList[qId - 1].ToString();
                    lblanswer.Text = TheRightAnswerList[qId - 1].ToString();
                }
                if (lblanswer.Text == "null")
                {
                    lblanswer.Text = "";
                    lblmyAnswer.Text = "";
                }
                else
                {
                    if (lblanswer.Text == lblmyAnswer.Text)
                    {
                        picRight.Visible = true;
                    }
                    else
                    {
                        picwrong.Visible = true;
                    }
                    //lblanswer.Text
                    //这要根据是否点击提交而判断
                    //当已被点击，应该为false
                    //当没有被点击，应该为true；
                    //三个事件
                    //第一个事件，当点击按钮提交，应该为false
                    //第二个事件，当点击下一题时，应该根据他是否为true，是则为false，否则true；
                    //第三个事件，当点击上一题时，应该根据他是否为true，时则为false，否则true；
                }
            }
            catch (Exception)
            {
                MyAnswerList.Add("null");
                TheRightAnswerList.Add("null");
            }
            if (!btnPush.Enabled)
            {
                switch (lblmyAnswer.Text)
                {
                    case "A":
                        rdoAnswerA.Checked = true;
                        rdoAnswerB.Enabled = false;
                        rdoAnswerC.Enabled = false;
                        rdoAnswerD.Enabled = false;
                        break;
                    case "B":
                        rdoAnswerB.Checked = true;
                        rdoAnswerA.Enabled = false;
                        rdoAnswerC.Enabled = false;
                        rdoAnswerD.Enabled = false;
                        break;
                    case "C":
                        rdoAnswerA.Enabled = false;
                        rdoAnswerB.Enabled = false;
                        rdoAnswerC.Checked = true;
                        rdoAnswerD.Enabled = false;
                        break;
                    case "D":
                        rdoAnswerA.Enabled = false;
                        rdoAnswerB.Enabled = false;
                        rdoAnswerC.Enabled = false;
                        rdoAnswerD.Checked = true;
                        break;
                    //case "null":
                    //    rdoAnswerA.Enabled = true;
                    //    rdoAnswerB.Enabled = true;
                    //    rdoAnswerC.Enabled = true;
                    //    rdoAnswerD.Enabled = true;
                }
            }
            else
            {
                rdoAnswerA.Enabled = true;
                rdoAnswerB.Enabled = true;
                rdoAnswerC.Enabled = true;
                rdoAnswerD.Enabled = true;
            }
            //else
            //{
            //    StateList[qId - 1] = true.ToString();
            //}

            //写成一个方法
            //var istrue = BLL.bll.readCollection(int.Parse(questionArray[0].ToString()), int.Parse(questionArray[1].ToString()), SuserEmail);
            //if (istrue)
            //{
            //    btnCollection.Text = "已收藏";
            //}
            //else
            //{
            //    btnCollection.Text = "未收藏";
            //}
            btnConlletionText();

        }

        private void btnDowm_Click(object sender, EventArgs e)
        {
            try
            {
                if (StateList[qId].ToString() == string.Empty)//如果当前的题号对应的状态值为空就给他赋值
                {
                }
            }
            catch (Exception)
            {
                StateList.Add(false.ToString()); //赋值 没有点击
            }


            //要先判断按钮有没有被点击 再依据按钮的状态去写入当前题的状态
            //StateList.Add(false.ToString());
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
                btnPush.Enabled = !Convert.ToBoolean(StateList[qId - 1].ToString());
                parsing.Visible = Convert.ToBoolean(StateList[qId - 1].ToString());
            }
            catch (Exception)
            {
                btnPush.Enabled = true;
            }

            try
            {
                if (MyAnswerList[qId - 1].ToString() == string.Empty)//如果当前的题并没有作答，则会报错，执行报错catch方法体里面的语句
                {
                }
                else//如果当前的题已经作答过，则将作答的选择展示出来
                {
                    lblmyAnswer.Text = MyAnswerList[qId - 1].ToString();
                    lblanswer.Text = TheRightAnswerList[qId - 1].ToString();
                }
                if (lblanswer.Text == "null")
                {
                    lblanswer.Text = "";
                    lblmyAnswer.Text = "";
                }
                else
                {
                    if (lblanswer.Text == lblmyAnswer.Text)
                    {
                        picRight.Visible = true;
                    }
                    else
                    {
                        picwrong.Visible = true;
                    }
                }
            }
            catch (Exception)
            {
                MyAnswerList.Add("null");
                TheRightAnswerList.Add("null");
            }
            if (!btnPush.Enabled)
            {
                switch (lblmyAnswer.Text)
                {
                    case "A":
                        rdoAnswerA.Checked = true;
                        rdoAnswerB.Enabled = false;
                        rdoAnswerC.Enabled = false;
                        rdoAnswerD.Enabled = false;
                        break;
                    case "B":
                        rdoAnswerB.Checked = true;
                        rdoAnswerA.Enabled = false;
                        rdoAnswerC.Enabled = false;
                        rdoAnswerD.Enabled = false;
                        break;
                    case "C":
                        rdoAnswerA.Enabled = false;
                        rdoAnswerB.Enabled = false;
                        rdoAnswerC.Checked = true;
                        rdoAnswerD.Enabled = false;
                        break;
                    case "D":
                        rdoAnswerA.Enabled = false;
                        rdoAnswerB.Enabled = false;
                        rdoAnswerC.Enabled = false;
                        rdoAnswerD.Checked = true;
                        break;
                    //case "null":
                    //    rdoAnswerA.Enabled = true;
                    //    rdoAnswerB.Enabled = true;
                    //    rdoAnswerC.Enabled = true;
                    //    rdoAnswerD.Enabled = true;
                }
            }
            else
            {
                rdoAnswerA.Enabled = true;
                rdoAnswerB.Enabled = true;
                rdoAnswerC.Enabled = true;
                rdoAnswerD.Enabled = true;
            }
            btnConlletionText();
            //var istrue = BLL.bll.readCollection(int.Parse(questionArray[0].ToString()), int.Parse(questionArray[1].ToString()), SuserEmail);
            //if (istrue)
            //{
            //    btnCollection.Text = "已收藏";
            //}
            //else
            //{
            //    btnCollection.Text = "未收藏";
            //}
        }

        //判断已收藏或未收藏
        public void btnConlletionText()
        {
            var istrue = BLL.bll.readCollection(int.Parse(questionArray[0].ToString()), int.Parse(questionArray[1].ToString()), SuserEmail);
            if (istrue)
            {
                btnCollection.Text = "已收藏";
            }
            else
            {
                btnCollection.Text = "未收藏";
            }
        }

        //怎么制作收藏和移除收藏
        //根据题号，题库号，邮箱，进行收藏。点击收藏时进行收藏，点击移除时移除收藏
        private void pictureBox4_Click(object sender, EventArgs e)
        {
            if (istrue)//收藏
            {
                collection = true;
                pictureBox3.Visible = true;
                pictureBox4.Visible = false;
                istrue = !istrue;
                BLL.bll.setCollection(int.Parse(questionArray[0].ToString()), int.Parse(questionArray[1].ToString()), SuserEmail, collection);
                //根据题号，题库号，邮箱，进行收藏
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (!istrue)//移除收藏
            {
                collection = false;
                pictureBox3.Visible = false;
                pictureBox4.Visible = true;
                istrue = !istrue;
                BLL.bll.setCollection(int.Parse(questionArray[0].ToString()), int.Parse(questionArray[1].ToString()), SuserEmail, collection);
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
            //isPush = !isPush;
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
        bool istrue = true;

        private void btnCollection_Click(object sender, EventArgs e)
        {
            var istrue = BLL.bll.readCollection(int.Parse(questionArray[0].ToString()), int.Parse(questionArray[1].ToString()), SuserEmail);
            if (btnCollection.Text == "未收藏")
            {
                MessageBox.Show("已添加收藏");
                collection = true;
                //pictureBox3.Visible = false;
                //pictureBox4.Visible = true;
                istrue = !istrue;
                BLL.bll.setCollection(int.Parse(questionArray[0].ToString()), int.Parse(questionArray[1].ToString()), SuserEmail, collection);
                btnCollection.Text = "已收藏";
            }
            else
            {
                MessageBox.Show("已移除收藏");
                collection = false;
                //pictureBox3.Visible = false;
                //pictureBox4.Visible = true;
                istrue = !istrue;
                BLL.bll.setCollection(int.Parse(questionArray[0].ToString()), int.Parse(questionArray[1].ToString()), SuserEmail, collection);
                btnCollection.Text = "未收藏";

            }

        }


        Button[] bnt = new Button[Morning+1];
        bool isbtn = true;
        private void button5_Click(object sender, EventArgs e)
        {
            if (isbtn)
            {
                panel7.Visible = true;
                isbtn = !isbtn;
                //Morning =
                //Afternoon
                for (int i = 0; i < Morning; i++)
                {
                    //实例化
                    bnt[i] = new Button();
                    //定义控件名称
                    bnt[i].Name = "bntton_" + (i + 1).ToString();
                    //定义text属性，可以用string数组初始化为指定值
                    bnt[i].Text = (i + 1).ToString();
                    //注：如果不指定父容器，则坐标是相对于主窗体的
                    bnt[i].Parent = panel7;
                    //定义坐标
                    bnt[i ].Location = new Point(20 + (i % 16) * 30, 5 + (i / 16) * 30);
                    //调整大小
                    //bnt[i].AutoSize = true;
                    bnt[i ].Size = new Size(25, 25);
                    //批量添加事件
                    bnt[i].Click += new EventHandler(bntton_Click);
                }
            }
            else
            {
                panel7.Visible = false;
                isbtn = !isbtn;
            }
        }
        private void bntton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("点击了 " + ((Button)sender).Name.ToString());
        }

    }
}
