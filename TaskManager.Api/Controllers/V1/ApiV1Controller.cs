using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskManager.Api.Controllers.V1
{
    [Route("api/[controller]")]
    public class ApiV1Controller<TService>: ApiController<TService>
    {
        public ApiV1Controller(TService service): base(service)
        {

        }

    }
}
