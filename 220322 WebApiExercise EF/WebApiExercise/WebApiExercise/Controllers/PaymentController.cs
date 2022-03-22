using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using WebApiExercise.Models;

namespace WebApiExercise.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        [HttpGet]
        public JsonResult Get(int customerNumber) // get 
        {
            List<Payment> payments = new List<Payment>();
            using (var context = new mySchemaContext())
            {
                try
                {
                    if (customerNumber == 0)
                    {
                    return new JsonResult(context.Payments.ToList()); // get all payments
                    }
                    else
                    {
                        List<Payment> payment = new List<Payment>(context.Payments.Where(p => p.CustomerNumber  == customerNumber));
                        return new JsonResult(payment); // get one payment
                    }
                }
                catch (System.Exception ex)
                {

                    return new JsonResult(ex.Message);
                }
            }
        }

        [HttpPost]
        public JsonResult Post(Payment payment) // insert new payment
        {
            using (var context = new mySchemaContext())
            {
                try
                {
                    context.Payments.Add(payment);
                    context.SaveChanges();
                    return new JsonResult("Fizetés felvétele megtörtént.");
                }
                catch (System.Exception ex)
                {

                    return new JsonResult(ex.Message);
                }
            }
        }

        [HttpPut]
        public JsonResult Put(Payment payment) // update payment
        {
            using (var context = new mySchemaContext())
            {
                try
                {
                    context.Payments.Update(payment);
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
        public JsonResult Delete(int customerNumber) // delete payment
        {
            using (var context = new mySchemaContext())
            {
                try
                {
                    // Payment payment = context.Payments.Find(paymentNumber);
                    Payment payment = new Payment();
                    payment.CustomerNumber = customerNumber;
                    context.Payments.Remove(payment);
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
