using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using WebApiExercise.Models;

namespace WebApiExercise.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        [HttpGet]
        public JsonResult Get(int orderNumber) // get 
        {
            List<Order> orders = new List<Order>();
            using (var context = new mySchemaContext())
            {
                try
                {
                    if (orderNumber == 0)
                    {
                    return new JsonResult(context.Orders.ToList()); // get all orders
                    }
                    else
                    {
                        List<Order> order = new List<Order>(context.Orders.Where(o => o.OrderNumber  == orderNumber));
                        return new JsonResult(order); // get one order
                    }
                }
                catch (System.Exception ex)
                {

                    return new JsonResult(ex.Message);
                }
            }
        }

        [HttpPost]
        public JsonResult Post(Order order) // insert new order
        {
            using (var context = new mySchemaContext())
            {
                try
                {
                    context.Orders.Add(order);
                    context.SaveChanges();
                    return new JsonResult("Megrendelés felvétele megtörtént.");
                }
                catch (System.Exception ex)
                {

                    return new JsonResult(ex.Message);
                }
            }
        }

        [HttpPut]
        public JsonResult Put(Order order) // update order
        {
            using (var context = new mySchemaContext())
            {
                try
                {
                    context.Orders.Update(order);
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
        public JsonResult Delete(int orderNumber) // delete order
        {
            using (var context = new mySchemaContext())
            {
                try
                {
                    // Order order = context.Orders.Find(orderNumber);
                    Order order = new Order();
                    order.OrderNumber = orderNumber;
                    context.Orders.Remove(order);
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
