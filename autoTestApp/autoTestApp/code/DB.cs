using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data.OleDb;

namespace autoTestApp.code
{
    public static class DB
    {

        public static OleDbConnection  conn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:/myfiles/Abu-Lyan/Students/projects/autoTestApp/autoTestApp/AppData/autoExamDB.accdb;Persist Security Info=True");

        public static bool openConnection()
        {
            try
            {
                conn.Open();
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }
        }
        public static bool closeConnection()
        {
            try
            {
                conn.Close();
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }
        }   
 
    }
}
