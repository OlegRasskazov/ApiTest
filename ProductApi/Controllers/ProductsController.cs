using ApplicationCore.AppServices;
using Infrastructure.Dto.Filters;
using Infrastructure.Models;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace ProductApi.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductsController : Controller
    {
        private IProductRepository _productRepository;
        private IProviderRepository _providerRepository;
        private IImportService _importService;

        public ProductsController(
            IProductRepository productRepository,
            IProviderRepository providerRepository,
            IImportService importService)
        {
            _productRepository = productRepository;
            _providerRepository = providerRepository;
            _importService = importService;
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
            catch
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
            catch
            {
                //TODO: добавть логирование
                return BadRequest();
            }
        }

        [HttpGet("ByProvider/{providerId:int}")]
        public IActionResult GetProductsByProvider(int providerId, DateTime? from, DateTime? to)
        {
            try
            {
                var result = _productRepository.GetProducts(new Filter()
                {
                    From = from,
                    To = to,
                    ProviderIds = new List<int>() { providerId }
                });
                return Ok(result);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("ByCompany/{companyId:int}")]
        public IActionResult GetProductsByCompany(int companyId, DateTime? from, DateTime? to)
        {
            try
            {
                var result = _productRepository.GetProducts(new Filter()
                {
                    From = from,
                    To = to,
                    CompanyIds = new List<int>() { companyId }
                });

                return Ok(result);
            }
            catch
            {
                return BadRequest();
            }

        }

        [HttpPost]
        [Consumes("application/json", "application/xml")]
        public IActionResult AddProductsByProvider([FromBody] Provider provider)
        {
            if (!_importService.Import(provider))
                return BadRequest();
            return Ok();
        }
    }
}
