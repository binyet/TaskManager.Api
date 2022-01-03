﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TaskManager.Entities;

namespace TaskManager.DBContext
{
    public class TaskManagerContext: DbContext
    {
        public TaskManagerContext()
        {

        }

        public TaskManagerContext(DbContextOptions<TaskManagerContext> options): base(options)
        {

        }

        public virtual DbSet<TMUser> TMUser { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
