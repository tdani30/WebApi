using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
//using Microsoft.Extensions.Logging;
using WebApi.Domain.DTO;
using WebApi.Interfaces;

namespace WebApi.Controllers
{
    [ApiController]
    //[Route("api/[controller]")]
    [Produces("application/json")]
    public class WeatherForecastController : SmControllerBase
    {
        IServeyMasterService _serveyMasterService;
        public WeatherForecastController(IServeyMasterService serveyMasterService, ILogger logger) : base(logger, nameof(ValuesController))
        {
            //_logger = logger;
            _serveyMasterService = serveyMasterService;
        }

        
        [HttpGet]
        //[ActionName("loo")]
        [Route("api/WeatherForecast/GetServey")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        public async Task<JsonResult> Get()
        {
            try
            {
                var result = await _serveyMasterService.GetServiceRequests();
                return new JsonResult(result);
            }
            catch (ArgumentException ex)
            {

                return new JsonResult(ex);
            }
            catch (Exception ex)
            {
                return new JsonResult(ex);
            }
        }

        [Route("api/WeatherForecast/CreateServey")]
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        public async Task<JsonResult> CreateServey(ServeyMasterDTO dto)
        {
            try
            {
                //ServeyMasterDTO dto = new ServeyMasterDTO();
                var result = await _serveyMasterService.CreateServey(dto);
                return new JsonResult(result);
            }
            catch (ArgumentException ex)
            {
                return new JsonResult(ex);
            }
            catch (Exception ex)
            {
                return new JsonResult(ex);
            }
        }

        [Route("api/WeatherForecast/UpdateAnswers")]
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        public async Task<JsonResult> UpdateAnswers(ChoicesDTO dto)
        {
            try
            {
                //ServeyMasterDTO dto = new ServeyMasterDTO();
                var result = await _serveyMasterService.UpdateAnswers(dto);
                return new JsonResult(result);
            }
            catch (ArgumentException ex)
            {
                return new JsonResult(ex);
            }
            catch (Exception ex)
            {
                return new JsonResult(ex);
            }
        }


        [Route("api/WeatherForecast/GetAllQuestions")]
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        public async Task<JsonResult> GetAllQuestions()
        {
            try
            {
                var result = await _serveyMasterService.GetAllQuestions();
                return new JsonResult(result);
            }
            catch (ArgumentException ex)
            {
                return new JsonResult(ex);
            }
            catch (Exception ex)
            {
                return new JsonResult(ex);
            }
        }
        //

        //
        [Route("api/WeatherForecast/GetAllQuestionWithOption")]
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        public async Task<JsonResult> GetAllQuestionWithOption(string ID)
        {
            try
            {
                var result = await _serveyMasterService.GetAllQuestionWithOption(ID);
                return new JsonResult(result);
            }
            catch (ArgumentException ex)
            {
                return new JsonResult(ex);
            }
            catch (Exception ex)
            {
                return new JsonResult(ex);
            }
        }
    }
}
