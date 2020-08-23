using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.VisualBasic;
using ProductApi.Importers;
using ProductApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductApi.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductsController : Controller
    {
        private DataContext context;

        public ProductsController(DataContext ctx)
        {

            context = ctx;
        }
        //задать тип принимаемого значения
        [HttpGet("{path}")]
        public Product GetProduct(string path)
        {
            if (int.TryParse(path, out int id))
            {
                return context.Products
                    .FirstOrDefault(p => p.Id == id);
            }
            else {
                return context.Products.FirstOrDefault(p => path.Equals(p.Name));
            };
        }

        [HttpGet]
        public Product[] GetProducts()
        {
            return context.Products
                .Include(p => p.Company)
                .ThenInclude(c => c.Provider)
                .ToArray();
        }

        [HttpPost]
        public IActionResult AddProduct(string product)
        {
            IImporter importer = new ImporterMock();
            var result = importer.Import();

            context.Add(result);
            context.SaveChanges();

            return Ok();
        }
    }
}
