namespace UI
{
    partial class admin
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.qId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qBId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.question = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.answerA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.answerB = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.answerC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.answerD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.answer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.parsing = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.comments = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button1 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.textBox10 = new System.Windows.Forms.TextBox();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.textBox9 = new System.Windows.Forms.TextBox();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.button5 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.button6 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.qId,
            this.qBId,
            this.question,
            this.answerA,
            this.answerB,
            this.answerC,
            this.answerD,
            this.answer,
            this.parsing,
            this.comments});
            this.dataGridView1.Location = new System.Drawing.Point(-1, -1);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 27;
            this.dataGridView1.Size = new System.Drawing.Size(1560, 598);
            this.dataGridView1.TabIndex = 2;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // qId
            // 
            this.qId.DataPropertyName = "qId";
            this.qId.HeaderText = "题号";
            this.qId.Name = "qId";
            this.qId.Width = 50;
            // 
            // qBId
            // 
            this.qBId.DataPropertyName = "qBId";
            this.qBId.HeaderText = "题库号";
            this.qBId.Name = "qBId";
            this.qBId.Width = 50;
            // 
            // question
            // 
            this.question.DataPropertyName = "question";
            this.question.FillWeight = 50F;
            this.question.HeaderText = "题目";
            this.question.Name = "question";
            // 
            // answerA
            // 
            this.answerA.DataPropertyName = "answerA";
            this.answerA.HeaderText = "选项A";
            this.answerA.Name = "answerA";
            // 
            // answerB
            // 
            this.answerB.DataPropertyName = "answerB";
            this.answerB.HeaderText = "选项B";
            this.answerB.Name = "answerB";
            // 
            // answerC
            // 
            this.answerC.DataPropertyName = "answerC";
            this.answerC.HeaderText = "选项C";
            this.answerC.Name = "answerC";
            // 
            // answerD
            // 
            this.answerD.DataPropertyName = "answerD";
            this.answerD.HeaderText = "选项D";
            this.answerD.Name = "answerD";
            // 
            // answer
            // 
            this.answer.DataPropertyName = "answer";
            this.answer.HeaderText = "答案";
            this.answer.Name = "answer";
            // 
            // parsing
            // 
            this.parsing.DataPropertyName = "parsing";
            this.parsing.HeaderText = "解析";
            this.parsing.Name = "parsing";
            // 
            // comments
            // 
            this.comments.DataPropertyName = "comments";
            this.comments.HeaderText = "评论号";
            this.comments.Name = "comments";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("宋体", 24F);
            this.button1.Location = new System.Drawing.Point(53, 632);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(318, 97);
            this.button1.TabIndex = 3;
            this.button1.Text = "修改";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("宋体", 24F);
            this.button3.Location = new System.Drawing.Point(404, 632);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(318, 97);
            this.button3.TabIndex = 3;
            this.button3.Text = "删除";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("宋体", 24F);
            this.button4.Location = new System.Drawing.Point(753, 632);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(318, 97);
            this.button4.TabIndex = 3;
            this.button4.Text = "查询";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(1220, 563);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(11, 12);
            this.label9.TabIndex = 17;
            this.label9.Text = "0";
            // 
            // textBox10
            // 
            this.textBox10.Location = new System.Drawing.Point(1263, 461);
            this.textBox10.Multiline = true;
            this.textBox10.Name = "textBox10";
            this.textBox10.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox10.Size = new System.Drawing.Size(260, 121);
            this.textBox10.TabIndex = 13;
            this.textBox10.MouseMove += new System.Windows.Forms.MouseEventHandler(this.textBox10_MouseMove);
            // 
            // textBox8
            // 
            this.textBox8.Location = new System.Drawing.Point(1263, 320);
            this.textBox8.Multiline = true;
            this.textBox8.Name = "textBox8";
            this.textBox8.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox8.Size = new System.Drawing.Size(260, 121);
            this.textBox8.TabIndex = 12;
            this.textBox8.MouseMove += new System.Windows.Forms.MouseEventHandler(this.textBox8_MouseMove);
            // 
            // textBox9
            // 
            this.textBox9.Location = new System.Drawing.Point(997, 461);
            this.textBox9.Multiline = true;
            this.textBox9.Name = "textBox9";
            this.textBox9.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox9.Size = new System.Drawing.Size(260, 121);
            this.textBox9.TabIndex = 14;
            this.textBox9.MouseMove += new System.Windows.Forms.MouseEventHandler(this.textBox9_MouseMove);
            // 
            // textBox7
            // 
            this.textBox7.Location = new System.Drawing.Point(997, 320);
            this.textBox7.Multiline = true;
            this.textBox7.Name = "textBox7";
            this.textBox7.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox7.Size = new System.Drawing.Size(260, 121);
            this.textBox7.TabIndex = 16;
            this.textBox7.MouseMove += new System.Windows.Forms.MouseEventHandler(this.textBox7_MouseMove);
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(1263, 183);
            this.textBox6.Multiline = true;
            this.textBox6.Name = "textBox6";
            this.textBox6.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox6.Size = new System.Drawing.Size(260, 121);
            this.textBox6.TabIndex = 15;
            this.textBox6.MouseMove += new System.Windows.Forms.MouseEventHandler(this.textBox6_MouseMove);
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(997, 183);
            this.textBox5.Multiline = true;
            this.textBox5.Name = "textBox5";
            this.textBox5.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox5.Size = new System.Drawing.Size(260, 121);
            this.textBox5.TabIndex = 8;
            this.textBox5.MouseMove += new System.Windows.Forms.MouseEventHandler(this.textBox5_MouseMove);
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(1263, 56);
            this.textBox4.Multiline = true;
            this.textBox4.Name = "textBox4";
            this.textBox4.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox4.Size = new System.Drawing.Size(260, 121);
            this.textBox4.TabIndex = 7;
            this.textBox4.MouseMove += new System.Windows.Forms.MouseEventHandler(this.textBox4_MouseMove);
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(997, 56);
            this.textBox3.Multiline = true;
            this.textBox3.Name = "textBox3";
            this.textBox3.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox3.Size = new System.Drawing.Size(260, 121);
            this.textBox3.TabIndex = 9;
            this.textBox3.MouseMove += new System.Windows.Forms.MouseEventHandler(this.textBox3_MouseMove);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(1072, 23);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(57, 27);
            this.textBox2.TabIndex = 11;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(997, 23);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(57, 27);
            this.textBox1.TabIndex = 10;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(1145, 23);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 6;
            this.button2.Text = "刷新";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(1220, 157);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(11, 12);
            this.label3.TabIndex = 18;
            this.label3.Text = "0";
            // 
            // button5
            // 
            this.button5.Font = new System.Drawing.Font("宋体", 24F);
            this.button5.Location = new System.Drawing.Point(1113, 632);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(318, 97);
            this.button5.TabIndex = 3;
            this.button5.Text = "添加";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(1220, 280);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(11, 12);
            this.label5.TabIndex = 19;
            this.label5.Text = "0";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(1220, 420);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(11, 12);
            this.label7.TabIndex = 19;
            this.label7.Text = "0";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(1487, 563);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(11, 12);
            this.label10.TabIndex = 17;
            this.label10.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(1487, 157);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(11, 12);
            this.label4.TabIndex = 18;
            this.label4.Text = "0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(1487, 280);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(11, 12);
            this.label6.TabIndex = 19;
            this.label6.Text = "0";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(1487, 420);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(11, 12);
            this.label8.TabIndex = 19;
            this.label8.Text = "0";
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(1240, 21);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(75, 23);
            this.button6.TabIndex = 6;
            this.button6.Text = "清空";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // admin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1552, 759);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.textBox10);
            this.Controls.Add(this.textBox8);
            this.Controls.Add(this.textBox9);
            this.Controls.Add(this.textBox7);
            this.Controls.Add(this.textBox6);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "admin";
            this.Text = "admin";
            this.Load += new System.EventHandler(this.admin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBox10;
        private System.Windows.Forms.TextBox textBox8;
        private System.Windows.Forms.TextBox textBox9;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridViewTextBoxColumn qId;
        private System.Windows.Forms.DataGridViewTextBoxColumn qBId;
        private System.Windows.Forms.DataGridViewTextBoxColumn question;
        private System.Windows.Forms.DataGridViewTextBoxColumn answerA;
        private System.Windows.Forms.DataGridViewTextBoxColumn answerB;
        private System.Windows.Forms.DataGridViewTextBoxColumn answerC;
        private System.Windows.Forms.DataGridViewTextBoxColumn answerD;
        private System.Windows.Forms.DataGridViewTextBoxColumn answer;
        private System.Windows.Forms.DataGridViewTextBoxColumn parsing;
        private System.Windows.Forms.DataGridViewTextBoxColumn comments;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button button6;
    }
}