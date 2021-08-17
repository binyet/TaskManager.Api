using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace TaskManager.Service
{
    public abstract class ApplicationService
    {

    }
    public abstract class ApplicationService<TCategoryName> : ApplicationService where TCategoryName : ApplicationService
    {
        protected ILogger<TCategoryName> Logger { get; }
        public ApplicationService(ILogger<TCategoryName> logger)
        {
            this.Logger = logger;
        }
    }
}
