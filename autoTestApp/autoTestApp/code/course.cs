using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
namespace autoTestApp.code
{
    public static class course
    {
        public static bool addCourse(string cID, string cName, int majID)
        {
            DB.openConnection();
            string sql = "insert into course values (?,?,?)";
            OleDbCommand com = new OleDbCommand(sql,DB.conn);
            com.Parameters.AddWithValue("@cid", cID);
            com.Parameters.AddWithValue("@cn", cName);
            com.Parameters.AddWithValue("@mid", majID);
            if (com.ExecuteNonQuery() > 0)
            {
                DB.closeConnection();
                return true; 
            }
            DB.closeConnection();
            return false;
        }
        public static bool addMaj(string mName)
        {
            DB.openConnection();
            string sql = "insert into majore (majoreName) values (?)";
            OleDbCommand com = new OleDbCommand(sql,DB.conn);
            com.Parameters.AddWithValue("@cid", mName);
            if (com.ExecuteNonQuery() > 0)
            {
                DB.closeConnection();
                return true; 
            }
            DB.closeConnection();
            return false;
            
        }
        public static List<string> getCourses()
        {
            try
            {
                List<string> teach = new List<string>();
                DB.openConnection();
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = DB.conn;              
                cmd.CommandText = "select * from course";

                OleDbDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    teach.Add(reader[1].ToString().Trim());
                }
                DB.closeConnection();
                return teach;
            }
            catch (Exception)
            {
                return null;
            }          
            
        }
        public static List<string> getCourses(string tSSN)
        {
            try
            {
                List<string> teach = new List<string>();
                DB.openConnection();
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = DB.conn;
                cmd.Parameters.AddWithValue("@tid", tSSN);
                cmd.CommandText = "select * from course,teacherCourses where teacherCourses.courseID=course.courseID and teacherCourses.teacherID=?";

                OleDbDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    teach.Add(reader[1].ToString().Trim());
                }
                DB.closeConnection();
                return teach;
            }
            catch (Exception)
            {
                return null;
            }

        }
        public static string getCID(string cName)
        {
            DB.openConnection();
            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = DB.conn;
            cmd.Parameters.AddWithValue("@cn", cName);
            cmd.CommandText = "select courseID from course where courseName=?";
            OleDbDataReader reader = cmd.ExecuteReader();
            reader.Read();
            string cid = reader[0].ToString();
            DB.closeConnection();
            return cid;
        }
        public static bool addTCourse(string cID,string tID,string cCode)
        {
            DB.openConnection();
            string sql = "insert into teacherCourses values (?,?,?)";
            OleDbCommand com = new OleDbCommand(sql,DB.conn);
            com.Parameters.AddWithValue("@cid", cID);
            com.Parameters.AddWithValue("@cn", tID);
            com.Parameters.AddWithValue("@mid", cCode);
            if (com.ExecuteNonQuery() > 0)
            {
                DB.closeConnection();
                return true; 
            }
            DB.closeConnection();
            return false;
        }
        public static bool addSCourse(string sID, string tID, string cID)
        {
            DB.openConnection();
            string sql = "insert into studentCourses values (?,?,?)";
            OleDbCommand com = new OleDbCommand(sql, DB.conn);
            com.Parameters.AddWithValue("@sn",sID );
            com.Parameters.AddWithValue("@cid", cID);            
            com.Parameters.AddWithValue("@tid",tID);
            if (com.ExecuteNonQuery() > 0)
            {
                DB.closeConnection();
                return true;
            }
            DB.closeConnection();
            return false;
        }
        public static bool addCTest(string cID, string tID, string tName)
        {
            try
            {
                DB.openConnection();
                string sql = "insert into test values (?,?,?,?)";
                OleDbCommand com = new OleDbCommand(sql, DB.conn);
                com.Parameters.AddWithValue("@tn", tName);
                com.Parameters.AddWithValue("@cid", cID);
                com.Parameters.AddWithValue("@cn", tID);
                com.Parameters.AddWithValue("@nq", 0);
                if (com.ExecuteNonQuery() > 0)
                {
                    DB.closeConnection();
                    return true;
                }
                DB.closeConnection();
            }
            catch (Exception ex)
            {
                return false;
            }
            return false;
        }
        public static List<string> getCTest(string cID, bool t)
        {
            //try
            //{

            DB.openConnection();
            List<string> tests = new List<string>();
            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = DB.conn;
            cmd.Parameters.AddWithValue("@cid", cID);
            if (t == true)
                cmd.CommandText = "select distinct testName from test,teacherCourses where test.courseID=teacherCourses.courseID and test.courseID=?";
            else
                cmd.CommandText = "select distinct testName from test where test.teacherID=?";

            OleDbDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                tests.Add(reader[0].ToString().Trim());
            }
            DB.closeConnection();
            return tests;
            //}
            //catch (Exception)
            //{
            //    return null;
            //}

        }
        public static bool addTDate(string tName, string tdate)
        {
            try
            {
                DB.openConnection();
                string sql = "insert into testDates values (?,?)";
                OleDbCommand com = new OleDbCommand(sql, DB.conn);
                com.Parameters.AddWithValue("@tn", tName);
                com.Parameters.AddWithValue("@td", tdate);

                if (com.ExecuteNonQuery() > 0)
                {
                    DB.closeConnection();
                    return true;
                }
            }
            catch (Exception)
            {
                DB.closeConnection();
                return false;
            }
            DB.closeConnection();
            return false;

        }
        public static List<string> getTDates(string tID)
        {
            //try
            //{

                DB.openConnection();
                List<string> tests = new List<string>();
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = DB.conn;
                cmd.Parameters.AddWithValue("@tid", tID);
                cmd.CommandText = "select testDate from testDates where testName=?";
                OleDbDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    tests.Add(DateTime.Parse(reader[0].ToString().Trim()).ToShortDateString());
                }
                DB.closeConnection();
                return tests;
            //}
            //catch (Exception)
            //{
            //    return null;
            //}

        }
        public static bool removeTest(string tname)
        {
            DB.openConnection();
            string sql = "delete from test where testName =?";
            OleDbCommand com = new OleDbCommand(sql, DB.conn);
            com.Parameters.AddWithValue("@tn", tname);
             
            if (com.ExecuteNonQuery() > 0)
            {
                DB.closeConnection();
                return true;
            }
            DB.closeConnection();
            return false;
        }
        public static bool removeQ(bool rt)
        {
            return false;
        }
        public static bool removeD(string tname,string td)
        {
            DB.openConnection();

            string sql = "delete from testDates where testName =? and testDate=?";
            OleDbCommand com = new OleDbCommand(sql, DB.conn);
            com.Parameters.AddWithValue("@tn", tname);
            DateTime dt = DateTime.Parse(td);
            com.Parameters.AddWithValue("@td", DateTime.Parse(td));

            if (com.ExecuteNonQuery() > 0)
            {
                DB.closeConnection();
                return true;
            }
            DB.closeConnection();
            return false;
            
        }

    }
}
