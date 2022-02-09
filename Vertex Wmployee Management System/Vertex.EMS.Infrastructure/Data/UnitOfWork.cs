using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vertex.EMS.Application.Common.Interfaces;

namespace Vertex.EMS.Infrastructure.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private AppDbContext _appDbContext;
        private IDepartmentRepository _departmentRepository;
        private IEmployeeRepository _employeeRepository;

        public IDepartmentRepository Department {
            get
            {
                if(_departmentRepository == null)
                {
                    _departmentRepository = new DepartmentRepository();
                }

                return _departmentRepository;
            } 
        }
        public IEmployeeRepository Employee { 
            get
            {
                if (_employeeRepository == null)
                {
                    _employeeRepository = new EmployeeRepository();
                }
                return _employeeRepository;
            }
        }
    }
}
