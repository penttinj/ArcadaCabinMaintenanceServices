using ArcadaCMSApi.UseCases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ArcadaCMSApi.Interfaces;

namespace ArcadaCMSApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ServicesController : ControllerBase
    {
        private readonly ILogger<ServicesController> _logger;
        private readonly IserviceUseCase _serviceUseCase;
        public ServicesController(ILogger<ServicesController> logger, IserviceUseCase serviceUseCase)
        {
            _logger = logger;
            _serviceUseCase = serviceUseCase;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var response = _serviceUseCase.GetAll();
                _logger.LogInformation("Get get get");
                return StatusCode(200, response);
            }
            catch(Exception e)
            {
                _logger.LogInformation($"Caught exception: {e.Message}");
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost]
        public IActionResult Post()
        {
            try
            {
                _logger.LogInformation("Post post post");
                return StatusCode(200, "Hi!");
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
