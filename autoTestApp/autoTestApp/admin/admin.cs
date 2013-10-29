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
namespace autoTestApp.admin
{
    public partial class admin : Form
    {
        Color c;
        public admin()
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
            panel3.Visible = false;
            panel2.Visible = true;
            cmbMajor.DataSource = sysUsers.getMajors();
            cmbJob.SelectedIndex = 0;
            cmbMajor.SelectedIndex = 0;
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

        private void btnClear_Click(object sender, EventArgs e)
        {
            clearFields();

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (checkFields())
            {
                if (sysUsers.addPer(txtSSN.Text, txtID.Text, txtPass.Text, txtName.Text, cmbMajor.SelectedIndex + 1, cmbJob.SelectedIndex + 1))
                {
                    clearFields();
                }
            }
        }
        private bool checkFields()
        {

            if (txtSSN.Text.Trim().Length < 1)
            {
                txtSSN.BackColor = Color.Red;
                txtSSN.Focus();
                return false;
            }
            else
            {
                txtSSN.BackColor = c;// txtID.BackColor;// Color.InactiveCaption;
                if (txtID.Text.Trim().Length < 1)
                {
                    txtID.BackColor = Color.Red;
                    txtID.Focus();
                    return false;
                }
                else
                {
                    txtID.BackColor = c;// txtSSN.BackColor;// Color.InactiveCaption;
                    if (txtName.Text.Trim().Length < 1)
                    {
                        txtName.BackColor = Color.Red;
                        txtName.Focus();
                        return false;
                    }
                    else
                    {
                        txtName.BackColor = c;// txtSSN.BackColor;// Color.InactiveCaption;
                        if (txtPass.Text.Trim().Length < 1)
                        {
                            txtPass.BackColor = Color.Red;
                            txtPass.Focus();
                            return false;
                        }
                        else
                        {
                            txtPass.BackColor = c;// txtSSN.BackColor;// Color.InactiveCaption;
                            return true;
                        }
                    }
                }
            }
            return true;
        }
        private void clearFields()
        {
            txtID.Text = "";
            txtName.Text = "";
            txtPass.Text = "";
            txtSSN.Text = "";
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
                comboBox4.DataSource = sysUsers.getMajors();
            }
            else
                if (tabTeacher.SelectedIndex == 1)
                {
                    cmbT.DataSource = sysUsers.getPearsons(1);
                    cmbC.DataSource = course.getCourses();
                    fillTCGrid();
                }
                else
                {
                    List<string> per = sysUsers.getPearsons(1);
                    per.Insert(0, "اختر مدرس");
                    cmbCT.DataSource = per;
                    List<string> per1 = course.getCourses();                    
                    per1.Insert(0, "اختر مادة");
                    cmbSC.DataSource = per1;
                    fillSCGrid();
                    //fillTCGrid();
                }

        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            panel3.Visible = true;
            panel2.Visible = false;
            fillCGrid();

        }

        private void panel2_Enter(object sender, EventArgs e)
        {

        }

        private void tabTeacher_Enter(object sender, EventArgs e)
        {
            comboBox4.DataSource = sysUsers.getMajors();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (txtCID.Text.Trim().Length > 0)
            {
                txtCID.BackColor = c;
                if (txtCName.Text.Trim().Length > 0)
                {
                    txtCName.BackColor = c;
                    if (course.addCourse(txtCID.Text, txtCName.Text, comboBox4.SelectedIndex + 1))
                        fillCGrid();
                }
                else
                {
                    txtCName.BackColor = Color.Red;
                }
            }
            else
            {
                txtCID.BackColor = Color.Red;
            }
        }

