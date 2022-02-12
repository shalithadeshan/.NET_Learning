using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Vertex.EMS.Application.Common.Interfaces;
using Vertex.EMS.Domain.Model;

namespace Vertex.EMS.Infrastructure.Data.Repositories
{
    internal class EmployeeRepository : RepositoryBase<Employee>, IEmployeeRepository
    {
      

        public EmployeeRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }

        public async Task<List<Employee>> GetEmployeesGreaterThan10Async()
        {
            var result = await _appDbContext.Employees.Where(x => x.Age > 10)
                .Include(x => x.Department)
                .ToListAsync();

            return result;
        }
    }
}
