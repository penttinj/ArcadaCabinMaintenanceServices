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
    public class ReservationsController : ControllerBase
    {
        private readonly ILogger<ServicesController> _logger;
        private readonly IReservationsUseCase _ReservationsUseCase;
        public ReservationsController(ILogger<ServicesController> logger, IReservationsUseCase reservationsUseCase)
        {
            _logger = logger;
            _ReservationsUseCase = reservationsUseCase;
        }


        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                _logger.LogInformation("Getting all reservations...");
                var result = _ReservationsUseCase.GetAll();
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
        public IActionResult Post([FromBody] Reservation reservation)
        {
            _logger.LogInformation("Posting a reservation...");
            try
            {
                int result = _ReservationsUseCase.Create(reservation);
                if (result > 0)
                {
                    return StatusCode(201, reservation);
                }
                else
                {
                    return StatusCode(400, "message: Reservation couldn't be created");
                }
            }
            catch (Exception e)
            {
                _logger.LogInformation($"Caught exception: {e.Message}");
                return StatusCode(500, e.Message);
            }
        }


        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Reservation reservation)
        {
            try
            {
                if (_ReservationsUseCase.isEmptyReservation(reservation))
                {
                    return BadRequest();
                }


                _logger.LogInformation($"Updating {id}");
                IEnumerable<Reservation> result = _ReservationsUseCase.Update(id, reservation);
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
                _logger.LogInformation($"Deleting reservation with id {id}");
                int result = _ReservationsUseCase.Delete(id);
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
