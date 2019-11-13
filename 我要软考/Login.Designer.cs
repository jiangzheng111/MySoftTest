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
            this.SuspendLayout();
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(102, 204);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(211, 38);
            this.btnLogin.TabIndex = 0;
            this.btnLogin.Text = "安全登录";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(102, 79);
            this.txtName.Multiline = true;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(211, 36);
            this.txtName.TabIndex = 1;
            // 
            // txtPwd
            // 
            this.txtPwd.Location = new System.Drawing.Point(102, 146);
            this.txtPwd.Multiline = true;
            this.txtPwd.Name = "txtPwd";
            this.txtPwd.Size = new System.Drawing.Size(211, 36);
            this.txtPwd.TabIndex = 2;
            // 
            // linkReg
            // 
            this.linkReg.AutoSize = true;
            this.linkReg.Location = new System.Drawing.Point(12, 281);
            this.linkReg.Name = "linkReg";
            this.linkReg.Size = new System.Drawing.Size(53, 12);
            this.linkReg.TabIndex = 3;
            this.linkReg.TabStop = true;
            this.linkReg.Text = "注册账号";
            // 
            // linkRePwd
            // 
            this.linkRePwd.AutoSize = true;
            this.linkRePwd.Location = new System.Drawing.Point(341, 281);
            this.linkRePwd.Name = "linkRePwd";
            this.linkRePwd.Size = new System.Drawing.Size(53, 12);
            this.linkRePwd.TabIndex = 4;
            this.linkRePwd.TabStop = true;
            this.linkRePwd.Text = "找回密码";
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(418, 302);
            this.Controls.Add(this.linkRePwd);
            this.Controls.Add(this.linkReg);
            this.Controls.Add(this.txtPwd);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.btnLogin);
            this.Name = "Login";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtPwd;
        private System.Windows.Forms.LinkLabel linkReg;
        private System.Windows.Forms.LinkLabel linkRePwd;
    }
}

