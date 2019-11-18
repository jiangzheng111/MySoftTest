namespace UI
{
    partial class formReg
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formReg));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblcode = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtPwd = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.btnReg = new System.Windows.Forms.Button();
            this.btnGet = new System.Windows.Forms.Button();
            this.miN_MAX_EXIT1 = new UI.MIN_MAX_EXIT();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(-3, -4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(152, 382);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 15;
            this.pictureBox1.TabStop = false;
            // 
            // lblcode
            // 
            this.lblcode.AutoSize = true;
            this.lblcode.Location = new System.Drawing.Point(147, 280);
            this.lblcode.Name = "lblcode";
            this.lblcode.Size = new System.Drawing.Size(68, 15);
            this.lblcode.TabIndex = 25;
            this.lblcode.Text = " 验证码 ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 6.6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(154, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 11);
            this.label2.TabIndex = 23;
            this.label2.Text = "每一天，都在提分";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(152, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(152, 17);
            this.label1.TabIndex = 22;
            this.label1.Text = "欢迎注册我要软考";
            // 
            // txtEmail
            // 
            this.txtEmail.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtEmail.Location = new System.Drawing.Point(156, 223);
            this.txtEmail.Margin = new System.Windows.Forms.Padding(4);
            this.txtEmail.Multiline = true;
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(211, 28);
            this.txtEmail.TabIndex = 21;
            this.txtEmail.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtEmail.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtEmail_MouseClick);
            // 
            // txtPwd
            // 
            this.txtPwd.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtPwd.Location = new System.Drawing.Point(156, 168);
            this.txtPwd.Margin = new System.Windows.Forms.Padding(4);
            this.txtPwd.Multiline = true;
            this.txtPwd.Name = "txtPwd";
            this.txtPwd.Size = new System.Drawing.Size(211, 28);
            this.txtPwd.TabIndex = 20;
            this.txtPwd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtPwd.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtPwd_MouseClick);
            // 
            // txtName
            // 
            this.txtName.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtName.Location = new System.Drawing.Point(156, 113);
            this.txtName.Margin = new System.Windows.Forms.Padding(4);
            this.txtName.Multiline = true;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(211, 28);
            this.txtName.TabIndex = 19;
            this.txtName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtName.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtName_MouseClick);
            // 
            // txtCode
            // 
            this.txtCode.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtCode.Location = new System.Drawing.Point(267, 275);
            this.txtCode.Multiline = true;
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(100, 25);
            this.txtCode.TabIndex = 18;
            this.txtCode.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtCode_MouseClick);
            // 
            // btnReg
            // 
            this.btnReg.BackColor = System.Drawing.SystemColors.Control;
            this.btnReg.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnReg.Location = new System.Drawing.Point(154, 332);
            this.btnReg.Name = "btnReg";
            this.btnReg.Size = new System.Drawing.Size(213, 46);
            this.btnReg.TabIndex = 17;
            this.btnReg.Text = "立即注册";
            this.btnReg.UseVisualStyleBackColor = false;
            this.btnReg.Click += new System.EventHandler(this.btnReg_Click);
            // 
            // btnGet
            // 
            this.btnGet.Location = new System.Drawing.Point(209, 275);
            this.btnGet.Name = "btnGet";
            this.btnGet.Size = new System.Drawing.Size(52, 24);
            this.btnGet.TabIndex = 26;
            this.btnGet.Text = "获取";
            this.btnGet.UseVisualStyleBackColor = true;
            this.btnGet.Click += new System.EventHandler(this.btnGet_Click);
            // 
            // miN_MAX_EXIT1
            // 
            this.miN_MAX_EXIT1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.miN_MAX_EXIT1.ForeColor = System.Drawing.Color.Black;
            this.miN_MAX_EXIT1.Location = new System.Drawing.Point(154, 10);
            this.miN_MAX_EXIT1.Name = "miN_MAX_EXIT1";
            this.miN_MAX_EXIT1.Opacity = 0;
            this.miN_MAX_EXIT1.Size = new System.Drawing.Size(108, 30);
            this.miN_MAX_EXIT1.TabIndex = 24;
            this.miN_MAX_EXIT1.WindowState = System.Windows.Forms.FormWindowState.Normal;
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // formReg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(370, 378);
            this.Controls.Add(this.btnGet);
            this.Controls.Add(this.lblcode);
            this.Controls.Add(this.miN_MAX_EXIT1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.txtPwd);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.txtCode);
            this.Controls.Add(this.btnReg);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "formReg";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "formReg";
            this.Load += new System.EventHandler(this.formReg_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblcode;
        private MIN_MAX_EXIT miN_MAX_EXIT1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtPwd;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.Button btnReg;
        private System.Windows.Forms.Button btnGet;
        private System.Windows.Forms.Timer timer1;
    }
}