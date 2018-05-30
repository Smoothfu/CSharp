using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApplication4.Controllers
{
    public class HelloWorldController : ApiController
    {
        [HttpGet]
        public string SayHello()
        {
            return "Cherish the present moment!";
        }
        public string Get()
        {
            return "OK";
        }

        public string Get(string id)
        {
            return "Get: " + id;
        }

        public string Post()
        {
            return "post";
        }

        public string Put()
        {
            return "Put";
        }

        public string Delete()
        {
            return "delete";
        }
    }
}
