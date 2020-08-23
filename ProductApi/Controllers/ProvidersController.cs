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
        private DataContext context;
        public ProvidersController(DataContext ctx)
        {
            context = ctx;
        }
        [HttpGet("{path}")]
        public IActionResult GetProvider(string path, [FromQuery] GetProviderQueryObject request)
        {
            var query = context.Products
                .Include(p => p.Company)
                .ThenInclude(c => c.Provider);

            //query.AsEnumerable().Where(p => p.LoadTime <= request.To);
            //query.Where(p => p.LoadTime >= request.From);

            //if (int.TryParse(path, out int id))
            //    query.Where(p => p.Company.Provider.Id == id);
            //else
            //    query.Where(p => p.Company.Provider.Name.ToLower() == path.ToLower());

            //if (request.From.HasValue)
            //    query.Where(p => p.LoadTime >= request.From);
            //if (request.To.HasValue)
            //    query.Where(p => p.LoadTime <= request.To);

            return Ok(new
            {
                products = query.ToList().Where(p => p.LoadTime >= request.From && p.LoadTime <= request.To)
            });
        }
    }
}
