﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WorkSpace.Models;

    public class WorkSpaceContext : IdentityDbContext<User>
{
        public WorkSpaceContext (DbContextOptions<WorkSpaceContext> options)
            : base(options)
        {
        //Database.EnsureCreated();
        }

       // public DbSet<WorkSpace.Models.User> Users { get; set; }
        public DbSet<WorkSpace.Models.WorkSpace> WorkSpaces { get; set; }
        public DbSet<Page> Pages { get; set; }
        public DbSet<Block> Blocks { get; set; }

        public DbSet<Element> Elements { get; set; }
        public DbSet<Template> Templates { get; set; }
}
