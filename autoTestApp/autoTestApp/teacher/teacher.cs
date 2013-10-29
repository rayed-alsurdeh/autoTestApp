using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using autoTestApp.code;
using System.Data.OleDb;
namespace autoTestApp.teacher
{
    public partial class teacher : Form
    {
        Color c;
        string tSSN = "1234567887";
        public teacher()
        {
            InitializeComponent();

        }

        private void admin_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'autoExamDBDataSet.course' table. You can move, or remove it, as needed.
            // this.courseTableAdapter.Fill(this.autoExamDBDataSet.course);
            // TODO: This line of code loads data into the 'autoExamDBDataSet3.DataTable1' table. You can move, or remove it, as needed.
            // this.dataTable1TableAdapter.Fill(this.autoExamDBDataSet3.DataTable1);
            // TODO: This line of code loads data into the 'autoExamDBDataSet3.DataTable1' table. You can move, or remove it, as needed.
            //   this.dataTable1TableAdapter.Fill(this.autoExamDBDataSet3.DataTable1);
            // TODO: This line of code loads data into the 'autoExamDBDataSet2.perView' table. You can move, or remove it, as needed.

            // TODO: This line of code loads data into the 'autoExamDBDataSet1.person' table. You can move, or remove it, as needed.
            c = txtSSN.BackColor;
            this.Text = this.Text + "( " + sysUsers.uname + " )";
        }

        private void المستخدمينالحاليينToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel3.Visible = true;
            panel2.Visible = false;
            List<string> lc= course.getCourses(tSSN);
            lc.Insert(0, "اختر مادة");
            cmbTC.DataSource = lc; 
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {

        }

        private void bindingNavigator1_ItemAdded(object sender, ToolStripItemEventArgs e)
        {
            MessageBox.Show("*");
        }

        private void addRecordToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                //this.dataTable1TableAdapter.addRecord(this.autoExamDBDataSet3.DataTable1);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void bindingNavigatorAddNewItem_Click_1(object sender, EventArgs e)
        {

        }

         

