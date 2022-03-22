using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using WebApiExercise.Models;

namespace WebApiExercise.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        [HttpGet]
        public JsonResult Get(string productCode) // get
        {
            List<Product> products = new List<Product>();
            using (var context = new mySchemaContext())
            {
                try
                {
                    if (productCode == null)
                    {
                    return new JsonResult(context.Products.ToList()); // get all products
                    }
                    else
                    {
                        List<Product> product = new List<Product>(context.Products.Where(o => o.ProductCode == productCode));
                        return new JsonResult(product); // get one product
                    }
                }
                catch (System.Exception ex)
                {

                    return new JsonResult(ex.Message);
                }
            }
        }

        [HttpPost]
        public JsonResult Post(Product product) // insert new product
        {
            using (var context = new mySchemaContext())
            {
                try
                {
                    context.Products.Add(product);
                    context.SaveChanges();
                    return new JsonResult("Termék felvétele megtörtént.");
                }
                catch (System.Exception ex)
                {

                    return new JsonResult(ex.Message);
                }
            }
        }

        [HttpPut]
        public JsonResult Put(Product product) // update product
        {
            using (var context = new mySchemaContext())
            {
                try
                {
                    context.Products.Update(product);
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
        public JsonResult Delete(string productCode) // delete product
        {
            using (var context = new mySchemaContext())
            {
                try
                {
                    // Product product = context.Products.Find(productCode);
                    Product product = new Product();
                    product.ProductCode = productCode;
                    context.Products.Remove(product);
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
