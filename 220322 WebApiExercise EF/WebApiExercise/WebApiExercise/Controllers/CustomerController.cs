using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using WebApiExercise.Models;

namespace WebApiExercise.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        [HttpGet]
        public JsonResult Get(int customerNumber) // get 
        {
            List<Customer> customers = new List<Customer>();
            using (var context = new mySchemaContext())
            {
                try
                {
                    if (customerNumber == 0)
                    {
                    return new JsonResult(context.Customers.ToList()); // get all customers
                    }
                    else
                    {
                        List<Customer> customer = new List<Customer>(context.Customers.Where(c => c.CustomerNumber  == customerNumber));
                        return new JsonResult(customer); // get one customer
                    }
                }
                catch (System.Exception ex)
                {

                    return new JsonResult(ex.Message);
                }
            }
        }

        [HttpPost]
        public JsonResult Post(Customer customer) // insert new customer
        {
            using (var context = new mySchemaContext())
            {
                try
                {
                    context.Customers.Add(customer);
                    context.SaveChanges();
                    return new JsonResult("Ügyfél felvétele megtörtént.");
                }
                catch (System.Exception ex)
                {

                    return new JsonResult(ex.Message);
                }
            }
        }

        [HttpPut]
        public JsonResult Put(Customer customer) // update customer
        {
            using (var context = new mySchemaContext())
            {
                try
                {
                    context.Customers.Update(customer);
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
        public JsonResult Delete(int customerNumber) // delete customer
        {
            using (var context = new mySchemaContext())
            {
                try
                {
                    // Customer customer = context.Customers.Find(customerNumber);
                    Customer customer = new Customer();
                    customer.CustomerNumber = customerNumber;
                    context.Customers.Remove(customer);
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
