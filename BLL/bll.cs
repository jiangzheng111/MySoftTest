using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MODEL;
using DAL;
using System.Text.RegularExpressions;
using myTool;
//业务层
namespace BLL
{
    public class bll
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
        public string select(int suserid, string suserpwd)
        {
            sqlLink SQLLINK = new sqlLink();//实例化链接数据库 在这里想表达的意思是已经链接数据库，只用这个一行代码。以后想改要对数据库的操作代码，就不用改这一行代码，只要找到对应的类的对应的方法修改即可食用。调用均有这个意思以下皆是。
            Suser SUSER = SQLLINK.select(suserid, suserpwd);//实例化用户表 传用户输入的账号和密码

            if (SUSER != null && SUSER.SuserId == suserid)
            {
                if (SUSER.SuserPwd == suserpwd)
                {
                    return TextString.successful;
                }
                return TextString.failure;
            }
            return TextString.No_Such_Account;
        }

        public string insert(string susername, string suserpwd, string suseremail, string emailcode)
        {
            sqlLink SQLLINK = new sqlLink();
            if (susername != null || suserpwd != null || suseremail != null)
            {
                if (susername != "昵称" && suserpwd != "密码")
                {
                    //var a = Regex.IsMatch(suseremail, str);
                    //if (a)
                    //{
                    //    //if (emailcode=="")
                    //    //{
                    //    Suser SUSER = SQLLINK.insert(susername, suserpwd, suseremail);
                    //    return TextString.successful;
                    //    //}

                    //}
                    if (bll.isRight(suseremail, emailcode))
                    {
                        Suser SUSER = SQLLINK.insert(susername, suserpwd, suseremail);
                        return TextString.successful;
                        //return "终于成功了";
                    }
                    return TextString.emailError;

                }
                return TextString.regError + "1";
            }
            return "";
        }

        public string emailCode(string suseremail)//要差一个判断邮箱是否存在
        {
            var str = "([a-zA-Z0-9_\\.\\-])+\\@(([a-zA-Z0-9\\-])+\\.)+([a-zA-Z0-9]{2,5})+";
            var a = Regex.IsMatch(suseremail, str);
            if (!a)
            {
                return TextString.emailError;
            }
            return "发送成功";
        }

        public static bool isRight(string suseremail, string emailcode)
        {
            if (emailcode == myTool.sendEmail.thisrandomcode)
            {
                return true;
            }
            return false;
        }
    }
}
