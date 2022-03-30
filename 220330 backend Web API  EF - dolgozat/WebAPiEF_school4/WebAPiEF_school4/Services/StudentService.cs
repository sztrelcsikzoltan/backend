using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using WebAPiEF_school4.Models;

namespace WebAPiEF_school4.Services
{
    public class StudentService
    {
        private readonly school4Context context;
        public StudentService(school4Context context)
        {
            this.context = context;
        }

        public IEnumerable<Student> GetAllStudents()
        {
            return context.Students.Include(st => st.Subjects).Include(st => st.Grades).ToList();
        }

        public Student GetStudentByEmail(string email)
        {
            Student student = context.Students.Include(st => st.Subjects).Include(st => st.Grades).First(x => x.Email == email);
            return student;
        }

        public IEnumerable<Grade> GetGradesByStudentId(int id)
        {
           IEnumerable<Grade> grades = context.Grades.Where(gr => gr.StudentId == id).ToList();
            return grades;
        }

        /*
        public Student GetStudentGradeById(int id)
        {
            Student student = context.Students.Include(st => st.Grades).First(x => Student.Id == id);
            return student;
        }
        */


    }
}
