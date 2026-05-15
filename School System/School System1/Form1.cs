using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace School_System1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        DatabaseHelper db = new DatabaseHelper();
        private void button1_Click(object sender, EventArgs e)
        {
            string role;

            bool success = db.Login(textBox1.Text, textBox2.Text, out role);

            if (success && role == "admin")
            {
                MessageBox.Show("Login Successful");

                Form2 admin = new Form2();
                admin.Show();

                this.Hide();
            }
            else
            {
                MessageBox.Show("Invalid login or not admin");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
