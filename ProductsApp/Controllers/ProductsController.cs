using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ProductsApp.Models;

namespace ProductsApp.Controllers
{
    public class ProductsController : ApiController
    {
        Product[] products = new Product[]
        {
            new Product{Id=1,Name="Benz",Category="MB",Price=1M},
            new Product{Id=2,Name="RangeRover",Category="RR",Price=2M},
            new Product{Id=3,Name="Toyto",Category="Pardo",Price=3M}
        };

        public IEnumerable<Product> GetAllProducts()
        {
            return products;
        }

        public IHttpActionResult GetProduct(int id)
        {
            var product = products.FirstOrDefault(x => x.Id == id);
            if(product==null)
            {
                return NotFound();
            }
            return Ok(product);
        }
    }
}
