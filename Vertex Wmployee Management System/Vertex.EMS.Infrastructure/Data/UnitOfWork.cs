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
        private IAppDbContext _appDbContext;

        private IDepartmentRepository _departmentRepository;
        private IEmployeeRepository _employeeRepository;

        public IDepartmentRepository DepartmentRepository {
            get
            {
                if(_departmentRepository == null)
                {
                    _departmentRepository = new DepartmentRepository(_appDbContext);
                }

                return _departmentRepository;
            } 
        }
        public IEmployeeRepository EmployeeRepository { 
            get
            {
                if (_employeeRepository == null)
                {
                    _employeeRepository = new EmployeeRepository(_appDbContext);
                }
                return _employeeRepository;
            }
        }

        public UnitOfWork(IAppDbContext appDbContext)
        {
            _appDbContext = appDbContext;

        }
    }
}
