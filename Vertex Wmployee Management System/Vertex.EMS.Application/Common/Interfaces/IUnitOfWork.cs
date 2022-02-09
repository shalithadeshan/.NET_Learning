using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vertex.EMS.Application.Common.Interfaces
{
    public interface IUnitOfWork
    {
        IDepartmentRepository Department { get; }
        IEmployeeRepository Employee { get; }
    }
}
