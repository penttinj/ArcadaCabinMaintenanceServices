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
                _logger.LogInformation("Getting all services...");
                var result = _serviceUseCase.GetAll();
                if (result.Count() > 0)
                {
                    return StatusCode(200, result);
                }

                return NotFound();
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
            _logger.LogInformation("Posting a service...");
            try
            {
                int result = _serviceUseCase.Create(service);
                if (result > 0)
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


        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Service service)
        {
            try
            {
                if (_serviceUseCase.isEmptyService(service))
                {
                    return BadRequest();
                }


                _logger.LogInformation($"Updating {id}");
                IEnumerable<Service> result = _serviceUseCase.Update(id, service);
                if (result == null)
                {
                    return NotFound();
                }
                return StatusCode(200, result);

            }
            catch (Exception e)
            {
                _logger.LogInformation($"Caught exception: {e.Message}");
                return StatusCode(500, e.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _logger.LogInformation($"Deleting service with id {id}");
                int result = _serviceUseCase.Delete(id);
                if (result > 0)
                {
                    // Deleted successfully, no message will be read by the client because of statuscode 204
                    return StatusCode(204);
                }
                return NotFound();
            }
            catch (Exception e)
            {
                _logger.LogInformation($"Caught exception: {e.Message}");
                return StatusCode(500, e.Message);
            }
        }
    }
}
