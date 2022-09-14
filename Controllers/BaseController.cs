using Jobportel.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jobportel.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        protected OkObjectResult OkResponse( string message, dynamic data)
        {
            return Ok( new Response { StatusCode = StatusCodes.Status200OK, Message = message, Data = data });
        }

        protected BadRequestObjectResult BadResponse(string message,Object data)
        {
            return BadRequest(new Response { StatusCode = StatusCodes.Status400BadRequest, Message = message, Data = data });
        }
        protected NotFoundObjectResult NotFoundResponse(string message,Object data)
        {
            return NotFound(new Response { StatusCode = StatusCodes.Status404NotFound, Message = message, Data = data });
        }
    }
}
