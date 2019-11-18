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
        public string SuserCode { get; set; }
    }
    /// <summary>
    /// string Msg
    /// </summary>
    public class TextString
    {
        /// <summary>
        ///return string 登录成功
        /// </summary>
        public static string successful = "登录成功";
        /// <summary>
        /// return string 账号或密码错误
        /// </summary>
        public static string failure = "账号或密码错误";
        /// <summary>
        /// return string 没有此账号
        /// </summary>
        public static string No_Such_Account = "没有此账号";

        public static string ExisName = "昵称已存在";

        public static string regError = "输入有误";

        public static string emailError = "邮箱格式错误或该邮箱已注册";
        public static string emailSuccessful = "注册成功";
        /// <summary>
        /// 邮件服务器 smtp.qq.com
        /// </summary>
        public static string smtpService = "smtp.qq.com";

        /// <summary>
        /// 主题
        /// </summary>
        public static string theme = "我要软考验证码";

        public static string subject = "我要软考--账号注册 时间 ";

        public static string subhead = "请不要告诉任何人！验证码：";

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
