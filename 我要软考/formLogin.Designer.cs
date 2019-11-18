namespace 我要软考
{
    partial class Login
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
            this.btnLogin = new System.Windows.Forms.Button();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtPwd = new System.Windows.Forms.TextBox();
            this.linkReg = new System.Windows.Forms.LinkLabel();
            this.linkRePwd = new System.Windows.Forms.LinkLabel();
            this.loginlbl = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnMin = new System.Windows.Forms.Button();
            this.btnMax = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.miN_MAX_EXIT1 = new UI.MIN_MAX_EXIT();
            this.SuspendLayout();
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(100, 231);
            this.btnLogin.Margin = new System.Windows.Forms.Padding(4);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(212, 32);
            this.btnLogin.TabIndex = 0;
            this.btnLogin.Text = "安全登录";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // txtName
            // 
            this.txtName.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtName.Location = new System.Drawing.Point(101, 109);
            this.txtName.Margin = new System.Windows.Forms.Padding(4);
            this.txtName.Multiline = true;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(211, 28);
            this.txtName.TabIndex = 1;
            this.txtName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtPwd
            // 
            this.txtPwd.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtPwd.Location = new System.Drawing.Point(101, 177);
            this.txtPwd.Margin = new System.Windows.Forms.Padding(4);
            this.txtPwd.MaxLength = 16;
            this.txtPwd.Multiline = true;
            this.txtPwd.Name = "txtPwd";
            this.txtPwd.Size = new System.Drawing.Size(211, 28);
            this.txtPwd.TabIndex = 2;
            this.txtPwd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // linkReg
            // 
            this.linkReg.AutoSize = true;
            this.linkReg.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
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
            this.miN_MAX_EXIT1.Location = new System.Drawing.Point(12, 8);
            this.miN_MAX_EXIT1.Name = "miN_MAX_EXIT1";
            this.miN_MAX_EXIT1.Opacity = 0;
            this.miN_MAX_EXIT1.Size = new System.Drawing.Size(108, 30);
            this.miN_MAX_EXIT1.TabIndex = 10;
            this.miN_MAX_EXIT1.WindowState = System.Windows.Forms.FormWindowState.Normal;
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(421, 325);
            this.Controls.Add(this.miN_MAX_EXIT1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnMax);
            this.Controls.Add(this.btnMin);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.loginlbl);
            this.Controls.Add(this.linkRePwd);
            this.Controls.Add(this.linkReg);
            this.Controls.Add(this.txtPwd);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.btnLogin);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximumSize = new System.Drawing.Size(421, 325);
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Login_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Login_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Login_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Login_MouseUp);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtPwd;
        private System.Windows.Forms.LinkLabel linkReg;
        private System.Windows.Forms.LinkLabel linkRePwd;
        private System.Windows.Forms.Label loginlbl;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnMin;
        private System.Windows.Forms.Button btnMax;
        private System.Windows.Forms.Button btnClose;
        private UI.MIN_MAX_EXIT miN_MAX_EXIT1;
    }
}

