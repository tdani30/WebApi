using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Domain.DTO;
using WebApi.Interfaces;

namespace WebApi.Controllers
{
    public class SmControllerBase : Controller
    {
        protected readonly ILogger _logger;
        protected readonly string _logSource;

        public SmControllerBase(ILogger logger,
            string logSource)
        {
            _logger = logger;
            _logSource = logSource;
        }

        protected void Log(string message, LogLevel level = LogLevel.Information)
        {
            _logger.Log(_logSource, message, level);
        }

        protected void Log(Exception ex, LogLevel level = LogLevel.Error)
        {
            _logger.Log(_logSource, ex, level);
        }

        protected IActionResult HandleUserException(Exception ex)
        {
            _logger.Log(nameof(WeatherForecastController), ex, LogLevel.Warning);
            return BadRequest(ServiceResponse.ErrorResponse(ex));
        }

        protected IActionResult HandleOtherException(Exception ex)
        {
            _logger.Log(nameof(WeatherForecastController), ex);
            return StatusCode(StatusCodes.Status500InternalServerError, ServiceResponse.ErrorResponse(ex));
        }

    }
}
