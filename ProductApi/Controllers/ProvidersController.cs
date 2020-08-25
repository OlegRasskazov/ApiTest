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
            return Ok();
        }
    }
}
