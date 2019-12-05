using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using MODEL;
using System.Data;

//增改，还没有写完

//数据层
//系统分配账号，用户注册（昵称，密码和用户代码）
namespace DAL
{
    /// <summary>
    /// 连接数据库操作数据库
    /// </summary>
    public class sqlLink
    {
        //select * from Suser where SuserName =@susername and SuserPwd=@suserpwd
        /// <summary>
        /// 用户账号查询语句
        /// </summary>
        private string USERSELECT = "SELECT * FROM SUSER WHERE SuserEmail=@suseremail ";

        /// <summary>
        /// 查询邮箱是否存在
        /// </summary>
        public string ISEXISTSEMAIL = "SELECT SUSEREMAIL FROM SUSER WHERE SUSEREMAIL=@suseremail";

        /// <summary>
        /// 增加用户账号语句
        /// </summary>
        private string USERINSER = "INSERT INTO SUSER(suseremail,suserpwd,susername) VALUES (@suseremail,@suserpwd,@susername)";

        /// <summary>
        /// 用户密码修改
        /// </summary>
        private string USERUPDATE = "UPDATE SUSER SET SUSERPWD =@suserpwd WHERE SUSEREMAIL=@suseremail";

        /// <summary>
        /// SqlDataReader对象
        /// </summary>
        public static SqlDataReader SQLDR;
        //string count = "server=.;DATABASE=MyAtm;Integrated Security=true;";//连接数据库字符串

        /// <summary>
        /// 实例化Suser
        /// </summary>
        static Suser SUSER = new Suser();

        /// <summary>
        /// 连接数据库字符串
        /// </summary>
        /// <returns>sqlConnection</returns>
        public static string sqlcon()
        {
            //119.23.54.113,1433
            string sqlConnection = "SERVER=119.23.54.113,1433;uid=sa;DATABASE=myTest;pwd=1234abcdxlS;";
            return sqlConnection;
        }

        /// <summary>
        /// 账号验证
        /// </summary>
        /// <param name="susername">用户名</param>
        /// <param name="suserpwd">密码</param>
        /// <returns>Suser用户实体类</returns>
        public Suser select(string suseremail, string suserpwd)
        {
            using (SqlConnection CON = new SqlConnection(sqlcon()))
            {
                CON.Open();
                using (SqlCommand CMD = new SqlCommand(USERSELECT, CON))
                {
                    CMD.Parameters.AddWithValue("@suseremail", suseremail);
                    CMD.Parameters.AddWithValue("@suserpwd", suserpwd);
                    SQLDR = CMD.ExecuteReader();
                    if (SQLDR.Read())
                    {
                        SUSER.SuserEmail = SQLDR["SuserEmail"].ToString().Trim();
                        SUSER.SuserPwd = SQLDR["SuserPwd"].ToString().Trim();
                        SUSER.SuserAdmin = SQLDR["SuserAdmin"].ToString().Trim();
                        SQLDR.Close();
                    }
                    CMD.Dispose();
                    CON.Close();
                }
            }
            return SUSER;
        }

        //判断是否上线，上线为true，下线为false
        //这是一个大工程，要创建服务端，这位客户端，服务端与客户端间用套接字传送信息，服务端根据连接的ip有无，从而判断用户是否下线，若下线了，则根据送过来的ip地址，和账号，把它的数据库上线状态改为false
        public static Suser isOnLine()
        {
            //if (SUSER.SuserOnLine == "false")
            //{ SUSER.SuserOnLine = "true"; }//暂时先不是用这个功能
            //else
            //{ SUSER.SuserOnLine = "false"; }

            using (SqlConnection CON = new SqlConnection(sqlcon()))
            {
                CON.Open();
                using (SqlCommand CMD = new SqlCommand("UPDATE SUSER SET SUSERONLINE=@suseronline where SUSEREMAIL=@suseremail", CON))
                {
                    CMD.Parameters.AddWithValue("@suseronline", SUSER.SuserAdmin);
                    CMD.Parameters.AddWithValue("@suseremail", SUSER.SuserEmail);
                    var n = CMD.ExecuteNonQuery();
                    CMD.Dispose();
                }
                CON.Close();

            }
            return SUSER;
        }

