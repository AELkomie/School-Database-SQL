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
    public partial class SelectForm : Form
    {
        DatabaseHelper db = new DatabaseHelper();
        string type;
        public SelectForm(string tableType)
        {
            InitializeComponent();
            type = tableType;
            this.Load += SelectForm_Load;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void SelectForm_Load(object sender, EventArgs e)
        {
            if (type == "student")
            {
                dataGridView1.DataSource = db.GetStudents();
            }
            else if (type == "teacher")
            {
                dataGridView1.DataSource = db.GetTeachers();
            }
            else if (type == "course")
            {
                dataGridView1.DataSource = db.GetCourses();
            }
            else if (type == "exam_max")
            {
                dataGridView1.DataSource = db.GetExamMaxMarks();
            }
            else if (type == "course_min")
            {
                dataGridView1.DataSource = db.GetMinCreditHours();
            }
            else if (type == "student_max_age")
            {
                dataGridView1.DataSource = db.GetMaxAgeByAddress();
            }
            else if (type == "multi_student")
            {
                dataGridView1.DataSource = db.studentmultiplecourse();
            }
            else if (type == "teacher>30")
            {
                dataGridView1.DataSource = db.Teachercoursebiggerthan30();
            }
            else if (type == "marksmorethanaverage")
            {
                dataGridView1.DataSource = db.marksmorethanaverage();
            }
            else if (type == "enrollmentjoin")
            {
                dataGridView1.DataSource = db.enrollmentjoinstudent();
            }
            else if (type == "teacherjoinsection")
            {
                dataGridView1.DataSource = db.teacherjoinsection();
            }
            else if (type == "examjoinstudent")
            {
                dataGridView1.DataSource = db.examjoinstudent();
            }
        }

    }
}
