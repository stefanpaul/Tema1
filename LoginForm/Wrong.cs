using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Login
{
    public partial class Wrong : Form
    {
        public Wrong()
        {
            InitializeComponent();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        public void write(string text)
        {
            richTextBox1.Text = text;
        }

        private void Wrong_Load(object sender, EventArgs e)
        {

        }
    }
}
