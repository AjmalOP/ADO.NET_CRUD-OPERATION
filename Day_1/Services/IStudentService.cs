using Day_1.Model;

namespace Day_1.Services
{
    public interface IStudentService
    {
        public string AddStudent(Student std);
        public List<Student> GetStudents();
        public int GetCount();
        public string DeleteStudent(int id);
        public string UpdateStudent(Student std);
    }
}
