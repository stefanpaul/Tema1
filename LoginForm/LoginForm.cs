using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entities;
using System.Net.Mail;
using System.Net;
using BL;

namespace Login
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        //Login button  
        private void button1_Click(object sender, EventArgs e)
        {
            String userID = textBox1.Text;
            String userPassword = textBox2.Text;
            UService userservice = new UService(userID, userPassword);
            User user = userservice.getUser();

            if(user is Admin)
            {
                AdminForm form = new AdminForm(userservice);
                form.Show();
            } 
            else if (user is Employee)
            {
                EmployeeForm form = new EmployeeForm();
                form.setUserID(user.getID());
                form.Show();
            }
            else
            {
                MessageBox.Show("Wrong Username or Password");
            }
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
           
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string userID = textBox1.Text;
            if (userID != "")
            {
                UService userservice = new UService(userID, "");
                label3.Text = userservice.updatePassword(userID);
            }
            else MessageBox.Show("Nu ati introdus nimic");
            //Email sending
            /////////////////////
           /*
            var fromAddress = new MailAddress("stefanpaulp@gmail.com");
            var toAddress = new MailAddress("stefanpaulp@yahoo.com");
            const string fromPassword = "mypass";
            const string subject = "test";
            const string body = "Hey now!!";

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword),
                Timeout = 20000
            };
            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body
            })
            {
                smtp.Send(message);
            }
            * */////////////////////////////
        }
    }
}
