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

namespace ArcadaCMSApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ServicesController : ControllerBase
    {
        private readonly ILogger<ServicesController> _logger;
        private readonly IServiceUseCase _serviceUseCase;
        public ServicesController(ILogger<ServicesController> logger, IServiceUseCase serviceUseCase)
        {
            _logger = logger;
            _serviceUseCase = serviceUseCase;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var result = _serviceUseCase.GetAll();
                _logger.LogInformation("Getting all services...");
                return StatusCode(200, result);
            }
            catch (Exception e)
            {
                _logger.LogInformation($"Caught exception: {e.Message}");
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] Service service)
        {
            try
            {
                Boolean result = _serviceUseCase.Create(service);
                _logger.LogInformation("Posting a service...");
                if (result)
                {
                    return StatusCode(201, "message: Service created!");
                }
                else
                {
                    return StatusCode(400, "message: Service couldn't be created");
                }
            }
            catch (Exception e)
            {
                _logger.LogInformation($"Caught exception: {e.Message}");
                return StatusCode(500, e.Message);
            }
        }


        [HttpPut]
        public IActionResult Put()
        {
            try
            {
                _logger.LogInformation("Put put put");
                return StatusCode(200, "Hi!");
            }
            catch (Exception e)
            {
                _logger.LogInformation($"Caught exception: {e.Message}");
                return StatusCode(500, e.Message);
            }
        }

        [HttpDelete]
        public IActionResult Delete()
        {
            try
            {
                _logger.LogInformation("Delete delete delete");
                return StatusCode(200, "Hi!");
            }
            catch (Exception e)
            {
                _logger.LogInformation($"Caught exception: {e.Message}");
                return StatusCode(500, e.Message);
            }
        }
    }
}
