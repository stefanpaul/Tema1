using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BL;
using Entities;

namespace Login
{
    public partial class AdminForm : Form
    {
        public UService userservice; 
        public AdminForm(UService userservice)
        {
            InitializeComponent();
            this.userservice = userservice;
        }

        //Create account
        private void button1_Click(object sender, EventArgs e)
        {
            string userID = textBox2.Text;
            string name = textBox3.Text;
            string surname = textBox4.Text;
            string password = textBox5.Text;
            string role = textBox6.Text;
            User worker = null ;
            bool ok = false;
            if (role == "Angajat")
            {
                worker = new Employee(userID, name, surname, password, role);
                ok = true;
            }
            else if (role == "Admin")
            {
                worker = new Admin(userID, name, surname, password, role);
                ok = true;
            }
            else MessageBox.Show("The role is incorrect");
            if (userID != "" && name != "" && surname != "" && password != "" && role != "" && ok)
            {
                userservice.createAccount(worker);
                MessageBox.Show("Account succesufully created");
            }
            else MessageBox.Show("Not all fields were written");
        }

        //Create report
        private void button3_Click(object sender, EventArgs e)
        {
            string userID = textBox1.Text;
            bool exists = userservice.doesItExist(userID);
            if (userID != null && exists)
            {
                string report = userservice.createReport(userID);
                Wrong form = new Wrong();
                form.write(report);
                form.Show();
            }
            else MessageBox.Show("You have not chosen an existing user");
        }

        //Delete user
        private void button2_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text;
            bool exists = userservice.doesItExist(name);
            if (name != "" && exists)
            {
                userservice.deleteAccount(name);
                MessageBox.Show("Account succesufully deleted");
            }
            else MessageBox.Show("You have not chosen an existing user");
        }


        private void button4_Click(object sender, EventArgs e)
        {
            string userID = textBox2.Text;
            string name = textBox3.Text;
            string surname = textBox4.Text;
            string password = textBox5.Text;
            string role = textBox6.Text;
            bool exists = userservice.doesItExist(userID);
            User worker = null;
            bool ok = false;
            if (role == "Angajat")
            {
                worker = new Employee(userID, name, surname, password, role);
                ok = true;
            }
            else if (role == "Admin")
            {
                worker = new Admin(userID, name, surname, password, role);
                ok = true;
            }
            else MessageBox.Show("The role is incorrect");
            if (userID != "" && name != "" && surname != "" && password != "" && role != "" && exists && ok)
            {
                userservice.updateAccount(worker);
                MessageBox.Show("Account succesufuly updated");
            }
            else MessageBox.Show("Not all fields were written or you have not chosen an existing user");
        }

        private void AdminForm_Load(object sender, EventArgs e)
        {
           
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
