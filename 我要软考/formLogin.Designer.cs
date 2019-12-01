namespace 我要软考
{
    partial class formLogin
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formLogin));
            this.btnLogin = new System.Windows.Forms.Button();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtPwd = new System.Windows.Forms.TextBox();
            this.linkReg = new System.Windows.Forms.LinkLabel();
            this.linkRePwd = new System.Windows.Forms.LinkLabel();
            this.loginlbl = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnMin = new System.Windows.Forms.Button();
            this.btnMax = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.miN_MAX_EXIT1 = new UI.MIN_MAX_EXIT();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(53, 243);
            this.btnLogin.Margin = new System.Windows.Forms.Padding(4);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(311, 32);
            this.btnLogin.TabIndex = 0;
            this.btnLogin.Text = "安全登录";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // txtEmail
            // 
            this.txtEmail.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtEmail.Location = new System.Drawing.Point(53, 109);
            this.txtEmail.Margin = new System.Windows.Forms.Padding(4);
            this.txtEmail.MaxLength = 17;
            this.txtEmail.Multiline = true;
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(312, 42);
            this.txtEmail.TabIndex = 1;
            this.txtEmail.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtEmail_MouseClick);
            // 
            // txtPwd
            // 
            this.txtPwd.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtPwd.Location = new System.Drawing.Point(53, 177);
            this.txtPwd.Margin = new System.Windows.Forms.Padding(4);
            this.txtPwd.MaxLength = 9;
            this.txtPwd.Multiline = true;
            this.txtPwd.Name = "txtPwd";
            this.txtPwd.Size = new System.Drawing.Size(312, 42);
            this.txtPwd.TabIndex = 2;
            this.txtPwd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtPwd.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtPwd_MouseClick);
            // 
            // linkReg
            // 
            this.linkReg.AutoSize = true;
            this.linkReg.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.linkReg.LinkColor = System.Drawing.Color.Gray;
            this.linkReg.Location = new System.Drawing.Point(0, 301);
            this.linkReg.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.linkReg.Name = "linkReg";
            this.linkReg.Size = new System.Drawing.Size(67, 15);
            this.linkReg.TabIndex = 3;
            this.linkReg.TabStop = true;
            this.linkReg.Text = "注册账号";
            this.linkReg.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.linkReg.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkReg_LinkClicked);
            // 
            // linkRePwd
            // 
            this.linkRePwd.AutoSize = true;
            this.linkRePwd.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.linkRePwd.LinkColor = System.Drawing.Color.Gray;
            this.linkRePwd.Location = new System.Drawing.Point(350, 301);
            this.linkRePwd.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.linkRePwd.Name = "linkRePwd";
            this.linkRePwd.Size = new System.Drawing.Size(67, 15);
            this.linkRePwd.TabIndex = 4;
            this.linkRePwd.TabStop = true;
            this.linkRePwd.Text = "找回密码";
            this.linkRePwd.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkRePwd_LinkClicked);
            // 
            // loginlbl
            // 
            this.loginlbl.AutoSize = true;
            this.loginlbl.Location = new System.Drawing.Point(156, 301);
            this.loginlbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.loginlbl.Name = "loginlbl";
            this.loginlbl.Size = new System.Drawing.Size(71, 15);
            this.loginlbl.TabIndex = 5;
            this.loginlbl.Text = "loginlbl";
            this.loginlbl.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(148, 45);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 24);
            this.label2.TabIndex = 6;
            this.label2.Text = "我要软考";
            // 
            // btnMin
            // 
            this.btnMin.Location = new System.Drawing.Point(300, 9);
            this.btnMin.Name = "btnMin";
            this.btnMin.Size = new System.Drawing.Size(32, 30);
            this.btnMin.TabIndex = 7;
            this.btnMin.Text = "一";
            this.btnMin.UseVisualStyleBackColor = false;
            this.btnMin.Visible = false;
            // 
            // btnMax
            // 
            this.btnMax.Location = new System.Drawing.Point(338, 8);
            this.btnMax.Name = "btnMax";
            this.btnMax.Size = new System.Drawing.Size(32, 30);
            this.btnMax.TabIndex = 8;
            this.btnMax.Text = "口";
            this.btnMax.UseVisualStyleBackColor = false;
            this.btnMax.Visible = false;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(376, 9);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(32, 30);
            this.btnClose.TabIndex = 9;
            this.btnClose.Text = "×";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Visible = false;
            // 
            // miN_MAX_EXIT1
            // 
            this.miN_MAX_EXIT1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.miN_MAX_EXIT1.ForeColor = System.Drawing.Color.Black;
            this.miN_MAX_EXIT1.Location = new System.Drawing.Point(12, 12);
            this.miN_MAX_EXIT1.Name = "miN_MAX_EXIT1";
            this.miN_MAX_EXIT1.Opacity = 0;
            this.miN_MAX_EXIT1.Size = new System.Drawing.Size(108, 30);
            this.miN_MAX_EXIT1.TabIndex = 10;
            this.miN_MAX_EXIT1.WindowState = System.Windows.Forms.FormWindowState.Normal;
            this.miN_MAX_EXIT1.Load += new System.EventHandler(this.miN_MAX_EXIT1_Load);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(59, 117);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(44, 25);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.White;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(59, 181);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(44, 31);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 12;
            this.pictureBox2.TabStop = false;
            // 
            // textBox1
            // 
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Location = new System.Drawing.Point(0, 330);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(421, 18);
            this.textBox1.TabIndex = 14;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.pictureBox3.Image = global::UI.Properties.Resources.向上;
            this.pictureBox3.Location = new System.Drawing.Point(403, 330);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(18, 18);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 15;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Click += new System.EventHandler(this.pictureBox3_Click);
            // 
            // formLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(421, 325);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.miN_MAX_EXIT1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnMax);
            this.Controls.Add(this.btnMin);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.loginlbl);
            this.Controls.Add(this.linkRePwd);
            this.Controls.Add(this.linkReg);
            this.Controls.Add(this.txtPwd);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.btnLogin);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(421, 347);
            this.MinimumSize = new System.Drawing.Size(421, 325);
            this.Name = "formLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Login_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Login_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Login_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Login_MouseUp);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtPwd;
        private System.Windows.Forms.LinkLabel linkReg;
        private System.Windows.Forms.LinkLabel linkRePwd;
        private System.Windows.Forms.Label loginlbl;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnMin;
        private System.Windows.Forms.Button btnMax;
        private System.Windows.Forms.Button btnClose;
        private UI.MIN_MAX_EXIT miN_MAX_EXIT1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.PictureBox pictureBox3;
    }
}

