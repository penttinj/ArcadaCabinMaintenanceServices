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
        public CabinsController(ILogger<CabinsController> logger)
        {
            _logger = logger;
            client = new HttpClient();
            cabinsUseCase = new CabinsUseCase(client);
        }

        // GET /cabins
        [HttpGet]
        public async Task<IActionResult> Get([FromHeader] string Authorization = "noToken")
        {
            try
            {
                _logger.LogInformation("Getting all cabins...");
                var result = await cabinsUseCase.GetAllCabinsAsync(Authorization);
                var response = StatusCode(200, result.Cabins);
                if (result.Cabins.Count == 0)
                {
                    return NotFound();
                }
                
                Response.Headers.Add("Authorization", result.Jwt.Scheme);

                return StatusCode(200, result.Cabins);
            }
            catch (Exception e)
            {
                _logger.LogInformation($"Caught exception: {e.Message}");
                return StatusCode(500, e.Message);
            }
        }
        // GET /cabins/<email>
        [HttpGet("{email}")]
        public async Task<IActionResult> GetCabinsByEmail(string email, [FromHeader] string Authorization = "noToken")
        {
                _logger.LogInformation($"Getting cabins by email: {email}");
            try
            {
                var result = await cabinsUseCase.GetByEmailAsync(Authorization, email);

                if (result == null)
                {
                    return NotFound();
                }

                Response.Headers.Add("Authorization", result.Jwt.Scheme);

                return StatusCode(200, result.Cabins);
            }
            catch (Exception e)
            {
                _logger.LogInformation($"Caught exception: {e.Message}");
                return StatusCode(500, e.Message);
            }
        }
    }
}