        //注册账号
        public Suser insert(string susername, string suserpwd, string suseremail)
        {
            using (SqlConnection CON = new SqlConnection(sqlcon()))
            {
                CON.Open();
                using (SqlCommand CMD = new SqlCommand(USERINSER, CON))
                {
                    CMD.Parameters.AddWithValue("@susername", susername);
                    CMD.Parameters.AddWithValue("@suserpwd", suserpwd);
                    CMD.Parameters.AddWithValue("@suseremail", suseremail);
                    var a = CMD.ExecuteNonQuery();//执行语句
                    CMD.Dispose();
                }
                CON.Close();
            }
            return SUSER;
        }

        /// <summary>
        /// isExistsEmail 查询邮箱是否存在
        /// </summary>
        /// <param name="suseremail">邮箱</param>
        /// <returns>SUSER</returns>
        public Suser isExistsEmail(string suseremail)
        {
            using (SqlConnection CON = new SqlConnection(sqlcon()))
            {
                CON.Open();
                using (SqlCommand CMD = new SqlCommand(ISEXISTSEMAIL, CON))
                {
                    CMD.Parameters.AddWithValue("@suseremail", suseremail);
                    SQLDR = CMD.ExecuteReader();
                    if (SQLDR.Read())
                    {
                        SUSER.SuserEmail = SQLDR["SuserEmail"].ToString().Trim();
                        SQLDR.Close();
                    }
                    CMD.Dispose();
                }
                CON.Close();
            }
            return SUSER;
        }

        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="susername">邮箱</param>
        /// <param name="suserpwd">密码</param>
        /// <returns>SUSER</returns>
        public Suser update(string suseremail, string suserpwd)
        {
            using (SqlConnection CON = new SqlConnection(sqlcon()))
            {
                CON.Open();
                using (SqlCommand CMD = new SqlCommand(USERUPDATE, CON))
                {
                    CMD.Parameters.AddWithValue("@suseremail", suseremail);
                    CMD.Parameters.AddWithValue("@suserpwd", suserpwd);
                    var n = CMD.ExecuteNonQuery();
                    CMD.Dispose();
                }
                CON.Close();
            }
            return SUSER;
        }
    }

    /// <summary>
    /// 使用题目的操作对象
    /// </summary>
    public class useQuestion
    {
        public static Questionbank QUESTIONBANK = new Questionbank();
        public static Question QUESTION = new Question();
        public static answerQuestions ANSWERQUESTIONS = new answerQuestions();
        public static int[] qBId;//储存对应的题库号，作用--》然后给查询个个信息
        /// <summary>
        /// 根据题库id 查询年份上下午题
        /// </summary>
        private static string selectQuestionbank = "SELECT * FROM QUESTIONBANK WHERE qBId=@qBId";
        //select Max(a) a from A"

        /// <summary>
        /// 根据题库id和题号id查询对应的题目
        /// </summary>
        private static string selectQuestion = "SELECT * FROM QUESTION WHERE qBId=@qBId AND qId=@qId";

        /// <summary>
        /// 插入用户答题的记录 题号id 题库id 邮箱 自己选择的答案
        /// </summary>
        private static string insertAnswerQuestions = "INSERT INTO  AnswerQuestions(qId ,qBId ,SuserEmail,myanswer,Wrong,collection) VALUES (@qId,@qBId,@SuserEmail,@myanswer,@Wrong,@collection)";

        //"INSERT INTO SUSER(suseremail,suserpwd,susername) VALUES (@suseremail,@suserpwd,@susername)";

        /// <summary>
        /// 查询用户的答题记录
        /// </summary>
        private static string selectAnswerQuestions = "SELECT * FROM ANSWERQUESTIONS WHERE SuserEmail=@SuserEmail AND qBId=@qBId AND qId=@qId";

        /// <summary>
        /// 修改用户的收藏
        /// </summary>
        private static string updateCollection = "UPDATE ANSWERQUESTIONS SET myanswer=@myanswer,Wrong =@Wrong,collection=@collection where SuserEmail=@SuserEmail AND qBId=@qBId AND qId=@qId";


