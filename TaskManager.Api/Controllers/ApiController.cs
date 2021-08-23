using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManager.Exceptions;

namespace TaskManager.Api.Controllers
{
    [ApiController]
    [Authorize]
    [ProducesErrorResponseType(typeof(HttpResponseExceptionMessage))]
    public class ApiController<TService>: ControllerBase
    {
        protected TService Service { get; }
        public ApiController(TService service)
        {
            this.Service = service;
        }
    }
}
