using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace School_System1
{
    public partial class removeStudent : Form
    {
        public removeStudent()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 back = new Form2();

            back.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DatabaseHelper db = new DatabaseHelper();
            db.DeleteStudent(int.Parse(textBox1.Text));

            MessageBox.Show("Student removed successfully");
        }
    }
}
