using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BL;
using Entities;

namespace Login
{
    public partial class EmployeeForm : Form
    {
        string file;
        AService service;
        UService userService;
        string userID;
        public EmployeeForm()
        {
            InitializeComponent();
            service = new AService();
            userService = new UService("", "");
        }

        public void setUserID(string userID)
        {
            this.userID = userID;
        }

        private void create_Click(object sender, EventArgs e)
        {
            string addName = textBox1.Text;
            string addDescription = richTextBox1.Text;
            string addID = textBox2.Text;
            string imageSource = file; 
            if (addName != "" && addDescription != "" && addID != "")
            {
                Image newImage = Image.FromFile(file);
                Add add = new Add(addID, addName, addDescription, newImage);
                service.addAdd(add);
                userService.increment(userID);
                MessageBox.Show("Add created");
            }
            else MessageBox.Show("No all field were written");
        }

        private void read_Click(object sender, EventArgs e)
        {
            string addID = textBox2.Text;
            string add;
            bool exists = service.doesItExist(addID);
            if (addID != "" && exists)
            {
                add = service.readAdd(addID);
                string[] attributes = add.Split('|');
                textBox1.Text = attributes[0];
                richTextBox1.Text = attributes[1];
            }
            else MessageBox.Show("ID field was not written or the add you have requested does not exist");
        }

        private void update_Click(object sender, EventArgs e)
        {
            string addID = textBox2.Text;
            string addTitle = textBox1.Text;
            string addDescription = richTextBox1.Text;
            bool exists = service.doesItExist(addID);
            if (addID != "" && addTitle != "" && addDescription != "" && exists)
            {
                service.updateAdd(addID, addTitle, addDescription);
                MessageBox.Show("Add updated");
            }
            else MessageBox.Show("Add Id, Title and Desriptions fields were not written or the add you requested does not exist");
        }

        private void delete_Click(object sender, EventArgs e)
        {
            string id = textBox2.Text;
            bool exists = service.doesItExist(id);
            if (id != "" && exists)
            {
                service.deleteAdd(id);
                MessageBox.Show("Add deleted");
            }
            else MessageBox.Show("ID field was not written or the add you have requested does not exist");

        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            DialogResult result = openFileDialog1.ShowDialog(); // Show the dialog.
            if (result == DialogResult.OK) // Test result.
            {
                file = openFileDialog1.FileName;
                try
                {
                    label3.Text = file;
                }
                catch (IOException)
                {
                }
            }
        }

        private void EmployeeForm_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
