using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MODEL;
using DAL;
using System.Text.RegularExpressions;
using myTool;
using System.Data;
//业务层
namespace BLL
{
    public static class bll
    {
        /// <summary>
        /// 登录方法
        /// </summary>
        /// <param name="suserid">账号</param>
        /// <param name="suserpwd">密码</param>
        /// <param name="0">登录成功</param>
        /// <param name="1">账号或密码错误</param>
        /// <param name="2">没有此账号</param>
        /// <returns>int</returns>

        public static bool isEmpty(string suseremail, string suserpwd, string susername)
        {
            if (susername != null || suserpwd != null || suseremail != null)
            {
                if (susername != "昵称" && suserpwd != "密码" && suseremail != "邮箱")
                {
                    return false;
                }
                return true;
            }
            return true;
        }

        public static string selectUser(string suseremail, string suserpwd)
        {
            sqlLink SQLLINK = new sqlLink();
            //实例化链接数据库 在这里想表达的意思是已经链接数据库，只用这个一行代码。以后想改要对数据库的操作代码，就不用改这一行代码，只要找到对应的类的对应的方法修改即可食用。调用均有这个意思以下皆是。

            Suser SUSER = SQLLINK.select(suseremail, suserpwd);
            //实例化用户表 传用户输入的账号和密码

            if (SUSER != null && SUSER.SuserEmail == suseremail)
            {
                if (SUSER.SuserPwd == suserpwd)
                {
                    if (SUSER.SuserAdmin == "true")
                    {
                        //DAL.sqlLink.
                        //sqlLink.isOnLine();暂时不使用这个功能，不能删除
                        return SUSER.SuserAdmin;
                    }
                    else
                    {
                        return TextString.successful;
                    }
                }
                return TextString.failure;
            }
            return TextString.No_Such_Account;
        }

        public static string insertUser(string susername, string suserpwd, string suseremail, string emailcode)
        {
            sqlLink SQLLINK = new sqlLink();
            if (susername != null || suserpwd != null || suseremail != null)
            {
                if (susername != "昵称" && suserpwd != "密码")
                {
                    if (bll.isRight(suseremail, emailcode))
                    {
                        Suser SUSER = SQLLINK.insert(susername, suserpwd, suseremail);
                        return TextString.emailSuccessful;
                        //return "终于成功了";
                    }
                    return TextString.emailError;
                }
                return TextString.regError;
            }
            return TextString.empty;
        }

        /// <summary>
        /// 判断邮箱格式是否正确
        /// </summary>
        /// <param name="suseremail">邮箱</param>
        /// <returns></returns>
        public static string emailFormat(string suseremail)//
        {
            var str = "([a-zA-Z0-9_\\.\\-])+\\@(([a-zA-Z0-9\\-])+\\.)+([a-zA-Z0-9]{2,5})+";
            var a = Regex.IsMatch(suseremail, str);
            if (!a)
            {
                return TextString.emailCode;
            }
            return string.Empty;
        }

        /// <summary>
        /// 注册的时候判断邮箱是否存在，存在则不能注册
        /// </summary>
        /// <param name="suseremail">邮箱</param>
        /// <param name="emailcode">邮箱验证码</param>
        /// <returns>bool</returns>
        public static bool isRight(string suseremail, string emailcode)
        {
            sqlLink SQLLINK = new sqlLink();
            //Suser suser = new MODEL.Suser();
            //SQLLINK.isExistsEmail(suseremail);
            if (SQLLINK.isExistsEmail(suseremail).SuserEmail != suseremail)//注册的时候判断邮箱是否存在，存在则不能注册
            {
                return isEmailcode(emailcode);//判断验证码是否匹配
            }
            return false;
        }

