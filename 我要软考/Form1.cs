using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;
namespace UI
{
    public partial class Form1 : Form
    {
        //public string smtpService = "smtp.qq.com";
        //public string sendEmail = "1316836373@qq.com";
        //public string sendpwd = "13430007979hyyy";
        public Form1()
        {
            InitializeComponent();

        }
        private void button1_Click(object sender, EventArgs e)
        {
            var a = MODEL.TextString.theme;
            myTool.sendEmail sendEmail = new myTool.sendEmail();
            a = sendEmail.sendemail(textBox1.Text, textBox2.Text, a);
            MessageBox.Show(a);


            //    //确定smtp服务器地址 实例化一个Smtp客户端
            //    SmtpClient smtpClient = new SmtpClient();
            //    smtpClient.Host = smtpService;
            //    //smtpClient.Port = "";//qq邮箱可以不用端口
            //    //构建发件地址和收件地址
            //    MailAddress sendAddress = new MailAddress(sendEmail, "我要软考验证码");
            //    MailAddress receiverAddress = new MailAddress(textBox1.Text);
            //    //构造一个Email的Message对象 内容信息
            //    MailMessage message = new MailMessage(sendAddress, receiverAddress);
            //    message.Subject = "邮件主题" + DateTime.Now;
            //    message.SubjectEncoding = Encoding.UTF8;
            //    message.Body = textBox2.Text;
            //    message.BodyEncoding = Encoding.UTF8;
            //    //设置邮件的信息 如登陆密码 账号
            //    //邮件发送方式  通过网络发送到smtp服务器
            //    smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            //    //如果服务器支持安全连接，则将安全连接设为true
            //    smtpClient.EnableSsl = true;
            //    try
            //    {
            //        smtpClient.UseDefaultCredentials = false;
            //        //发件用户登陆信息
            //        NetworkCredential senderCredential = new NetworkCredential(sendEmail, "hvehzjsfisiuiijd");
            //        smtpClient.Credentials = senderCredential;
            //        //发送邮件
            //        smtpClient.Send(message);
            //        MessageBox.Show("发送成功!");
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show(ex.Message);
            //    }
            //地址https://jingyan.baidu.com/article/0320e2c12e2f2d1b86507b46.html
        }
    }
}