        private void btnAdd_Click(object sender, EventArgs e)
        {            
        }
     
     

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            autoTestApp.All.updateInfo up = new All.updateInfo();
            up.ShowDialog();
        }

        private void ادارةالموادToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void tabTeacher_Selected(object sender, TabControlEventArgs e)
        {


        }

        private void tabTeacher_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabTeacher.SelectedIndex == 0)
            {
                List<string> lc = course.getCourses("1234567887");
                lc.Insert(0, "اختر مادة");
                cmbTC.DataSource = lc;
            }
            else
                if (tabTeacher.SelectedIndex == 1)
                {

                    List<string> tests = new List<string>();
                    cmbTT.DataSource = tests;
                    tests = course.getCTest(tSSN, false);
                    if (tests.Count < 1)
                    {
                        tests.Add("لا يوجد اختبارات");
                        cmbTT.DataSource = tests;
                        btnAddQ.Enabled = false;
                        btnMQ.Enabled = false;
                        btnRQ.Enabled = false;
                    }
                    else
                    {
                        cmbTT.DataSource = tests;
                        btnAddQ.Enabled = true;
                        btnMQ.Enabled = true;
                        btnRQ.Enabled = true;
                    }
                }
        }
        private static void getQ(string tname)
        {

        }
        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            panel3.Visible = true;
            panel2.Visible = false;
            //fillCGrid();        
        }

        private void panel2_Enter(object sender, EventArgs e)
        {

        }

        private void tabTeacher_Enter(object sender, EventArgs e)
        {
            
        }

        private void btnAddD_Click(object sender, EventArgs e)
        {
            if (cmbTC.SelectedIndex > 0  && cmbCurT.SelectedIndex >=0)
            {
                int days = dtTD.Value.Date.Subtract(DateTime.Now).Days;
                if ( days <= 0)
                {
                    MessageBox.Show("ادخل تاريخ صحيح");
                }
                else
                {
                    if (course.addTDate(cmbCurT.SelectedValue.ToString(),dtTD.Value.Date.ToString()))
                    {
                        getDates();
                    }
                }
            }
        }

        private void cmbTC_SelectedIndexChanged(object sender, EventArgs e)
        {
            updateTest();
        }
        private void updateTest()
        {
            if (cmbTC.SelectedIndex > 0)
            {
                List<string> tests = new List<string>();
                cmbCurT.DataSource = tests;
                tests = course.getCTest(course.getCID(cmbTC.SelectedValue.ToString()),true);
                if (tests.Count < 1)
                {
                    tests.Add("لا يوجد اختبارات");
                    cmbCurT.DataSource = tests;
                }
                else
                    cmbCurT.DataSource = tests;
            }
            else
            {
                List<string> tests = new List<string>();
                cmbCurT.DataSource = tests;

                cmbCurT.Text = "";
            }

        }

        private void btnAddNT_Click(object sender, EventArgs e)
        {
            if (txtTName.Text.Trim().Length <= 0)
            {
                txtTName.BackColor = Color.Red;
            }
            else
            {
                txtTName.BackColor = c;
                if (course.addCTest(course.getCID(cmbTC.SelectedValue.ToString()), tSSN, txtTName.Text))
                {
                    txtTName.Text = "";
                    panAddT.Visible = false;
                    updateTest();
                }
            }
        }
        private void btnAddT_Click(object sender, EventArgs e)
        {
            if (cmbTC.SelectedIndex > 0 )
                panAddT.Visible = true;
        }

        private void cmbTD_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void cmbCurT_SelectedIndexChanged(object sender, EventArgs e)
        {
            getDates();
        }
        private void getDates()
        {
            
                List<string> dates = course.getTDates(cmbCurT.SelectedValue.ToString());
                if (dates != null)
                {
                    if (dates.Count == 0)
                    {
                        dates.Add("لا يوجد مواعيد");
                        cmbTD.DataSource = dates;
                    }
                    else
                        cmbTD.DataSource = dates;
                }
            
        }

        private void btnRemoveTest_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbCurT.Items.Count >= 0)
                {
                    DialogResult res = MessageBox.Show("هل تريد حذف الاختبار مع جميع مكوناته؟", "", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                    if (res == DialogResult.Yes)
                    {
                        if (course.removeTest(cmbCurT.SelectedValue.ToString()))
                        {
                            MessageBox.Show("تم حذف الاختبار");
                            int x= cmbTC.SelectedIndex;
                            cmbTC.SelectedIndex = 0;
                            cmbTC.SelectedIndex = x;
                        }
                    }
                }
            }
            catch (Exception)
            {

            }

        }

        private void btnRemoveD_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbTD.Items.Count >= 0)
                {
                    DialogResult res = MessageBox.Show("هل تريد حذف موعد الاختبار ؟", "", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                    if (res == DialogResult.Yes)
                    {
                        if (course.removeD(cmbCurT.SelectedValue.ToString(),cmbTD.SelectedValue.ToString()))
                        {
                            MessageBox.Show("تم حذف الموعد");
                            int x = cmbTC.SelectedIndex;
                            int y = cmbTD.SelectedIndex;
                            cmbTC.SelectedIndex = 0;
                            cmbTC.SelectedIndex = x;                            
                            cmbTD.SelectedIndex = y;
                        }
                    }
                }
            }
            catch (Exception)
            {

            }

        }

        private void btnAddQ_Click(object sender, EventArgs e)
        {
            q addq = new q(cmbTT.SelectedValue.ToString(),1);
            addq.ShowDialog();
            //questions.addQ("","","mm","",1);
            //questions.addQ("", "", "mm", "", 1,"");
        }
          
        //private void fillSCGrid()
        //{
        //    try
        //    {
        //        dataGridView3.Rows.Clear();
        //        OleDbCommand com = new OleDbCommand();
        //        string sql;
        //        sql = "SELECT person.perName AS sName, course.courseName AS cName, person_1.perName AS tName, person.perID as sNum ";
        //        sql = sql + " From person,course,person as person_1,studentCourses,teacherCourses ";
        //        sql = sql + " Where studentCourses.courseID = teacherCourses.courseID AND studentCourses.teacherID = teacherCourses.teacherID and  studentCourses.studentSSN = person.perID ";
        //        sql = sql + " and teacherCourses.teacherID = person_1.perSSN and course.courseID = teacherCourses.courseID ";
        //        if (cmbCT.SelectedIndex == 0 && cmbSC.SelectedIndex == 0)
        //        {
        //            com.CommandText = sql;                   
        //        }
        //        else
        //        {
        //            if (cmbCT.SelectedIndex == 0)
        //            {
        //                com.Parameters.AddWithValue("@cid",course.getCID(cmbSC.SelectedValue.ToString()));
        //                sql = sql + " and studentCourses.courseID=@cid;";
        //                com.CommandText = sql;                   
        //            }
        //            else
        //            {
        //                if (cmbSC.SelectedIndex == 0)
        //                {
        //                    com.Parameters.AddWithValue("@tid", sysUsers.getPerSSN(cmbCT.SelectedValue.ToString(),1));
        //                    sql = sql + " and studentCourses.teacherID=@tid;";
        //                    com.CommandText = sql;                   
        //                }
        //                else
        //                {
        //                    com.Parameters.AddWithValue("@cid", course.getCID(cmbSC.SelectedValue.ToString()));
        //                    com.Parameters.AddWithValue("@tid", sysUsers.getPerSSN(cmbCT.SelectedValue.ToString(), 1));
        //                    sql = sql + " and  studentCourses.courseID=@cid and studentCourses.teacherID=@tid;";
        //                    com.CommandText = sql;                   
        //                }

        //            }
        //        }
        //        DB.openConnection();
        //        com.Connection = DB.conn;
        //        OleDbDataReader reader = com.ExecuteReader();
        //        while (reader.Read())
        //        {
        //            dataGridView3.Rows.Add(reader[3].ToString().Trim(), reader[0].ToString().Trim(), reader[2].ToString().Trim(), reader[1].ToString().Trim());//, reader[].ToString().Trim());
        //        }

        //        dataGridView3.Refresh();
        //        DB.closeConnection();
        //    }
        //    catch (Exception ex)
        //    {
        //        //MessageBox.Show(ex.Message);
        //    }

        //}
   

    }
}
