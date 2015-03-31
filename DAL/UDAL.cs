using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;
using Entities;

namespace DAL
{
    public class UDAL
    {
        public String connectionString;
        public MySqlConnection conn;
        public UDAL()
        {

        }

        public void UsersDAOMySQL()
        {
            connectionString = String.Format("server=127.0.0.1;uid=root;" + "pwd=;database=tema1;");
            //("server={0};user id={1}; password={2}; database={3}; pooling=false", "localhost", "root", "root", "tema1");
            conn = new MySqlConnection(connectionString);
        }


        public User getUser(String userID, String password)
        {
            User u = null;
            String sql = "SELECT * FROM userstable WHERE UserID='" + userID + "' AND Parola='" + password + "'";
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                if (reader.HasRows)
                {
                    if (reader["Rol"].ToString() == "Admin")
                        u = new Admin(reader["UserID"].ToString(), reader["Nume"].ToString(), reader["Prenume"].ToString(), reader["Parola"].ToString(), reader["Rol"].ToString());
                    else
                        u = new Employee(reader["UserID"].ToString(), reader["Nume"].ToString(), reader["Prenume"].ToString(), reader["Parola"].ToString(), reader["Rol"].ToString());
                }
                else
                {
                    u = null;
                }
                conn.Close();

            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.Message);
                conn.Close();
                return null;
            }
            return u;
        }


        //Email password
        public void updatePassword(string username, string password)
        {
            String sql = "UPDATE userstable SET Parola = '" + password + "' WHERE UserID = '" + username + "'";
            Console.WriteLine(username + " " + password);
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader exec = cmd.ExecuteReader();
                conn.Close();
            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.Message);
                conn.Close();
            }
        }

        public void createAcc(User worker, string newUserPassword)
        {
            String sql = "INSERT INTO userstable VALUES ('" + worker.getID() + "','" + worker.getName() + "','" + worker.getSurname() + "','" + newUserPassword + "','" + worker.getRole() + "','0');";
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader exec = cmd.ExecuteReader();
                conn.Close();
            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.Message);
                conn.Close();
            }
        }

        public void deleteAcc(string username)
        {
            string sql = "Delete From userstable Where UserID='" + username + "';";
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader exec = cmd.ExecuteReader();
                conn.Close();
            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.Message);
                conn.Close();
            }
        }

        public void updateAcc(User worker, string newUserPassword)
        {
            string sql = "UPDATE userstable SET Nume='" + worker.getName() +
                                            "', Prenume='" + worker.getSurname() +
                                            "', Parola='" + newUserPassword +
                                            "', Rol='" + worker.getRole() +
                                            "' WHERE UserID='" + worker.getID() + "';";
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader exec = cmd.ExecuteReader();
                conn.Close();
            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.Message);
                conn.Close();
            }
        }

        public string createReport(string userID)
        {
            string report = "";

            string sql = "Select * from userstable Where UserID='" + userID + "';";
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                if (reader.HasRows)
                {
                    report = reader["Nume"].ToString() + " has placed a number of " + reader["AddNr"].ToString() + " adds;";
                }
                conn.Close();
            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.Message);
                conn.Close();
            }

            return report;
        }

        public void increment(string userID)
        {
            String sql = "SELECT * FROM userstable WHERE UserID='" + userID + "'";
            int nrOfAdds = 0;
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                if (reader.HasRows)
                {
                    string stringNrOfAdds = reader["AddNr"].ToString();
                    nrOfAdds = Convert.ToInt32(stringNrOfAdds);
                }
                conn.Close();
                int newNrOfAdds = nrOfAdds++;
            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.Message);
                conn.Close();
            }

            String newSql = "UPDATE userstable SET AddNr='" + nrOfAdds.ToString() +
                                            "' WHERE UserID='" + userID + "';";
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(newSql, conn);
                cmd.ExecuteReader();
                conn.Close();
            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.Message);
                conn.Close();
            }
        }

        public bool doesItExist(string userID)
        {
            bool exists = false;
            String sql = "SELECT * FROM userstable WHERE UserID='" + userID + "'";
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                if (reader.HasRows)
                {
                    exists = true;
                }
                conn.Close();

            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.Message);
                conn.Close();
            }
            return exists;
        }
    }
}
