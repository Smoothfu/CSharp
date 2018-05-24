using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Entity;

namespace ConsoleApp178
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    public class AutoLotEntities: DbContext
    {
        public AutoLotEntities() base("name=AutoLotConnection")
        {

        }

        protected override void Dispose(bool disposing)
        {
           
        }
    }
}
