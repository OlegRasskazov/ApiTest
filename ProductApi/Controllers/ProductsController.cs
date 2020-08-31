using ApplicationCore.AppServices;
using Infrastructure.Dto.Filters;
using Infrastructure.Models;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;
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
        public IActionResult Get(int id)
        {
            try
            {
                var result = _productRepository.GetProduct(id);
                return Ok(result);
            }
            catch (Exception e)
            {
                //TODO: добавть логирование
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{name}")]
        public IActionResult Get(string name)
        {
            try
            {
                var result = _productRepository.GetProducts(new Filter()
                {
                    ProductNames = new List<string>() { name }
                });
                return Ok(result);
            }
            catch (Exception e)
            {
                //TODO: добавть логирование
                return BadRequest(e.Message);
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
            catch (Exception e)
            {
                return BadRequest(e.Message);
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
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        [HttpPost]
        [Consumes("application/json", "application/xml")]
        public IActionResult AddProductsByProvider([FromBody] Provider provider)
        {
            try
            {
                if (!_importService.Import(provider))
                    return BadRequest();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{productId:int}")]
        public IActionResult WithdrawProducts(int productId, int amount)
        {
            try
            {
                var product = _productRepository.GetProduct(productId);
                if (product.Amount < amount)
                    return BadRequest($"Insufficient quantity of product:{productId}");
                product.Amount -= amount;
                if (product.Amount == 0)
                {
                    _productRepository.Delete(product);
                    return Ok(product);
                }
                _productRepository.Update(product);
                return Ok(product);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
