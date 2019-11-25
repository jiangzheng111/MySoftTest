using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using MODEL;

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
                    //CMD.Parameters.AddWithValue("@susercode",susercode);
                    SQLDR = CMD.ExecuteReader();
                    if (SQLDR.Read())
                    {
                        SUSER.SuserEmail = SQLDR["SuserEmail"].ToString().Trim();
                        SUSER.SuserPwd = SQLDR["SuserPwd"].ToString().Trim();
                        SUSER.SuserOnLine = SQLDR["SuserOnLine"].ToString().Trim();
                    }
                    CON.Close();
                }
            }
            return SUSER;
        }

        //判断是否上线，上线为true，下线为false
        //这是一个大工程，要创建服务端，这位客户端，服务端与客户端间用套接字传送信息，服务端根据连接的ip有无，从而判断用户是否下线，若下线了，则根据送过来的ip地址，和账号，把它的数据库上线状态改为false
        public static Suser isOnLine()
        {
            if (SUSER.SuserOnLine == "false")
            { SUSER.SuserOnLine = "true"; }//暂时先不是用这个功能
            else
            { SUSER.SuserOnLine = "false"; }

            using (SqlConnection CON = new SqlConnection(sqlcon()))
            {
                CON.Open();
                using (SqlCommand CMD = new SqlCommand("UPDATE SUSER SET SUSERONLINE=@suseronline where SUSEREMAIL=@suseremail", CON))
                {
                    CMD.Parameters.AddWithValue("@suseronline", SUSER.SuserOnLine);
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
                        //SQLDR.Close();
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

    public class useQuestion
    {
        public static Questionbank QUESTIONBANK = new Questionbank();
        public static Question QUESTION = new Question();
        public static int[] qBId;//储存对应的题库号，作用--》然后给查询个个信息
        /// <summary>
        /// 根据题库id 查询年份上下午题
        /// </summary>
        private static string selectQuestionbank = "SELECT * FROM QUESTIONBANK WHERE qBId=@qBId";
        //select Max(a) a from A"
        private static string selectQuestion = "SELECT * FROM QUESTION WHERE qBId=@qBId AND qId=@qId";

        /// <summary>
        /// 查询选择的类型科目
        /// </summary>
        /// <param name="qBType"></param>
        /// <returns></returns>
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
        //static int qid = 1;
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
    }
}
