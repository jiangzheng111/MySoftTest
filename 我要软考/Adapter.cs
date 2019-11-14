using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace 我要软考
{
    //https://zhuanlan.zhihu.com/p/90742531 适配器模式
    class AdapterSql
    {
        public class Isql2005
        {
            public void sql2005()
            {
                string sqlConnection = "SERVER=119.23.54.113,1433;uid=sa;DATABASE=myTest;pwd=1234abcdxlS;";//连接数据库字符串
            }
        }
        public class Ixml
        {
           public void ixml() { }
            //暂时先不实现。操作xml的语句
        }

        public class Adapter : Isql2005
        {
            Ixml ixml = new Ixml();
            public override void sql2005()
            {
                ixml.Ixml();
            }
        }

    }
}
