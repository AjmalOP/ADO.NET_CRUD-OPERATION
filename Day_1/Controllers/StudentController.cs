using Day_1.Model;
using Day_1.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Day_1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        public readonly IStudentService _studentService;
        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }
        [HttpPut]
        public IActionResult AddStudent(Student std)
        {
            return Ok(_studentService.AddStudent(std));
        }
        [HttpGet]
        public IActionResult ShowStudent() 
        { 
            return Ok(_studentService.GetStudents());
        }
        [HttpGet("count")]
        public IActionResult GetCount()
        {
            return Ok(_studentService.GetCount());
        }
        [HttpDelete]
        public IActionResult DeleteStudent(int id)
        {
            return Ok(_studentService.DeleteStudent(id));
        }
        [HttpPost]
        public IActionResult UpdateStudents(Student std)
        {
            return Ok(_studentService.UpdateStudent(std));
        }
    }
}
