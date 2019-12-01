using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//实体类
namespace MODEL
{
    /// <summary>
    /// Suser用户实体类
    /// </summary>
    public class Suser
    {
        public int SuserId { get; set; }
        public string SuserEmail { get; set; }
        public string SuserName { get; set; }
        public string SuserPwd { get; set; }
        public string SuserOnLine { get; set; }
    }

    /// <summary>
    /// 题库 题库号，科目(软件设计师)，类型（年份上午/下午）
    /// </summary>
    public class Questionbank
    {
        public int qBId { get; set; }
        public string qBType { get; set; }
        public string qByearsType { get; set; }
        public string qBdayType { get; set; }
    }

    /// <summary>
    /// 试卷 题号id 题库id 问题 选项ABCD，答案，解析，评论id
    /// </summary>
    public class Question
    {
        public int qId { get; set; }
        public int qBId { get; set; }
        public string question { get; set; }
        public string answerA { get; set; }
        public string answerB { get; set; }
        public string answerC { get; set; }
        public string answerD { get; set; }
        public string answer { get; set; }
        public string parsing { get; set; }
        public string comments { get; set; }
    }

    /// <summary>
    /// 用户作答表 题号id，题库id，邮箱，答案，是否错题，是否收藏
    /// </summary>
    public class answerQuestions
    {
        public int qId { get; set; }
        public int qBId { get; set; }
        public string SuserEmail { get; set; }
        public string myanswer { get; set; }
        public bool Wrong { get; set; }
        public bool collection { get; set; }
        public bool isExit { get; set; }//这是程序需要，数据库这个表中并没有这个列







    }
    /// <summary>
    /// string Msg
    /// </summary>
    public static class TextString
    {
        /// <summary>
        ///return string 登录成功
        /// </summary>
        public static string successful = "成功";

        public static string updateSuccessful = "修改成功，请重新登录";
        /// <summary>
        /// OnLine 你已在我要软考登录，不能重复登录。
        /// </summary>
        public static string onLine = "你已在我要软考登录，不能重复登录。";


        /// <summary>
        /// failure 账号或密码错误
        /// </summary>
        public static string failure = "账号或密码错误";

        /// <summary>
        /// No_Such_Account 没有此账号
        /// </summary>
        public static string No_Such_Account = "没有此账号";

        /// <summary>
        /// ExisName 昵称已存在
        /// </summary>
        public static string ExisName = "昵称已存在";

        /// <summary>
        /// regError 输入有误
        /// </summary>
        public static string regError = "输入有误";

        /// <summary>
        /// emailError 邮箱验证码错误或该邮箱已注册
        /// </summary>
        public static string emailError = "邮箱验证码错误或该邮箱已注册";

        /// <summary>
        /// emailCode 邮箱格式错误
        /// </summary>
        public static string emailCode = "邮箱格式错误或文本不能为空";

        /// <summary>
        /// emailSuccessful 注册成功
        /// </summary>
        public static string emailSuccessful = "注册成功";

        /// <summary>
        /// empty 文本框不能为空
        /// </summary>
        public static string empty = "文本框不能为空";

        /// <summary>
        /// 邮件服务器 smtp.qq.com
        /// </summary>
        public static string smtpService = "smtp.qq.com";

        /// <summary>
        /// 注册主题
        /// </summary>
        public static string insertTheme = "我要软考注册验证码";
        /// <summary>
        /// 修改密码主题
        /// </summary>
        public static string updateTheme = "我要软考修改密码验证码";

        /// <summary>
        /// subject 我要软考--账号注册 时间 
        /// </summary>
        public static string subjectInsert = "我要软考  时间 ";

        /// <summary>
        /// subhead 请不要告诉任何人！验证码：
        /// </summary>
        public static string subhead = "请不要告诉任何人！验证码：";

        /// <summary>
        /// time 有效时间为一分钟
        /// </summary>
        public static string time = "      有效时间为一分钟";

        /// <summary>
        /// 发送的邮箱 myEmail
        /// </summary>
        public static string myEmail = "1316836373@qq.com";

        /// <summary>
        /// 授权码 Authorization_code
        /// </summary>
        public static string Authorization_code = "hvehzjsfisiuiijd";

    }
}
