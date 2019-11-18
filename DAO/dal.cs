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
        private static string USERSELECT = "SELECT * FROM SUSER WHERE SUSERId=@suserid ";

        /// <summary>
        /// 查询邮箱是否存在
        /// </summary>
        public static string ISEXISTSEMAIL = "SELECT SUSEREMAIL FROM SUSER WHERE SUSEREMAIL=@suseremail";

        /// <summary>
        /// 增加用户账号语句
        /// </summary>
        private static string USERINSER = "INSERT INTO SUSER VALUES (@susername,@suseremail,@suserpwd)";

        /// <summary>
        /// 用户密码修改
        /// </summary>
        private static string USERUPDATE = "UPDARE MYTEST SET SUSERPWD =@suserpwd WHERE SUSERNAME=@suserid AND SUSERCODE=@susercode";

        /// <summary>
        /// SqlDataReader对象
        /// </summary>
        public static SqlDataReader SQLDR;
        //string count = "server=.;DATABASE=MyAtm;Integrated Security=true;";//连接数据库字符串

        /// <summary>
        /// 实例化Suser
        /// </summary>
        Suser SUSER = new Suser();

        /// <summary>
        /// 连接数据库字符串
        /// </summary>
        /// <returns>sqlConnection</returns>
        public string sqlcon()
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
        public Suser select(int suserid, string suserpwd)
        {

            using (SqlConnection CON = new SqlConnection(sqlcon()))
            {
                CON.Open();
                using (SqlCommand CMD = new SqlCommand(USERSELECT, CON))
                {
                    CMD.Parameters.AddWithValue("@suserid", suserid);
                    CMD.Parameters.AddWithValue("@suserpwd", suserpwd);
                    //CMD.Parameters.AddWithValue("@susercode",susercode);
                    SQLDR = CMD.ExecuteReader();
                    if (SQLDR.Read())
                    {
                        SUSER.SuserId = int.Parse(SQLDR["SuserId"].ToString().Trim());
                        SUSER.SuserPwd = SQLDR["SuserPwd"].ToString().Trim();
                    }
                    CON.Close();
                }
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
           using(SqlConnection CON=new SqlConnection(sqlcon()))
           {
               CON.Open();
                using(SqlCommand CMD=new SqlCommand(ISEXISTSEMAIL,CON)){
                    CMD.Parameters.AddWithValue("@suseremail", suseremail);
                    SqlDataReader SQLDR=CMD.ExecuteReader();
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

        //修改密码
        public Suser update(string susername, string suserpwd)
        {
            return SUSER;
        }
    }
}