        /// <summary>
        /// 读取题库中的数据
        /// </summary>
        /// <param name="qbid">题库号</param>
        /// <returns>Questionbank</returns>
        public static Questionbank readQuestionbank(int qbid)
        {
            using (SqlConnection CON = new SqlConnection(sqlLink.sqlcon()))
            {
                CON.Open();
                using (SqlCommand CMD = new SqlCommand(selectQuestionbank, CON))
                {
                    CMD.Parameters.AddWithValue("@qBId", qbid);
                    sqlLink.SQLDR = CMD.ExecuteReader();
                    if (sqlLink.SQLDR.Read())
                    {
                        QUESTIONBANK.qBId = int.Parse(sqlLink.SQLDR["qBId"].ToString().Trim());
                        QUESTIONBANK.qBType = sqlLink.SQLDR["qBType"].ToString().Trim();
                        QUESTIONBANK.qByearsType = sqlLink.SQLDR["qByearsType"].ToString().Trim();
                        QUESTIONBANK.qBdayType = sqlLink.SQLDR["qBdayType"].ToString().Trim();

                    }
                    sqlLink.SQLDR.Close();
                    CMD.Dispose();
                }
                CON.Close();
            }
            return QUESTIONBANK;
        }

        /// <summary>
        /// 读取题目的数据
        /// </summary>
        /// <param name="qbid">题库id</param>
        /// <param name="qid">题号id</param>
        /// <returns>Question</returns>
        /// 
        public static Question readQuestion(int qbid, int qid)
        {
            using (SqlConnection CON = new SqlConnection(sqlLink.sqlcon()))
            {
                CON.Open();
                using (SqlCommand CMD = new SqlCommand(selectQuestion, CON))
                {
                    //qid++;
                    CMD.Parameters.AddWithValue("@qBId", qbid);
                    CMD.Parameters.AddWithValue("@qId", qid);
                    sqlLink.SQLDR = CMD.ExecuteReader();
                    if (sqlLink.SQLDR.Read())
                    {
                        QUESTION.qId = int.Parse(sqlLink.SQLDR["qId"].ToString().Trim());
                        QUESTION.qBId = int.Parse(sqlLink.SQLDR["qBId"].ToString().Trim());
                        QUESTION.question = sqlLink.SQLDR["question"].ToString().Trim();
                        QUESTION.answerA = sqlLink.SQLDR["answerA"].ToString().Trim();
                        QUESTION.answerB = sqlLink.SQLDR["answerB"].ToString().Trim();
                        QUESTION.answerC = sqlLink.SQLDR["answerC"].ToString().Trim();
                        QUESTION.answerD = sqlLink.SQLDR["answerD"].ToString().Trim();
                        QUESTION.parsing = sqlLink.SQLDR["parsing"].ToString().Trim();
                        QUESTION.answer = sqlLink.SQLDR["answer"].ToString().Trim();
                        QUESTION.comments = sqlLink.SQLDR["comments"].ToString().Trim();
                        sqlLink.SQLDR.Close();
                    }
                }
                CON.Close();
            }
            return QUESTION;
        }

        ////用户状态表
        //static Question_answerQuestions QUESTION_ANSWERQUESTIONS = new Question_answerQuestions();
        //public static Question_answerQuestions readA_Q()
        //{
        //    //先读取有没有数据存在，

        //    return QUESTION_ANSWERQUESTIONS;
        //}

        //读写要分离
        //读 要依据题号，题库号读取就ok了
        //写要依据题号，题库号，邮箱, 是否错题 而来写


