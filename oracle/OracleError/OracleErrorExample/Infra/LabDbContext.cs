using Microsoft.EntityFrameworkCore;
using OracleErrorExample.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OracleErrorExample.Infra
{
    public class LabDbContext : DbContext
    {
        public LabDbContext(DbContextOptions<LabDbContext> options) : base(options) { }
        public virtual DbSet<ProjectProperties> ProjectProperties { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProjectPropertiesEntityConfigurations());
        }
    }
}
