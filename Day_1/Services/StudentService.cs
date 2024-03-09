using Day_1.Model;
using Microsoft.Data.SqlClient;

namespace Day_1.Services
{
    public class StudentService : IStudentService
    {
        readonly string connectionStr = "data source = AJMAL ; database = 4TH_WEEK ; integrated security = SSPI ; TrustServerCertificate = true";
        public string AddStudent(Student std)
        {
            using (SqlConnection connection = new SqlConnection(connectionStr))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("insert into STUDENTS values (@FirstName,@LastName,@Age)", connection);
                command.Parameters.AddWithValue("@FirstName",std.FirstName);
                command.Parameters.AddWithValue("@LastName", std.LastName);
                command.Parameters.AddWithValue("@Age", Convert.ToInt32(std.Age));
                int EffectedRow = command.ExecuteNonQuery();
                return EffectedRow + "Effected Row";
            }
        }
        public List<Student> GetStudents()
        {
            List<Student> stds = new List<Student>();
            using (SqlConnection connection = new SqlConnection(connectionStr))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("Select * from STUDENTS",connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Student student = new Student();
                    student.Id = Convert.ToInt32(reader["StudentID"]);
                    student.FirstName = reader["FirstName"].ToString();
                    student.LastName = reader["LastName"].ToString();
                    student.Age = Convert.ToInt32(reader["Age"]);
                    stds.Add(student);
                }
                return stds;
            }
        }
        public int GetCount()
        {
            using(SqlConnection connection = new SqlConnection(connectionStr))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("select count(StudentID) as TotalStudents from STUDENTS ", connection);
                int Total = (int)command.ExecuteScalar();
                return Total;
            }
        }
        public string DeleteStudent(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionStr))
            {
                connection.Open();
                SqlCommand command = new SqlCommand($"Delete from STUDENTS where StudentID = {id}", connection);
                int EffectedRow = command.ExecuteNonQuery();
                return EffectedRow+"  effected Row";
            }
        }
        public string UpdateStudent(Student std)
        {
            using (SqlConnection connection = new SqlConnection(connectionStr))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("update STUDENTS set FirstName = @FirstName , LastName = @LastName , Age = @Age where StudentID = @Id",connection);
                command.Parameters.AddWithValue("@FirstName", std.FirstName);
                command.Parameters.AddWithValue("@LastName", std.LastName);
                command.Parameters.AddWithValue("@Age", std.Age);
                command.Parameters.AddWithValue("@Id", std.Id);
                int EffectedRow = command.ExecuteNonQuery();
                return EffectedRow+" Effected Row";
            }
        }
    }
}
