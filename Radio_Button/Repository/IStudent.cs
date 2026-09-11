using Radio_Button.Models;

namespace Radio_Button.Repository
{
    public interface IStudent
    {
        Task<List<Student>> GetStudents();

        Task<Student?> GetStudentById(int id);

        Task<bool> AddStudent(Student student);

        Task<bool> UpdateStudent(Student student);

        Task<bool> DeleteStudent(int id);
    }
}
