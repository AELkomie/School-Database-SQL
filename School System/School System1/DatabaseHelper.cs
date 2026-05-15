using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace School_System1

{
    
    public class DatabaseHelper
    {
        private readonly string connectionString;
        public DatabaseHelper()
        {
            connectionString = @"Server=AELS-PC\SQLEXPRESS;Database=School;Trusted_Connection=True";
        }
        private SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
        public bool Login(string username, string password, out string role)
        {
            role = null;

            using (SqlConnection conn = GetConnection())
            {
                conn.Open();

                string query = "SELECT role FROM Users WHERE username=@u AND password=@p";

                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@u", username);
                cmd.Parameters.AddWithValue("@p", password);

                object result = cmd.ExecuteScalar();

                if (result != null)
                {
                    role = result.ToString();
                    return true;
                }

                return false;
            }
        }

        public DataTable GetStudents()
        {
            DataTable dt = new DataTable();

            string query = @"
                SELECT student_id, first_name, last_name, email, age
                FROM student
                WHERE age >= 0
                ORDER BY first_name";

            using (SqlConnection conn = GetConnection())
            {
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                da.Fill(dt);
            }

            return dt;
        }

        public DataTable GetTeachers()
        {
            DataTable dt = new DataTable();

            string query = @"
                SELECT teacher_id, first_name, email
                FROM teacher
                WHERE hire_date >'2020-01-01'
                ORDER BY first_name";

            using (SqlConnection conn = GetConnection())
            {
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                da.Fill(dt);
            }

            return dt;
        }

        public DataTable GetCourses()
        {
            DataTable dt = new DataTable();

            string query = @"
                SELECT course_id, course_name, credit_hour
                FROM course
                WHERE credit_hour > 2
                ORDER BY course_name";

            using (SqlConnection conn = GetConnection())
            {
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                da.Fill(dt);
            }

            return dt;
        }

        public DataTable GetExamMaxMarks()
        {
            DataTable dt = new DataTable();

            string query = @"
               SELECT exam_date,
               MAX(total_marks) AS MaxMarks
               FROM Exam
               GROUP BY exam_date
               HAVING MAX(total_marks) > 5
               ORDER BY MaxMarks DESC";

            using (SqlConnection conn = GetConnection())
            {
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                da.Fill(dt);
            }

            return dt;
        }

        public DataTable GetMinCreditHours()
        {
            DataTable dt = new DataTable();

            string query = @"
             SELECT course_name, MIN(credit_hour) AS MinCredits
             FROM course
             GROUP BY course_name
             HAVING MIN(credit_hour) > 0
             ORDER BY MinCredits";

            using (SqlConnection conn = GetConnection())
            {
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                da.Fill(dt);
            }

            return dt;
        }

        public DataTable GetMaxAgeByAddress()
        {
            DataTable dt = new DataTable();

            string query = @"
             SELECT address,
             MAX(DATEDIFF(YEAR, date_of_birth, GETDATE())) AS MaxAge
             FROM student
             GROUP BY address
             HAVING MAX(DATEDIFF(YEAR, date_of_birth, GETDATE())) >= 18
             ORDER BY MaxAge DESC";

            using (SqlConnection conn = GetConnection())
            {
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                da.Fill(dt);
            }

            return dt;
        }

        public DataTable studentmultiplecourse()
        {
            DataTable dt = new DataTable();

            string query = @"
             SELECT first_name, last_name
             FROM student
             WHERE student_id IN (
             SELECT student_id
             FROM enrollment
             GROUP BY student_id
             HAVING COUNT(course_id) > 1
             )";

            using (SqlConnection conn = GetConnection())
            {
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                da.Fill(dt);
            }

            return dt;
        }

        public DataTable Teachercoursebiggerthan30()
        {
            DataTable dt = new DataTable();

            string query = @"
            SELECT first_name, last_name
            FROM teacher
            WHERE teacher_id IN (
            SELECT teacher_id
            FROM class_section
            WHERE course_id IN (
            SELECT course_id
            FROM course
            WHERE max_capacity > 30
            )
            )";

            using (SqlConnection conn = GetConnection())
            {
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                da.Fill(dt);
            }

            return dt;
        }

        public DataTable marksmorethanaverage()
        {
            DataTable dt = new DataTable();

            string query = @"
            SELECT student_id, marks_obtained
            FROM exam_result
            WHERE marks_obtained > (
            SELECT AVG(marks_obtained)
            FROM exam_result
            )";

            using (SqlConnection conn = GetConnection())
            {
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                da.Fill(dt);
            }

            return dt;
        }

        public DataTable enrollmentjoinstudent()
        {
            DataTable dt = new DataTable();

            string query = @"
             SELECT 
             student.first_name,
             student.last_name,
             course.course_name,
             enrollment.grade_letter
             FROM enrollment
             INNER JOIN student
             ON enrollment.student_id = student.student_id
             INNER JOIN course
             ON enrollment.course_id = course.course_id";

            using (SqlConnection conn = GetConnection())
            {
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                da.Fill(dt);
            }

            return dt;
        }

        public DataTable teacherjoinsection()
        {
            DataTable dt = new DataTable();

            string query = @"
            Select
            teacher.first_name,
            teacher.last_name,
            class_section.section_number
            FROM teacher
            LEFT OUTER JOIN class_section
            ON teacher.teacher_id = class_section.teacher_id";

            using (SqlConnection conn = GetConnection())
            {
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                da.Fill(dt);
            }

            return dt;
        }

        public DataTable examjoinstudent()
        {
            DataTable dt = new DataTable();

            string query = @"
            SELECT 
            student.first_name,
            student.last_name,
            exam_result.marks_obtained,
            exam_result.grade
            FROM exam_result
            INNER JOIN student
            ON exam_result.student_id = student.student_id";

            using (SqlConnection conn = GetConnection())
            {
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                da.Fill(dt);
            }

            return dt;
        }

    }
}