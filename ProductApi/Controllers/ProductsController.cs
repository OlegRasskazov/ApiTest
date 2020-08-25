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
        private IProviderRepository _providerRepository;

        public ProductsController(IProductRepository productRepository, IProviderRepository providerRepository)
        {
            _productRepository = productRepository;
            _providerRepository = providerRepository;
        }
        //задать тип принимаемого значения
        [HttpGet("{id:int}")]
        public IActionResult GetProduct(int id)
        {
            try
            {
                var result = _productRepository.GetProduct(id);
                return Ok(result);
            }
            catch(Exception ex)
            {
                //TODO: добавть логирование
                return BadRequest();
            }
        }

        [HttpGet("{name:alpha}")]
        public IActionResult GetProduct(string name)
        {
            try
            {
                var result = _productRepository.GetProduct(1);
                return Ok(result);
            }
            catch (Exception ex)
            {
                //TODO: добавть логирование
                return BadRequest();
            }
        }

        [HttpGet("{providerId:int}&{from:datetime}&{to:datetime}")]
        public Product[] GetProductsByProvider(int? providerId, DateTime? from, DateTime? to)
        {

            return _productRepository.GetProducts(new Filter()
            {
                From = from,
                To = to,
                ProviderId = providerId
            });
        }

        [HttpGet("{companyId:alpha}&{from:datetime}&{to:datetime}")]
        public Product[] GetProductsByCompany(string companyId, DateTime? from, DateTime? to)
        {
            return _productRepository.GetProducts(new Filter()
            {
                From = from,
                To = to,
                CompanyId = companyId
            });
        }

        [HttpPost]
        [Consumes("application/json", "application/xml")]
        [Produces("application/json", "application/xml")]
        public IActionResult AddProduct([FromBody] Product product)
        {
            IImporter importer = new ImporterMock();
            var result = importer.Import();

            _providerRepository.AddProvider(result);

            return Ok();
        }
    }
}
