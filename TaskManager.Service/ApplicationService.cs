using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using TaskManager.DBContext;

namespace TaskManager.Service
{
    public abstract class ApplicationService
    {

    }
    public abstract class ApplicationService<TCategoryName> : ApplicationService where TCategoryName : ApplicationService
    {
        protected ILogger<TCategoryName> Logger { get; }
        protected TaskManagerContext Context { get; }
        public ApplicationService(ILogger<TCategoryName> logger, TaskManagerContext contxt)
        {
            this.Logger = logger;
            this.Context = contxt;
        }
    }
}
