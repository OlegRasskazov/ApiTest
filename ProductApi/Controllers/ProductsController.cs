using ApplicationCore.Importers;
using Infrastructure.Models;
using Infrastructure.Dto;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
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
        private IProductRepository _productRepository;

        public ProductsController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        //задать тип принимаемого значения
        [HttpGet("{id}")]
        public Product GetProduct(int id)
        {
            return _productRepository.GetProduct(id);
        }

        [HttpGet]
        public Product[] GetProducts()
        {
            _productRepository.GetProducts(new Filter() { 
            From = DateTime.Now.AddMonths(-11),
            To = DateTime.Now,
            });
            return new Product[1];
        }

        [HttpPost]
        public IActionResult AddProduct(string product)
        {
            IImporter importer = new ImporterMock();
            var result = importer.Import();

            _productRepository.SaveProducts(result);

            return Ok();
        }
    }
}
