using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Domain.DTO;
using WebApi.Interfaces;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : SmControllerBase
    {
        IServeyMasterService _serveyMasterService;
        public ValuesController(IServeyMasterService serveyMasterService, ILogger logger) : base(logger, nameof(ValuesController))
        {
            _serveyMasterService = serveyMasterService;
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        public  IActionResult CreateServiceRequest()
        {
            try
            {
                var result =  _serveyMasterService.GetServiceRequests();
                return Ok(ServiceResponse.SuccessResponse(result));
            }
            catch (ArgumentException ex)
            {
                return HandleUserException(ex);
            }
            catch (Exception ex)
            {
                return HandleOtherException(ex);
            }
        }

    }
}
