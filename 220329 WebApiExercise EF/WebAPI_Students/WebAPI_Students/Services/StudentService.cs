using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using WebAPI_Students.Models;

namespace WebAPI_Students.Services
{
    public class StudentService
    {
        /*
        private readonly school2Context context;
        public StudentService(school2Context context)
        {
            this.context = context;
        }
        */
        private readonly school2Context context = new school2Context();
                
        public IEnumerable<Student> GetAllStudent()
        {
            context.ChangeTracker.LazyLoadingEnabled = false; // lazy load kikapcsolása
            // Students lista visszaadása
            // return context.Students.ToList();
            return context.Students.Include(st => st.Subjects).ToList();
        }

        public Student GetStudentById(int id)
        {
            // return context.Students.Find(id);
            return context.Students.Include(student => student.Subjects).First(st => st.Id == id);
        }

    }
}
