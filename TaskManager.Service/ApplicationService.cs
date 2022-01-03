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
    public abstract class ApplicationService<TCategoryName, TRepository> : ApplicationService where TCategoryName : ApplicationService
    {
        protected ILogger<TCategoryName> Logger { get; }
        protected TRepository Repository { get; }
        public ApplicationService(ILogger<TCategoryName> logger, TRepository repository)
        {
            this.Logger = logger;
            this.Repository = repository;
        }
    }
}