        public static answerQuestions setAnswerQuestions(int qId, int qBId, string SuserEmail, string myAnswer)
        {
            //判断作答的记录是否已经存在
            Boolean Wrong = false;//标识是否错题
            //用来判断是否是错题
            using (SqlConnection CON = new SqlConnection(sqlLink.sqlcon()))
            {
                CON.Open();
                using (SqlCommand CMD = new SqlCommand("select * from Question where qId=@qId and qBId=@qBId", CON))
                {
                    CMD.Parameters.AddWithValue("@qId", qId);
                    CMD.Parameters.AddWithValue("@qBId", qBId);
                    sqlLink.SQLDR = CMD.ExecuteReader();
                    if (sqlLink.SQLDR.Read())
                    {
                        //这三条语句表示是否存在记录
                        ANSWERQUESTIONS.qId = int.Parse(sqlLink.SQLDR["qId"].ToString().Trim());
                        ANSWERQUESTIONS.qBId = int.Parse(sqlLink.SQLDR["qId"].ToString().Trim());
                        //ANSWERQUESTIONS.SuserEmail = sqlLink.SQLDR["SuserEmail"].ToString().Trim();

                        QUESTION.answer = sqlLink.SQLDR["answer"].ToString().Trim();//获取正确答案
                        sqlLink.SQLDR.Close();
                        CON.Close();
                    }
                    if (myAnswer != QUESTION.answer)//比较作答的答案和正确的答案
                    {
                        Wrong = true;//标识是错题
                    }
                    else
                    {
                        Wrong = false;//标识不是错题
                    }
                    if (ANSWERQUESTIONS.SuserEmail == string.Empty)
                    {
                        //表示没有这个记录就可以插入
                        using (SqlConnection ThisCON = new SqlConnection(sqlLink.sqlcon()))
                        {
                            ThisCON.Open();
                            using (SqlCommand ThisCMD = new SqlCommand("insert into answerQuestions(qId,qBId,SuserEmail,myAnswer,Wrong) values(@qId,@qBId,@SuserEmail,@myAnswer,@Wrong)", ThisCON))
                            {
                                //参数化防sql注入
                                ThisCMD.Parameters.AddWithValue("@qId", qId);
                                ThisCMD.Parameters.AddWithValue("@qBId", qBId);
                                ThisCMD.Parameters.AddWithValue("@SuserEmail", SuserEmail);
                                ThisCMD.Parameters.AddWithValue("@myAnswer", myAnswer);
                                ThisCMD.Parameters.AddWithValue("@Wrong", Wrong);

                                //执行sql语句
                                ThisCMD.ExecuteNonQuery();
                            }
                            ThisCON.Close();
                        }
                    }
                    //如果有这个记录就修改记录
                    else
                    {
                        //用来修改作答
                        using (SqlConnection ThisCON = new SqlConnection(sqlLink.sqlcon()))
                        {
                            ThisCON.Open();
                            using (SqlCommand ThisCMD = new SqlCommand("update answerQuestions set myAnswer=@myAnswer ,Wrong=@Wrong where qId=@qId and qBId=@qBId and SuserEmail=@SuserEmail", ThisCON))
                            {
                                ThisCMD.Parameters.AddWithValue("@qId", qId);
                                ThisCMD.Parameters.AddWithValue("@qBId", qBId);
                                ThisCMD.Parameters.AddWithValue("@SuserEmail", SuserEmail);
                                ThisCMD.Parameters.AddWithValue("@myAnswer", myAnswer);
                                ThisCMD.Parameters.AddWithValue("@Wrong", Wrong);
                                ThisCMD.ExecuteNonQuery();
                                ThisCMD.Dispose();
                            }
                            ThisCON.Close();
                        }
                    }
                    CMD.Dispose();
                }
                //CON.Close();
            }
            return ANSWERQUESTIONS;
        }

        #region 重构了读写作答表,重构后的代码在上面
        //写入题号id，题库id，邮箱，错题
        //public static answerQuestions readSetANSWERQUESTIONS(int qId, int qBId, string SuserEmail, string myanswer, bool Wrong, bool collection, bool isRead, bool isExit)
        //{
        //    要先判断这条记录是否存在，不存在就插入，存在就修改
        //    set 题号id，题库id，邮箱
        //    先查询题号id，题库id，邮箱，是否存在 返回bool，存在就修改数据，不存在就插入


