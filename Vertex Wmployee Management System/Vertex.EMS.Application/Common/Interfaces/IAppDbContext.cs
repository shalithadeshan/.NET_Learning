using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Vertex.EMS.Domain.Model;

namespace Vertex.EMS.Application.Common.Interfaces
{
    public interface IAppDbContext
    {
        DbSet<Department>? Deparments { get; set; }
        DbSet<Employee>? Employees { get; set; }
    }
}
