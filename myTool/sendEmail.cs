using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Mail;
using MODEL;
using System.Threading;
namespace myTool
{
    /// <summary>
    /// 发送邮件
    /// </summary>


    public class sendEmail
    {
        /// <summary>
        /// sendemail
        /// </summary>
        /// <param name="eMail">邮箱</param>
        /// <param name="eMailContent">邮件内容</param>
        /// <param name="theme">邮件主题</param>
        /// <returns>return TextString</returns>
        public string sendemail(string eMail, string eMailContent, string theme)
        {
            eMailContent = randomCode();
            //确定smtp服务器地址 实例化一个Smtp客户端
            SmtpClient smtpClient = new SmtpClient();
            smtpClient.Host = MODEL.TextString.smtpService;
            //smtpClient.Port = "";//qq邮箱可以不用端口
            //构建发件地址和收件地址
            MailAddress sendAddress = new MailAddress(MODEL.TextString.myEmail, "我要软考验证码");
            MailAddress receiverAddress = new MailAddress(eMail);
            //构造一个Email的Message对象 内容信息
            MailMessage message = new MailMessage(sendAddress, receiverAddress);
            message.Subject = TextString.subject + DateTime.Now + TextString.time;
            message.SubjectEncoding = Encoding.UTF8;
            message.Body = eMailContent;
            message.BodyEncoding = Encoding.UTF8;
            //设置邮件的信息 如登陆密码 账号
            //邮件发送方式  通过网络发送到smtp服务器
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            //如果服务器支持安全连接，则将安全连接设为true
            smtpClient.EnableSsl = true;
            try
            {
                smtpClient.UseDefaultCredentials = false;
                //发件用户登陆信息
                NetworkCredential senderCredential = new NetworkCredential(MODEL.TextString.myEmail, MODEL.TextString.Authorization_code);
                smtpClient.Credentials = senderCredential;
                //发送邮件
                smtpClient.Send(message);
                return MODEL.TextString.successful;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        static Random random = new Random();
        static string randomcode1 = "1234567890abcdefghijklmnopqrstuvwxyz";
        static string randomcode2 = "ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
        static string randomcode3 = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
        static string randomcode4 = "abcdefghijklmxUVWXYZ1234567890";
        static string randomcode5 = "abcdeFGHIJKLMNOPQRSTUVWXYZ1234567894567890";
        static string randomcode6 = "1234567890abpqrszABCDEFGHIJWXY7890";


        public static string thisrandomcode = "";
        /// <summary>
        /// 随机生成验证码
        /// </summary>
        /// <returns>string randomcode</returns>
        public static string randomCode()
        {

            thisrandomcode = randomcode1.Substring(random.Next(0, randomcode1.Length), 1);
            thisrandomcode += randomcode2.Substring(random.Next(0, randomcode2.Length), 1);
            thisrandomcode += randomcode3.Substring(random.Next(0, randomcode3.Length), 1);
            thisrandomcode += randomcode4.Substring(random.Next(0, randomcode4.Length), 1);
            thisrandomcode += randomcode5.Substring(random.Next(0, randomcode5.Length), 1);
            thisrandomcode += randomcode6.Substring(random.Next(0, randomcode6.Length), 1);
            //thisrandomcode += thisrandomcode;
            return thisrandomcode;
        }
    }
}
