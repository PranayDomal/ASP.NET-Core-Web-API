using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Radio_Button.Models;
using Radio_Button.Repository;

namespace Radio_Button.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudent _studentRepository;

        public StudentController(IStudent studentRepository)
        {
            _studentRepository = studentRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetStudents()
        {
            var students = await _studentRepository.GetStudents();

            return Ok(students);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetStudentById(int id)
        {
            var student =
                await _studentRepository.GetStudentById(id);

            if (student == null)
            {
                return NotFound("Student not found");
            }

            return Ok(student);
        }

        [HttpPost]
        public async Task<IActionResult> AddStudent(
            [FromBody] Student student)
        {
            var result =
                await _studentRepository.AddStudent(student);

            return Ok("Student added successfully!");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateStudent(
            [FromBody] Student student)
        {
            var result =
                await _studentRepository.UpdateStudent(student);

            if (!result)
            {
                return NotFound("Student not found");
            }

            return Ok("Student updated successfully!");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            var result =
                await _studentRepository.DeleteStudent(id);

            if (!result)
            {
                return NotFound("Student not found");
            }

            return Ok("Student deleted successfully!");
        }
    }
}
