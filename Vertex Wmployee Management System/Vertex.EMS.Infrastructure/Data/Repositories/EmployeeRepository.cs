using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vertex.EMS.Application.Common.Interfaces;
using Vertex.EMS.Domain.Model;

namespace Vertex.EMS.Infrastructure.Data.Repositories
{
    internal class EmployeeRepository : IEmployeeRepository
    {
        private readonly IAppDbContext _appDbContext;

        public EmployeeRepository(IAppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }


        public List<Employee> GetEmployees()
        {
            return _appDbContext.Employees.ToList();
        }
    }
}
