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
using System.Net;

namespace ArcadaCMSApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CabinsController : ControllerBase
    {
        private readonly ILogger<CabinsController> _logger;
        private HttpClient client;
        private CabinsUseCase cabinsUseCase;
        private string jwt;
        public CabinsController(ILogger<CabinsController> logger)
        {
            _logger = logger;
            client = new HttpClient();
            cabinsUseCase = new CabinsUseCase(client);
            jwt = "";
        }

        // GET /cabins
        [HttpGet]
        public async Task<IActionResult> Get([FromHeader] string Authorization = "noToken")
        {
            _logger.LogInformation($"HeAdEr1 {Authorization}");
            jwt = Authorization;
            try
            {
                _logger.LogInformation("Getting all cabins...");
                var cabins = await cabinsUseCase.GetAll(jwt);





                return StatusCode(200, cabins);
            }
            catch (Exception e)
            {
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