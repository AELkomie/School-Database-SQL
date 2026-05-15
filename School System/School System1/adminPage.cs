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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 home = new Form1();
            home.Show();

            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SelectForm f = new SelectForm("student");
            f.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SelectForm f = new SelectForm("teacher");
            f.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SelectForm f = new SelectForm("course");
            f.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SelectForm f = new SelectForm("exam_max");
            f.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            SelectForm f = new SelectForm("student_max_age");
            f.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            SelectForm f = new SelectForm("course_min");
            f.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            SelectForm f = new SelectForm("multi_student");
            f.Show();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            SelectForm f = new SelectForm("teacher>30");
            f.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            SelectForm f = new SelectForm("marksmorethanaverage");
            f.Show();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            SelectForm f = new SelectForm("enrollmentjoin");
            f.Show();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            SelectForm f = new SelectForm("teacherjoinsection");
            f.Show();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            SelectForm f = new SelectForm("examjoinstudent");
            f.Show();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            removeStudent s = new removeStudent();

            s.Show();
            this.Hide();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            addStudent s = new addStudent();

            s.Show();
            this.Hide();
        }
    }
}
