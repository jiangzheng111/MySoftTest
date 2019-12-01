using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace UI
{
    public partial class MIN_MAX_EXIT : UserControl
    {
        public MIN_MAX_EXIT()
        {
            InitializeComponent();
             this.Opacity = 0;
        }
        public void btnMin_Click(object sender, EventArgs e)
        {
            Form.ActiveForm.WindowState = FormWindowState.Minimized;
        }

        public void btnMax_Click(object sender, EventArgs e)
        {
            if (Form.ActiveForm.WindowState == FormWindowState.Maximized)
            {
                Form.ActiveForm.WindowState = FormWindowState.Normal;
            }
            else
            {
                Form.ActiveForm.WindowState = FormWindowState.Maximized;
            }
            //btnMax.Enabled = false;
        }

        public void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
            
        }

        public FormWindowState WindowState { get; set; }

        public int Opacity { get; set; }
    }
}
