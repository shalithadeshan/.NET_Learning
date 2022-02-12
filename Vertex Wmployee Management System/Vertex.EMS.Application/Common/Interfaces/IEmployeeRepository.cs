using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vertex.EMS.Domain.Model;

namespace Vertex.EMS.Application.Common.Interfaces
{
    public interface IEmployeeRepository : IRepositoryBase<Employee>
    {
        Task<List<Employee>> GetEmployeesGreaterThan10Async();
    }
}
