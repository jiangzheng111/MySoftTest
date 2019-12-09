using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using BLL;
using DAL;

namespace UI
{
    public partial class admin : Form
    {
        public admin()
        {
            InitializeComponent();
        }
        public static DataSet ds = new DataSet();
        private void admin_Load(object sender, EventArgs e)
        {
            Display();
            button2_Click(sender, e);
        }

        DataGridViewCellEventArgs ee;
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            foreach (Control item in Controls)
            {
                if (item is TextBox)
                {
                    item.Text = string.Empty;
                }
            }
            //textBox1.Text =  dataGridView1.CurrentRow.Index.ToString();
            myHeaderText();
            textBox1.Text = this.dataGridView1.CurrentRow.Cells["qId"].Value.ToString();
            textBox2.Text = this.dataGridView1.CurrentRow.Cells["qBId"].Value.ToString();
            textBox3.Text = this.dataGridView1.CurrentRow.Cells["question"].Value.ToString();
            textBox4.Text = this.dataGridView1.CurrentRow.Cells["answerA"].Value.ToString();
            textBox5.Text = this.dataGridView1.CurrentRow.Cells["answerB"].Value.ToString();
            textBox6.Text = this.dataGridView1.CurrentRow.Cells["answerC"].Value.ToString();
            textBox7.Text = this.dataGridView1.CurrentRow.Cells["answerD"].Value.ToString();
            textBox8.Text = this.dataGridView1.CurrentRow.Cells["answer"].Value.ToString();
            textBox9.Text = this.dataGridView1.CurrentRow.Cells["parsing"].Value.ToString();
            textBox10.Text = this.dataGridView1.CurrentRow.Cells["comments"].Value.ToString();
            //原文链接：https://blog.csdn.net/abc13222880223/article/details/82760777
            //this.dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            //object o = this.dataGridView1.CurrentRow.Cells["qId"].Value; 
            //DataGridView1.CurrentRow.Index
        }


        public void Display()
        {
            using (SqlConnection CON = new SqlConnection(sqlLink.sqlcon()))
            {
                CON.Open();
                using (SqlCommand CMD = new SqlCommand("select * from Question", CON))
                {
                    SqlDataAdapter da = new SqlDataAdapter(CMD);
                    da.Fill(ds, "Question");
                    //da.Dispose();
                    CMD.Dispose();
                }
                CON.Close();
            }
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "Question";
        }

        //修改
        DataTable mytable = ds.Tables["Question"];
        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("确认修改题号 " + textBox1.Text + " 题库号 " + textBox2.Text + " 的内容？", "标题", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (result == DialogResult.OK)
            {
                //确定按钮的方法
                //DataTable mytable = ds.Tables["Question"];
                string commandStr = "update Question set question = @textBox3, answerA =@textBox4 ,answerB =@textBox5, answerC =@textBox6,answerD =@textBox7,answer =@textBox8, parsing =@textBox9 where qId =@textBox1 and qBId=@textBox2";
                using (SqlConnection CON = new SqlConnection(sqlLink.sqlcon()))
                {
                    CON.Open();
                    using (SqlCommand CMD = new SqlCommand(commandStr, CON))
                    {
                        CMD.Parameters.AddWithValue("@textBox1", textBox1.Text.Trim());
                        CMD.Parameters.AddWithValue("@textBox2", textBox2.Text.Trim());
                        CMD.Parameters.AddWithValue("@textBox3", textBox3.Text.Trim());
                        CMD.Parameters.AddWithValue("@textBox4", textBox4.Text.Trim());
                        CMD.Parameters.AddWithValue("@textBox5", textBox5.Text.Trim());
                        CMD.Parameters.AddWithValue("@textBox6", textBox6.Text.Trim());
                        CMD.Parameters.AddWithValue("@textBox7", textBox7.Text.Trim());
                        CMD.Parameters.AddWithValue("@textBox8", textBox8.Text.Trim());
                        CMD.Parameters.AddWithValue("@textBox9", textBox9.Text.Trim());

                        SqlDataAdapter da = new SqlDataAdapter(CMD);
                        CMD.ExecuteNonQuery();
                        ds.Tables["Question"].Clear();
                        da.Dispose();
                        CMD.Dispose();
                        MessageBox.Show("更新成功!");
                    }
                    CON.Close();
                }
                Display();
            }
            else
            {
                //取消按钮的方法
            }
        }

