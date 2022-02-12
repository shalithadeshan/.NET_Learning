using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Vertex.EMS.Application.Common.Interfaces;
using Vertex.EMS.Domain.Model;

namespace Vertex.EMS.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Department>? Deparments { get; set; }
        public DbSet<Employee>? Employees { get; set;}
    }
}
 