using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WorkSpace.Models;

    public class WorkSpaceContext : DbContext
    {
        public WorkSpaceContext (DbContextOptions<WorkSpaceContext> options)
            : base(options)
        {
        }

        public DbSet<WorkSpace.Models.Block> Block { get; set; }
    }
