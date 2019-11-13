using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;


namespace 我要软考
{
   public class sqlHerp
    {
        //string count = "server=.;DATABASE=MyAtm;Integrated Security=true;";//连接数据库字符串
       public  string sqlcon() 
       {
           //119.23.54.113,1433
           string sqlConnection = "SERVER=119.23.54.113,1433;uid=sa;DATABASE=myTest;pwd=1234abcdxlS;";//连接数据库字符串
           return sqlConnection;
       }
    }
}
