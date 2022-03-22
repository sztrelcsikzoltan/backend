using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using WebApiExercise.Models;

namespace WebApiExercise.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        [HttpGet]
        public JsonResult Get(string email) // get
        {
            List<Employee> employees = new List<Employee>();
            using (var context = new mySchemaContext())
            {
                try
                {
                    if (email == null)
                    {
                    return new JsonResult(context.Employees.ToList()); // get all employees
                    }
                    else
                    {
                        List<Employee> employee = new List<Employee>(context.Employees.Where(e => e.Email == email));
                        return new JsonResult(employee); // get one employee
                    }
                }
                catch (System.Exception ex)
                {

                    return new JsonResult(ex.Message);
                }
            }
        }

        [HttpPost]
        public JsonResult Post(Employee employee) // insert new employee
        {
            using (var context = new mySchemaContext())
            {
                try
                {
                    context.Employees.Add(employee);
                    context.SaveChanges();
                    return new JsonResult("Alkalmazott felvétele megtörtént.");
                }
                catch (System.Exception ex)
                {

                    return new JsonResult(ex.Message);
                }
            }
        }

        [HttpPut]
        public JsonResult Put(Employee employee) // update employee
        {
            using (var context = new mySchemaContext())
            {
                try
                {
                    context.Employees.Update(employee);
                    context.SaveChanges();
                    return new JsonResult("Az adatok módosítása megtörtént.");
                }
                catch (System.Exception ex)
                {

                    return new JsonResult(ex.Message);
                }
            }
        }

        [HttpDelete]
        public JsonResult Delete(string email) // delete employee
        {
            using (var context = new mySchemaContext())
            {
                try
                {
                    // Employee employee = context.Employees.Find(id);
                    Employee employee = new Employee();
                    employee.Email = email;
                    context.Employees.Remove(employee);
                    context.SaveChanges();
                    return new JsonResult("Törlés sikeresen megtörtént.");
                }
                catch (System.Exception ex)
                {

                    return new JsonResult(ex.Message);
                }
            }
        }


    }
}
