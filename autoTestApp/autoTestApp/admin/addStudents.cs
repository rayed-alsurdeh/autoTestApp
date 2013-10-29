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
    public partial class addStudents : Form
    {
        string cid;
        string tid;
        public addStudents(string tn,string cn)
        {
            InitializeComponent();
            cid = code.course.getCID(cn);
            tid = sysUsers.getPerSSN(tn,1);

            //MessageBox.Show(cid + " " + tid);
        }

        private void addStudents_Load(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.Rows.Clear();
                DB.openConnection();
                string sql = "select perID as sNum, perName as pName from person where perRoleID=3";
                OleDbCommand com = new OleDbCommand(sql, DB.conn);
                OleDbDataReader reader = com.ExecuteReader();
                while (reader.Read())
                {
                    dataGridView1.Rows.Add(reader[0].ToString().Trim(), reader[1].ToString().Trim());//
                }

                dataGridView1.Refresh();
                DB.closeConnection();

            }
            catch (Exception)
            {


            }

        }

        private void اضافةToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridViewSelectedRowCollection coll = dataGridView1.SelectedRows;

                if (coll.Count < 1)
                {
                    MessageBox.Show("الرجاء اختار طالب او طلاب");
                }
                else
                {
                    System.Collections.IEnumerator renum = coll.GetEnumerator();
                    bool add = false;
                    while (renum.MoveNext())
                    {
                        DataGridViewRow row = (DataGridViewRow)renum.Current;
                        add=course.addSCourse(row.Cells[0].Value.ToString(), tid, cid);
                         
                        // renum.MoveNext();
                    }
                    if (add)
                        MessageBox.Show("تم اضافة الطلاب");
                }
            }
            catch (Exception)
            {

                 
            }

            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1.CurrentRow.Selected = true;
        }
    }
}
