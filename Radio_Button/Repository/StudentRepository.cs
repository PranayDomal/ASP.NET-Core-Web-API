using Microsoft.EntityFrameworkCore;
using Radio_Button.Data;
using Radio_Button.Models;

namespace Radio_Button.Repository
{
    public class StudentRepository : IStudent
    {
        private readonly AppDbContext _context;

        public StudentRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Student>> GetStudents()
        {
            return await _context.Student
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Student?> GetStudentById(int id)
        {
            return await _context.Student
                .AsNoTracking()
                .FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<bool> AddStudent(Student student)
        {
            _context.Student.Add(student);

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> UpdateStudent(Student student)
        {
            var existingStudent = await _context.Student
                .FindAsync(student.Id);

            if (existingStudent == null)
            {
                return false;
            }

            existingStudent.Name = student.Name;
            existingStudent.Email = student.Email;
            existingStudent.Mobile = student.Mobile;
            existingStudent.CountryId = student.CountryId;
            existingStudent.StateId = student.StateId;
            existingStudent.DistrictId = student.DistrictId;
            existingStudent.GenderId = student.GenderId;

            await _context.SaveChangesAsync();

            return true;
        }

        // DELETE STUDENT
        public async Task<bool> DeleteStudent(int id)
        {
            var student = await _context.Student
                .FindAsync(id);

            if (student == null)
            {
                return false;
            }

            _context.Student.Remove(student);

            await _context.SaveChangesAsync();

            return true;
        }
    }
}
