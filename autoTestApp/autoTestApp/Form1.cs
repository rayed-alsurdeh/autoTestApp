using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using autoTestApp.code;

namespace autoTestApp
{
    public partial class frLogin : Form
    {
        public frLogin()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUID.Text.Trim().Length >= 1)
            {
                label4.Text = "";
                if (txtUPass.Text.Trim().Length >= 1)
                {
                    label5.Text = "";
                    if (rd1.Checked)
                    {
                        if (code.sysUsers.checkLogin(txtUID.Text.Trim(), txtUPass.Text.Trim(), 1))
                        {
                            admin.admin ad = new admin.admin();
                            this.Visible = false;
                            ad.ShowDialog();
                            this.Visible = true;
                            
                        }
                        else
                        {
                            MessageBox.Show("تاكد من بيانات الدخول");
                            txtUPass.Text = "";
                        }
                    }
                    else
                        if (rd2.Checked)
                        {

                        }
                        else
                        {

                        }
                }
                else
                {
                    label5.Text = "*";
                }
            }
            else
            {
                label4.Text = "*";
            }
        }
    }
}