        //    读写分离
        //     读有两种读， 读取题目选项，读取答题的记录，如何区分这两种的状态呢？读题一般都是空白的没有作答， 读取作答的记录一般都已经有了记录，可以先读取作答的记录，读取作答的记录要查询邮箱，题号，题库号，如果没有找到就读题，如果有找到，就填充题
        //    using (SqlConnection CON = new SqlConnection(sqlLink.sqlcon()))
        //    {
        //        CON.Open();
        //        if (isRead)//是否查询有记录
        //        {
        //            using (SqlCommand CMD = new SqlCommand(selectAnswerQuestions, CON))
        //            {
        //                CMD.Parameters.AddWithValue("@qId", qId);
        //                CMD.Parameters.AddWithValue("@qBId", qBId);
        //                CMD.Parameters.AddWithValue("@SuserEmail", SuserEmail);
        //                CMD.Parameters.AddWithValue("@myanswer", myanswer);
        //                CMD.Parameters.AddWithValue("@Wrong", Wrong);
        //                CMD.Parameters.AddWithValue("@collection", collection);
        //                sqlLink.SQLDR = CMD.ExecuteReader();
        //                if (sqlLink.SQLDR.Read())
        //                {
        //                    ANSWERQUESTIONS.isExit = true;
        //                    sqlLink.SQLDR.Close();
        //                    CMD.Dispose();
        //                    using (SqlCommand thisCMD = new SqlCommand(updateCollection, CON))
        //                    {
        //                        thisCMD.Parameters.AddWithValue("@qId", qId);
        //                        thisCMD.Parameters.AddWithValue("@qBId", qBId);
        //                        thisCMD.Parameters.AddWithValue("@SuserEmail", SuserEmail);
        //                        thisCMD.Parameters.AddWithValue("@myanswer", myanswer);
        //                        thisCMD.Parameters.AddWithValue("@Wrong", Wrong);
        //                        thisCMD.Parameters.AddWithValue("@collection", collection);
        //                        if (thisCMD.ExecuteNonQuery() > 0)
        //                        {
        //                            ANSWERQUESTIONS.qId = qId;
        //                            ANSWERQUESTIONS.qBId = qBId;
        //                            ANSWERQUESTIONS.SuserEmail = SuserEmail;
        //                            ANSWERQUESTIONS.myanswer = myanswer;
        //                            ANSWERQUESTIONS.Wrong = Wrong;
        //                            ANSWERQUESTIONS.collection = collection;
        //                            thisCMD.Dispose();
        //                        }
        //                    }
        //                }
        //                else
        //                {
        //                    sqlLink.SQLDR.Close();
        //                    CMD.Dispose();
        //                    using (SqlCommand thisCMD = new SqlCommand(insertAnswerQuestions, CON))//插入用户作答的记录
        //                    {
        //                        thisCMD.Parameters.AddWithValue("@qId", qId);
        //                        thisCMD.Parameters.AddWithValue("@qBId", qBId);
        //                        thisCMD.Parameters.AddWithValue("@SuserEmail", SuserEmail);
        //                        thisCMD.Parameters.AddWithValue("@myanswer", myanswer);
        //                        thisCMD.Parameters.AddWithValue("@Wrong", Wrong);
        //                        thisCMD.Parameters.AddWithValue("@collection", collection);
        //                        var n = CMD.ExecuteNonQuery();
        //                        if (thisCMD.ExecuteNonQuery() > 0)
        //                        {
        //                            ANSWERQUESTIONS.qId = qId;
        //                            ANSWERQUESTIONS.qBId = qBId;
        //                            ANSWERQUESTIONS.SuserEmail = SuserEmail;
        //                            ANSWERQUESTIONS.myanswer = myanswer;
        //                            ANSWERQUESTIONS.Wrong = Wrong;
        //                            ANSWERQUESTIONS.collection = collection;
        //                        }
        //                        thisCMD.Dispose();
        //                    }
        //                    CON.Close();
        //                }
        //            }
        //        }
        //    }
        //    return ANSWERQUESTIONS;
        //}
        #endregion
    }

    public class DataSource_DataGridView
    {
        public static DataSet ds = new DataSet();
        public static DataSet getDataSet()
        {
            //String strConn = "Data Source=.;Initial Catalog=His;User ID=sa;Password=*****";
            //SqlConnection conn = new SqlConnection(strConn);
            //String sql = "select * from EMPLOYEE ";
            //conn.Open();
            //SqlCommand cmd = new SqlCommand(sqlId, conn);
            //SqlDataAdapter da = new SqlDataAdapter(cmd);
            //DataSet ds = new DataSet();
            //da.Fill(ds, "EMPLOYEE");
            //dataGridView1.DataSource = ds;
            //this.dataGridView1.AutoGenerateColumns = false;//是否自动生成列
            //dataGridView1.DataMember = "EMPLOYEE";
            //conn.Close(); 

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
            return ds;
        }
    }
}
