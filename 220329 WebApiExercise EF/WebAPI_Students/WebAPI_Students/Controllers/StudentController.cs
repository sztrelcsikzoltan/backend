using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Collections.Generic;
using WebAPI_Students.Models;
using WebAPI_Students.Services;

namespace WebAPI_Students.Controllers
{
    [Controller]
    [Route("[controller]")]
    public class StudentController : Controller
    {
        /*
        // dependency injection: a különböző service-eket megkapja a kontroller: az alkalmazás indulásakor felépül egy alkalmazás context, amibe bekerül az alkalmazsá context egszer (SingleTon): egy van belőle; a studenService-ből létrehoz egy példányt, és beinjáktálja a kontruktorba
        private readonly StudentService studentService;
        public StudentController(StudentService studentService)
        {
            this.studentService = studentService;
        }
        */
        private readonly StudentService studentService = new StudentService();

        [HttpGet]
        public IEnumerable<Student> GetAllStudents()
        {
            // itt még role szerinti korlátozást is be lehet állítani
            return studentService.GetAllStudent();

        }

        [HttpGet]
        [Route("{id}")]
        public Student GetStudentById(int id)
        {
            return studentService.GetStudentById(id);
        }
    }
}
