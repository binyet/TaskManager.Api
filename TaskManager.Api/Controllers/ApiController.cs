using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskManager.Api.Controllers
{
    [ApiController]
    [Authorize]
    [ProducesErrorResponseType(typeof(string))]
    public class ApiController<TService>: ControllerBase
    {
        protected TService Service { get; }
        public ApiController(TService service)
        {
            this.Service = service;
        }
    }
}
