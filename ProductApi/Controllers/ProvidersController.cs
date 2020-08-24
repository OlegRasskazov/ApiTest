using Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductApi.Extensions;
using ProductApi.Models;
using ProductApi.Models.Bindings;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace ProductApi.Controllers
{
    [Route("api/providers")]
    [ApiController]
    public class ProvidersController : Controller
    {
        private IProviderRepository _providerRepository;
        public ProvidersController(IProviderRepository providerRepository)
        {
            _providerRepository = providerRepository;
        }
        [HttpGet("{path}")]
        public IActionResult GetProvider(string path, [FromQuery] GetProviderQueryObject request)
        {
            //var query = context.Products
            //    .Include(p => p.Company)
            //    .ThenInclude(c => c.Provider).AsQueryable();

            //if (int.TryParse(path, out int id))
            //    query = query.Where(p => p.Company.Provider.Id == id);
            //else
            //    query = query.Where(p => p.Company.Provider.Name.ToLower() == path.ToLower());

            //if (request.From.HasValue)
            //    query = query.Where(p => p.LoadTime >= request.From);
            //if (request.To.HasValue)
            //    query = query.Where(p => p.LoadTime <= request.To);

            return Ok(new
            {
                //products = query.ToArray()
            }); ;
        }
    }
}