        /// <summary>
        /// 验证码匹配
        /// </summary>
        /// <param name="emailcode"></param>
        /// <returns></returns>
        public static bool isEmailcode(string emailcode)
        {
            if (emailcode != string.Empty && emailcode == myTool.sendEmail.thisrandomcode)
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="suseremail">邮箱</param>
        /// <param name="emailpwd">密码</param>
        /// <param name="emailcode">验证码</param>
        /// <returns></returns>
        public static string updatePwd(string suseremail, string emailcode, string emailpwd)
        {
            if (suseremail != string.Empty && emailpwd != string.Empty && emailcode != string.Empty)//判断文本是否为空
            {
                if (emailFormat(suseremail) != TextString.emailCode)//判断邮箱格式是否正确
                {
                    //要判断验证码是否正确。
                    if (isEmailcode(emailcode))
                    {
                        sqlLink SQLLINK = new sqlLink();
                        SQLLINK.update(suseremail, emailpwd);
                        return "修改成功，请重新登录";
                    }
                    return "验证码错误";
                }
                return TextString.emailCode;
            }
            return TextString.empty;
        }
        //隔开


        //static Questionbank questionbank = new Questionbank();
        /// <summary>
        /// 读取科目，年份，上午题，下午题
        /// </summary>
        /// <param name="qbid">题库id</param>
        /// <returns>返回拼接的年份和上下午提</returns>
        public static string qbdaytype(int qbid)
        {
            var qBdayType = useQuestion.readQuestionbank(qbid).qBdayType.ToString();
            var qByearsType = useQuestion.readQuestionbank(qbid).qByearsType.ToString();
            return qByearsType + "\n\n" + qBdayType;
        }

        static Question USEQUESTION = new Question();

        /// <summary>
        /// 初始化试卷 根据错过来的题库id查询对应的试卷
        /// </summary>
        /// <param name="qbid">题库id</param>
        /// <param name="qId">题号id</param>
        /// <returns>string[10]</returns>
        public static string[] loadPaper(int qbid, int qId)
        {
            string[] questionArray = new string[10];
            USEQUESTION = useQuestion.readQuestion(qbid, qId);
            questionArray[0] = USEQUESTION.qId.ToString();
            questionArray[1] = USEQUESTION.qBId.ToString();
            questionArray[2] = USEQUESTION.question.ToString();
            questionArray[3] = USEQUESTION.answerA.ToString();
            questionArray[4] = USEQUESTION.answerB.ToString();
            questionArray[5] = USEQUESTION.answerC.ToString();
            questionArray[6] = USEQUESTION.answerD.ToString();
            questionArray[7] = USEQUESTION.answer.ToString();
            questionArray[8] = USEQUESTION.parsing.ToString();
            questionArray[9] = USEQUESTION.comments.ToString();
            //根据传过来的题库号，题号，查询题目，答案，解析，一系列的数据，返回到ui层
            return questionArray;
        }


        static answerQuestions ANSWERQUESTIONS = new answerQuestions();//实例化作答表

        /// <summary>
        /// 初始化作答 插入作答记录
        /// </summary>
        /// <param name="qId">题号id</param>
        /// <param name="qBId">题库id</param>
        /// <param name="SuserEmail">邮箱</param>
        /// <param name="myanswer">作答答案</param>
        /// <param name="Wrong">是否错题</param>
        /// <param name="collection">是否收藏</param>
        /// <returns>string answerArray</returns>
        public static string[] loadAnswer(int qId, int qBId, string SuserEmail, string myanswer)
        {
            string[] answerArray = new string[6];
            ANSWERQUESTIONS = useQuestion.setAnswerQuestions(qId, qBId, SuserEmail, myanswer);
            answerArray[0] = ANSWERQUESTIONS.qId.ToString();
            answerArray[1] = ANSWERQUESTIONS.qBId.ToString();
            //answerArray[2] = ANSWERQUESTIONS.SuserEmail.ToString();
            //answerArray[3] = ANSWERQUESTIONS.myanswer.ToString();
            answerArray[4] = ANSWERQUESTIONS.Wrong.ToString();
            //answerArray[5] = ANSWERQUESTIONS.collection.ToString();

            return answerArray;
        }

        //
        public static bool readCollection(int qId, int qBId, string SuserEmail)
        {
            var istrue = useQuestion.readCollection(qId, qBId, SuserEmail);
            return istrue;
        }


        //写入当前题是否收藏
        public static void setCollection(int qId, int qBId, string SuserEmail, bool isCollection)
        {
            useQuestion.setCollection(qId, qBId, SuserEmail, isCollection);
        }
        private static DataSet ds;
        public static DataSet getDataset()
        {
            ds = DataSource_DataGridView.getDataSet();
            return ds;
        }
    }
}