        private void fillCGrid()
        {
            try
            {
                dataGridView1.Rows.Clear();
                DB.openConnection();
                string sql = "select courseID,courseName,majoreName from course,majore where courseMajoreID=majoreID";
                OleDbCommand com = new OleDbCommand(sql, DB.conn);
                OleDbDataReader reader = com.ExecuteReader();
                while (reader.Read())
                {
                    dataGridView1.Rows.Add(reader[0].ToString().Trim(), reader[1].ToString().Trim(), reader[2].ToString().Trim());//, reader[].ToString().Trim());
                }

                dataGridView1.Refresh();
                DB.closeConnection();

            }
            catch (Exception)
            {


            }

        }
        private void fillTCGrid()
        {
            try
            {
                dataGridView2.Rows.Clear();
                DB.openConnection();
                string sql = "select courseName as cName,perName as tName, courseCode as cCode from teacherCourses, course, person ";
                sql = sql + " where teacherCourses.courseID=course.courseID and teacherCourses.teacherID=perSSN";
                OleDbCommand com = new OleDbCommand(sql, DB.conn);
                OleDbDataReader reader = com.ExecuteReader();
                while (reader.Read())
                {
                    dataGridView2.Rows.Add(reader[1].ToString().Trim(), reader[0].ToString().Trim(), reader[2].ToString().Trim());//, reader[].ToString().Trim());
                }

                dataGridView2.Refresh();
                DB.closeConnection();

            }
            catch (Exception)
            {


            }

        }
        private void fillSCGrid()
        {
            try
            {
                dataGridView3.Rows.Clear();
                OleDbCommand com = new OleDbCommand();
                string sql;
                sql = "SELECT person.perName AS sName, course.courseName AS cName, person_1.perName AS tName, person.perID as sNum ";
                sql = sql + " From person,course,person as person_1,studentCourses,teacherCourses ";
                sql = sql + " Where studentCourses.courseID = teacherCourses.courseID AND studentCourses.teacherID = teacherCourses.teacherID and  studentCourses.studentSSN = person.perID ";
                sql = sql + " and teacherCourses.teacherID = person_1.perSSN and course.courseID = teacherCourses.courseID ";
                if (cmbCT.SelectedIndex == 0 && cmbSC.SelectedIndex == 0)
                {
                    com.CommandText = sql;                   
                }
                else
                {
                    if (cmbCT.SelectedIndex == 0)
                    {
                        com.Parameters.AddWithValue("@cid",course.getCID(cmbSC.SelectedValue.ToString()));
                        sql = sql + " and studentCourses.courseID=@cid;";
                        com.CommandText = sql;                   
                    }
                    else
                    {
                        if (cmbSC.SelectedIndex == 0)
                        {
                            com.Parameters.AddWithValue("@tid", sysUsers.getPerSSN(cmbCT.SelectedValue.ToString(),1));
                            sql = sql + " and studentCourses.teacherID=@tid;";
                            com.CommandText = sql;                   
                        }
                        else
                        {
                            com.Parameters.AddWithValue("@cid", course.getCID(cmbSC.SelectedValue.ToString()));
                            com.Parameters.AddWithValue("@tid", sysUsers.getPerSSN(cmbCT.SelectedValue.ToString(), 1));
                            sql = sql + " and  studentCourses.courseID=@cid and studentCourses.teacherID=@tid;";
                            com.CommandText = sql;                   
                        }

                    }
                }
                DB.openConnection();
                com.Connection = DB.conn;
                OleDbDataReader reader = com.ExecuteReader();
                while (reader.Read())
                {
                    dataGridView3.Rows.Add(reader[3].ToString().Trim(), reader[0].ToString().Trim(), reader[2].ToString().Trim(), reader[1].ToString().Trim());//, reader[].ToString().Trim());
                }

                dataGridView3.Refresh();
                DB.closeConnection();
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }

        }
        private void btnAddC_Click(object sender, EventArgs e)
        {
            if (txtNC.Text.Trim().Length > 0)
            {
                txtNC.BackColor = c;
                if (course.addMaj(txtNC.Text))
                {
                    //comboBox4.Items.Clear();
                    comboBox4.DataSource = sysUsers.getMajors();
                    txtNC.Text = "";
                }
            }
            else
            {
                txtNC.BackColor = Color.Red;
            }
        }
        private void btnAddTC_Click(object sender, EventArgs e)
        {

            if (txtCC.Text.Trim().Length > 0)
            {
                txtCC.BackColor = c;
                string cid=course.getCID(cmbC.SelectedItem.ToString());
                string perSSN=sysUsers.getPerSSN(cmbT.SelectedItem.ToString(),1);
                if (course.addTCourse(cid,perSSN,txtCC.Text))
                {
                    //comboBox4.Items.Clear();
                    //comboBox4.DataSource = sysUsers.getMajors();
                    txtCC.Text = "";
                    fillTCGrid();
                }
            }
            else
            {
                txtCC.BackColor = Color.Red;
            }
        }
        private void tabAddC_Click(object sender, EventArgs e)
        {

        }
        private void اضافةطلابToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string tn = dataGridView2.CurrentRow.Cells[0].Value.ToString();
            string cn = dataGridView2.CurrentRow.Cells[1].Value.ToString();

            //this.Hide();
            addStudents adds = new addStudents(tn, cn);
            adds.ShowDialog();
            this.Show();
        }

        private void cmbSC_SelectedIndexChanged(object sender, EventArgs e)
        {
            fillSCGrid();
        }

        private void cmbCT_SelectedIndexChanged(object sender, EventArgs e)
        {
            fillSCGrid();
        }


    }
}
