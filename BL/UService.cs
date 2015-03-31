using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using System.IO;
using DAL;
using System.Security.Cryptography;

namespace BL
{
    public class UService
    {
        String userID;
        String password;

        UDAL userdal;
        String criptedPassword;

        public UService(String userID, String password)
        {
            this.userID = userID;
            this.password = password;
            userdal = new UDAL();
        }

        private string getMd5Hash(string input)
        {
            // Create a new instance of the MD5CryptoServiceProvider object.
            MD5 md5Hasher = MD5.Create();

            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }


        public User getUser()
        {
            userdal.UsersDAOMySQL();

            criptedPassword = getMd5Hash(password);

            User user = userdal.getUser(userID, criptedPassword);
            return user;
        }

        public void createAccount(User worker)
        {
            string newPassword = getMd5Hash(worker.getPassword());
            userdal.createAcc(worker, newPassword);
        }

        public void deleteAccount(string username)
        {
            userdal.deleteAcc(username);
        }

        public void updateAccount(User worker)
        {
            string newPass = getMd5Hash(worker.getPassword());
            userdal.updateAcc(worker,newPass);
        }

        public string createReport(string userID)
        {
            string report = userdal.createReport(userID);
            return report;
        }

        public string updatePassword(string userID)
        {
            userdal.UsersDAOMySQL();
            string pass = Path.GetRandomFileName();
            string newPass = getMd5Hash(pass);
            userdal.updatePassword(userID,newPass);
            return pass;
        }

        public void increment(string userID)
        {
            userdal.UsersDAOMySQL();
            userdal.increment(userID);
        }

        public bool doesItExist(string userID)
        {
            return userdal.doesItExist(userID);
        }
    }
}
