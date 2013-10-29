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
namespace autoTestApp.All
{
    public partial class updateInfo : Form
    {
        Color c;
        public updateInfo()
        {
            InitializeComponent();

        }

        private void admin_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'autoExamDBDataSet3.DataTable1' table. You can move, or remove it, as needed.
           // this.dataTable1TableAdapter.Fill(this.autoExamDBDataSet3.DataTable1);
            // TODO: This line of code loads data into the 'autoExamDBDataSet3.DataTable1' table. You can move, or remove it, as needed.
        //   this.dataTable1TableAdapter.Fill(this.autoExamDBDataSet3.DataTable1);
            // TODO: This line of code loads data into the 'autoExamDBDataSet2.perView' table. You can move, or remove it, as needed.
            
            // TODO: This line of code loads data into the 'autoExamDBDataSet1.person' table. You can move, or remove it, as needed.
            panel2.Visible = true;
            c = txtPass.BackColor;
            sysUsers.uid = "1234567899";

            DB.openConnection();
            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = DB.conn;
            cmd.Parameters.AddWithValue("@ssn", sysUsers.uid);
            cmd.CommandText = "select * from person where perSSN=?";
            OleDbDataReader reader = cmd.ExecuteReader();
            reader.Read();
            txtEmail.Text = reader[4].ToString();
            txtMob.Text = reader [5].ToString();
            txtPass.Text = reader[7].ToString();
            txtSSN.Text = sysUsers.uid;
        }

        private void المستخدمينالحاليينToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {

        }

        private void bindingNavigator1_ItemAdded(object sender, ToolStripItemEventArgs e)
        {
            
        }

        private void addRecordToolStripButton_Click(object sender, EventArgs e)
        {
            
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
                if (sysUsers.updatePer(sysUsers.uid, txtEmail.Text, txtMob.Text, txtPass.Text))
                {
                    MessageBox.Show("تم التحديث");
                }
            }
        }
        private bool checkFields()
        {
            
            if (txtPass.Text.Trim().Length < 4)
            {
                txtPass.BackColor = Color.Red;
                txtPass.Focus();
                return false;
            }
            else
            {
                txtPass.BackColor = c;// txtID.BackColor;// Color.InactiveCaption;
                return true;                
            }
            
        }
        private void clearFields()
        {
            txtEmail.Text = "";
            txtMob.Text = "";
            txtPass.Text = "";
            txtSSN.Text = "";
        }

        private void المستخدمينToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       
    }
}