        public void myHeaderText()//设置dataGridView1的列名
        {
            dataGridView1.Columns[0].Width = 50;
            dataGridView1.Columns[1].Width = 50;
            dataGridView1.Columns[0].HeaderText = "题号";
            dataGridView1.Columns[1].HeaderText = "题库号";
            dataGridView1.Columns[2].HeaderText = "题目";
            dataGridView1.Columns[3].HeaderText = "选择A";
            dataGridView1.Columns[4].HeaderText = "选择B";
            dataGridView1.Columns[5].HeaderText = "选择C";
            dataGridView1.Columns[6].HeaderText = "选择D";
            dataGridView1.Columns[7].HeaderText = "答案";
            dataGridView1.Columns[8].HeaderText = "解析";
            dataGridView1.Columns[9].HeaderText = "评论";
        }

        //刷新
        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.ColumnHeadersVisible = true;
            ds.Tables["Question"].Clear();//清除表
            Display();//加载表     如果不先清楚表，就加载表，会造成表累加。
            dataGridView1_CellContentClick(sender, ee);//调用填充文本框的事件
        }

        //删除
        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("确定删除题号 " + textBox1.Text + " 题库号 " + textBox2.Text + " 的内容？", "标题", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            string commandStr = "delete from Question  where qId=@qId and qBId=@qBId";
            string ThiscommandStr = "delete from answerQuestions  where qId=@qId and qBId=@qBId";
            if (result == DialogResult.OK)
            {
                using (SqlConnection CON = new SqlConnection(sqlLink.sqlcon()))
                {
                    CON.Open();
                    using (SqlCommand CMD = new SqlCommand(commandStr, CON))
                    {
                        SqlCommand ThisCMD = new SqlCommand(ThiscommandStr, CON);
                        CMD.Parameters.AddWithValue("@qId", textBox1.Text);
                        CMD.Parameters.AddWithValue("@qBId", textBox2.Text);
                        ThisCMD.Parameters.AddWithValue("@qId", textBox1.Text);
                        ThisCMD.Parameters.AddWithValue("@qBId", textBox2.Text);
                        ThisCMD.ExecuteNonQuery();
                        CMD.ExecuteNonQuery();
                        CMD.Dispose();
                        ThisCMD.Dispose();
                        button2_Click(sender, e);
                    }
                    CON.Close();
                }
            }
        }

        //查询
        private void button4_Click(object sender, EventArgs e)
        {
            string sql = string.Format("select * from Question where qId = '{0}'and qBId='{1}'", textBox1.Text.Trim(), textBox2.Text.Trim());
            ds.Tables["Question"].Clear();
            SqlDataAdapter dataAdapter = new SqlDataAdapter(sql, sqlLink.sqlcon());
            dataAdapter.Fill(ds, "Question");
            dataGridView1.DataSource = ds.Tables["Question"];
            dataGridView1_CellContentClick(sender, ee);
        }



        private void button5_Click(object sender, EventArgs e)
        {
            foreach (Control item in Controls)
            {
                if (item is TextBox)
                {
                    if (item.Text == string.Empty)
                    {
                        MessageBox.Show("不能为空");
                        return;
                    }
                }
            }
            DialogResult result = MessageBox.Show("确定要添加这组数据？", "标题", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (result == DialogResult.OK)
            {
                using (SqlConnection CON = new SqlConnection(sqlLink.sqlcon()))
                {
                    CON.Open();
                    using (SqlCommand CMD = new SqlCommand("insert into  Question (qId,qBId,question,answerA,answerB,answerC,answerD,answer,parsing)values(@qId,@qBId,@question,@answerA,@answerB,@answerC,@answerD,@answer,@parsing)", CON))
                    {
                        CMD.Parameters.AddWithValue("@qId", textBox1.Text.Trim());
                        CMD.Parameters.AddWithValue("@qBId", textBox2.Text.Trim());
                        CMD.Parameters.AddWithValue("@question", textBox3.Text.Trim());
                        CMD.Parameters.AddWithValue("@answerA", textBox4.Text.Trim());
                        CMD.Parameters.AddWithValue("@answerB", textBox5.Text.Trim());
                        CMD.Parameters.AddWithValue("@answerC", textBox6.Text.Trim());
                        CMD.Parameters.AddWithValue("@answerD", textBox7.Text.Trim());
                        CMD.Parameters.AddWithValue("@answer", textBox8.Text.Trim());
                        CMD.Parameters.AddWithValue("@parsing", textBox9.Text.Trim());
                        CMD.ExecuteNonQuery();
                        CMD.Dispose();
                        button2_Click(sender, e);
                    }
                    CON.Close();
                }
            }
        }
        private void textBox3_MouseMove(object sender, MouseEventArgs e)
        {
            label3.Text = textBox3.SelectedText.Trim().Length.ToString();
        }
        private void textBox4_MouseMove(object sender, MouseEventArgs e)
        {
            label4.Text = textBox4.SelectedText.Trim().Length.ToString();
        }
        private void textBox5_MouseMove(object sender, MouseEventArgs e)
        {
            label5.Text = textBox5.SelectedText.Trim().Length.ToString();
        }
        private void textBox6_MouseMove(object sender, MouseEventArgs e)
        {
            label6.Text = textBox6.SelectedText.Trim().Length.ToString();
        }
        private void textBox7_MouseMove(object sender, MouseEventArgs e)
        {
            label7.Text = textBox7.SelectedText.Trim().Length.ToString();
        }
        private void textBox8_MouseMove(object sender, MouseEventArgs e)
        {
            label8.Text = textBox8.SelectedText.Trim().Length.ToString();
        }
        private void textBox9_MouseMove(object sender, MouseEventArgs e)
        {
            label9.Text = textBox9.SelectedText.Trim().Length.ToString();
        }

        private void textBox10_MouseMove(object sender, MouseEventArgs e)
        {
            label10.Text = textBox10.SelectedText.Trim().Length.ToString();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            foreach (Control item in Controls)
            {
                if (item is TextBox)
                {
                    item.Text = string.Empty;
                }
            }
        }

        private void textBox9_MouseHover(object sender, EventArgs e)
        {
            //string[] questionArray = textBox9.Text.Split(new char[] { '?' });
            //for (int i = 0; i < questionArray.Length; i++)
            //{
            //    textBox11.Text += questionArray[i].ToString() + "\n";
            //}
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            //string[] questionArray = textBox9.Text.ToString().Split(new char[] { '?' });
            //for (int i = 0; i < questionArray.Length; i++)
            //{
            //    textBox11.Text += questionArray[i].ToString() + "\n";
            //}
        }

        private void textBox9_MouseClick(object sender, MouseEventArgs e)
        {
            label1.Text = "";
            string[] questionArray = textBox9.Text.ToString().Split(new char[] { '?' });
            for (int i = 0; i < questionArray.Length; i++)
            {
                label1.Text += questionArray[i].ToString() + "\n";
            }
        }
        //————————————————
        //版权声明：本文为CSDN博主「jimk5200」的原创文章，遵循 CC 4.0 BY-SA 版权协议，转载请附上原文出处链接及本声明。
        //原文链接：https://blog.csdn.net/jimk5200/article/details/5643370

    }
}
