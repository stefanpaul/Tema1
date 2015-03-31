using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using System.Drawing;


namespace DAL
{
    public class ADAL
    {
        public String connectionString;
        public MySqlConnection conn;

        public ADAL()
        {

        }

        public void UsersDAOMySQL()
        {
            connectionString = String.Format("server=127.0.0.1;uid=root;" + "pwd=;database=tema1;");
            conn = new MySqlConnection(connectionString);
        }

        public void addAdd(Add add)
        {
            String sql = "INSERT INTO anunturi VALUES ('" + add.getID() + "','" + add.getName() + "','" + add.getDescription() + "','" + add.getImage() + "');";
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

        public void deleteAdd(string addID)
        {
            string sql = "Delete From anunturi Where IDAnunt='" + addID + "';";
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


        public string readAdd(string addID)
        {
            string add = "";
            String sql = "SELECT * FROM anunturi WHERE IDAnunt='" + addID + "'";
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                if (reader.HasRows)
                {
                    add = reader["Titlu"].ToString() + " | " + reader["Descriere"].ToString();
                }
                else
                {
                    add = null;
                }
                conn.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("read add failed");
            }
            return add;
        }


        public void updateAdd(string addID, string addTitle, string addDescription)
        {
            string sql = "UPDATE anunturi SET Titlu='" + addTitle +
                                             "', Descriere='" + addDescription +
                                             "' WHERE IDAnunt='" + addID + "';";
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

        public bool doesItExist(string addID)
        {
            bool exists = false;
            String sql = "SELECT * FROM anunturi WHERE IDAnunt='" + addID + "'";
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
