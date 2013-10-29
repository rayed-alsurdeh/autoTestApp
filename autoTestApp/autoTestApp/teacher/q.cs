using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace autoTestApp.teacher
{
    public partial class q : Form
    {
        int qnum;
        string tname;
        public q(string tname,int qnum=0)
        {
            this.qnum = qnum;
            this.tname = tname;
            InitializeComponent();
        }

        private void q_Load(object sender, EventArgs e)
        {
            lblTname.Text = "اختبار : " + tname;
            if (qnum == 0)
            {
                btnQ.Text = "اضافة سؤال";
            }
            else
                btnQ.Text = "تعديل سؤال";

        }
        private void clearContent()
        {

        }
    }
}
