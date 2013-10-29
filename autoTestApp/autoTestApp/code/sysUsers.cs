using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data.OleDb;
namespace autoTestApp.code
{
	public static class sysUsers
	{
        public static string uname = "";
        public static string uid = "";
        public static bool checkLogin(string uid, string pass, int logT)
        {
            try
            {
              DB.openConnection();
              OleDbCommand com = new OleDbCommand();

                com.Connection = DB.conn;
                com.Parameters.AddWithValue("@pSSN", uid);
                com.Parameters.AddWithValue("@pPass", pass);
                com.Parameters.AddWithValue("@rID", logT);                
                com.CommandText = "select count(*) from person where perSSN=@pSSN and perPass=@pPass and perRoleID=@rID";
                int rc = Int32.Parse(com.ExecuteScalar().ToString());
                DB.closeConnection();
                if (rc > 0)
                {
                    sysUsers.uname = getUName(uid);
                    return true;
                }
                else
                    return false;
            }
            catch (Exception ex)
            {
                return false;
            }                        
        }
        private static string getUName(string uid)
        {
            try
            {
                DB.openConnection();
                OleDbCommand com = new OleDbCommand();

                com.Connection = DB.conn;
                com.Parameters.AddWithValue("@pSSN", uid);                 
                com.CommandText = "select perName from person where perSSN=@pSSN";
                OleDbDataReader reader = com.ExecuteReader();
                reader.Read();
                string uname = reader[0].ToString().Trim();
                DB.closeConnection();
                return uname;
            }
            catch (Exception ex)
            {
                return "";
            }                                    
        }
        public static List<string> getMajors()
        {
            try
            {
                List<string> maj = new List<string>();
                DB.openConnection();
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = DB.conn;
                cmd.CommandText = "select * from majore";
                OleDbDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    maj.Add(reader[1].ToString().Trim());
                }
                DB.closeConnection();
                return maj;
            }
            catch (Exception)
            {
                return null;
            }          
            
        }
        public static bool addPer(string ssn, string sid, string pass, string name, int mid, int rid)
        {
            DB.openConnection();
            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = DB.conn;
            cmd.Parameters.AddWithValue("@ssn", ssn);
            cmd.Parameters.AddWithValue("@sid", sid);
            cmd.Parameters.AddWithValue("@sname",name);
            cmd.Parameters.AddWithValue("@rid", rid);
            cmd.Parameters.AddWithValue("@mid", mid);
            cmd.Parameters.AddWithValue("@pass", pass);
            cmd.CommandText = "insert into person (perSSN,perID,perName,perRoleID,perMajoreID,perPass) values (?,?,?,?,?,?)";
            if (cmd.ExecuteNonQuery() > 0)
            {                
                DB.closeConnection();
                return true;
            }
            return false;
        }
        public static bool updatePer(string ssn, string email, string mob, string pass)
        {
            DB.openConnection();
            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = DB.conn;            
            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@mob",mob);
            cmd.Parameters.AddWithValue("@pass", pass);
            cmd.Parameters.AddWithValue("@ssn", ssn);
            cmd.CommandText = "update person set perEmail=? , perMobile=? , perPass=? where perSSN=?";
            if (cmd.ExecuteNonQuery() > 0)
            {
                DB.closeConnection();
                return true;
            }
            return false;
        }
        public static List<string> getPearsons(int t)
        {
            try
            {
                List<string> teach = new List<string>();
                DB.openConnection();
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = DB.conn;
                if (t==1)
                    cmd.CommandText = "select * from person where perRoleID=2";
                else
                    cmd.CommandText = "select * from person where perRoleID=3";

                OleDbDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    teach.Add(reader[2].ToString().Trim());
                }
                DB.closeConnection();
                return teach;
            }
            catch (Exception)
            {
                return null;
            }          
            
        }
        public static string getPerSSN(string pname,int rt)
        {
            DB.openConnection();
            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = DB.conn;
            cmd.Parameters.AddWithValue("@pn", pname);
            if(rt==1)
                cmd.CommandText = "select perSSN from person where perName=?";
            else
                cmd.CommandText = "select perSSN from person where perID=?";

            OleDbDataReader reader = cmd.ExecuteReader();
            reader.Read();
            string cid = reader[0].ToString();
            DB.closeConnection();
            return cid;
        }
	}
}
