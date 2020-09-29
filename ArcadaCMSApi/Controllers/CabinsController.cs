using ArcadaCMSApi.UseCases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ArcadaCMSApi.Interfaces;
using ArcadaCMSApi.Models;
using Nancy.Json;
using System.Net.Http;

namespace ArcadaCMSApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CabinsController : ControllerBase
    {
        private readonly ILogger<CabinsController> _logger;
        private HttpClient client;
        private CabinsUseCase cabinsUseCase;
        public CabinsController(ILogger<CabinsController> logger)
        {
            _logger = logger;
            client = new HttpClient();
            cabinsUseCase = new CabinsUseCase(client);
        }

        // GET /cabins
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                _logger.LogInformation("Getting all cabins...");
                var cabins = await cabinsUseCase.GetAll("eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJfaWQiOiI1ZjcyMWZlZGEwN2I4MDAwMzUwYjllOWEiLCJlbWFpbCI6InBlZ2d5X2hvcGtpbnNAZXhhbXBsZS5vcmciLCJpYXQiOjE2MDE0MDk5MTksImV4cCI6MTYwMTQxMDgxOX0.jE2HT2PToIPV4TB571o4w0kkUTWqtSaNF-p0QM3TZCo");





                return StatusCode(200, cabins);
            }
            catch (Exception e)
            {
                var stack = e;
                _logger.LogInformation($"Caught exception: {e.Message}");
                return StatusCode(500, e.Message);
            }
        }
        // GET /cabins/<email>
        [HttpGet("{email}")]
        public IActionResult GetOne()
        {
            try
            {
                var result = "";
                _logger.LogInformation("Getting all cabins...");
                return StatusCode(200, result);
            }
            catch (Exception e)
            {
                _logger.LogInformation($"Caught exception: {e.Message}");
                return StatusCode(500, e.Message);
            }
        }
    }
}