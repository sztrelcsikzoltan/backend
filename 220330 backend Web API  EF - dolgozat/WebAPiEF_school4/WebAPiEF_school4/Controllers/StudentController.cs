using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebAPiEF_school4.Models;
using WebAPiEF_school4.Services;

namespace WebAPiEF_school4.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentController : Controller
    {
        private readonly StudentService studentService;
        public StudentController(StudentService student)
        {
            this.studentService = student;
        }

        [HttpGet]
        public IEnumerable<Student> GetAllStudents()
        {
            return studentService.GetAllStudents();
        }

        [HttpGet]
        [Route("GetStudentByEmail")]
        public Student GetStudentByEmail([FromQuery] string email)
        {
            return studentService.GetStudentByEmail(email);
        }

        [HttpGet]
        [Route("GetGradesByStudentId")]
        public IEnumerable<Grade> GetGradesByStudentId([FromQuery] int id)
        {
            return studentService.GetGradesByStudentId(id);
        }
        /*
        [Route("GetStudentGradeById")]
        public Student GetStudentGradeByEmail([FromQuery] int id)
        {
            return studentService.GetStudentGradeById(id);
        }
        */
    }
}
