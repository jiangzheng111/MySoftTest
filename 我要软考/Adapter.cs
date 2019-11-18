using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace 我要软考
{
    //https://zhuanlan.zhihu.com/p/90742531 适配器模式
    public class AdapterSql
    {
        public class  Isql2005
        {
            public virtual void sql2005()
            {
                string sqlConnection = "SERVER=119.23.54.113,1433;uid=sa;DATABASE=myTest;pwd=1234abcdxlS;";//连接数据库字符串
                System.Windows.Forms.MessageBox.Show(sqlConnection);
            }
        }
        public class Ixml
        {
           public void ixml() {
               System.Windows.Forms.MessageBox.Show("ixml");
           }
            //暂时先不实现。操作xml的语句
        }

        public class Adapter1 : Isql2005
        {
            Ixml ixml = new Ixml();
            Isql2005 sql20051 = new Isql2005();
            public override void sql2005()
            {
                ixml.ixml();
                sql20051.sql2005();
                //string sqlConnection = "SERVER=119.23.54.113,1433;uid=sa;DATABASE=myTest;pwd=1234abcdxlS;";//连接数据库字符串
                //System.Windows.Forms.MessageBox.Show(sqlConnection);
            }
        }

    }
}
