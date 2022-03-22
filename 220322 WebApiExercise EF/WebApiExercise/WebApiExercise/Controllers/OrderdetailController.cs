using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using WebApiExercise.Models;

namespace WebApiExercise.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderdetailController : ControllerBase
    {
        [HttpGet]
        public JsonResult Get(int orderNumber) // get 
        {
            List<Orderdetail> orderdetails = new List<Orderdetail>();
            using (var context = new mySchemaContext())
            {
                try
                {
                    if (orderNumber == 0)
                    {
                    return new JsonResult(context.Orderdetails.ToList()); // get all orderdetails
                    }
                    else
                    {
                        List<Orderdetail> orderdetail = new List<Orderdetail>(context.Orderdetails.Where(o => o.OrderNumber  == orderNumber));
                        return new JsonResult(orderdetail); // get one orderdetail
                    }
                }
                catch (System.Exception ex)
                {

                    return new JsonResult(ex.Message);
                }
            }
        }

        [HttpPost]
        public JsonResult Post(Orderdetail orderdetail) // insert new orderdetail
        {
            using (var context = new mySchemaContext())
            {
                try
                {
                    context.Orderdetails.Add(orderdetail);
                    context.SaveChanges();
                    return new JsonResult("Megrendelés részletek felvétele megtörtént.");
                }
                catch (System.Exception ex)
                {

                    return new JsonResult(ex.Message);
                }
            }
        }

        [HttpPut]
        public JsonResult Put(Orderdetail orderdetail) // update order
        {
            using (var context = new mySchemaContext())
            {
                try
                {
                    context.Orderdetails.Update(orderdetail);
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
        public JsonResult Delete(int orderNumber) // delete orderdetail
        {
            using (var context = new mySchemaContext())
            {
                try
                {
                    // Orderdetail orderdetail = context.Orderdetails.Find(orderNumber);
                    Orderdetail orderdetail = new Orderdetail();
                    orderdetail.OrderNumber = orderNumber;
                    context.Orderdetails.Remove(orderdetail);
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
