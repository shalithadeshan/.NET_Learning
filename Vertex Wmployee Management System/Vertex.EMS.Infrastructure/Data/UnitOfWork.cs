using Vertex.EMS.Application.Common.Interfaces;

namespace Vertex.EMS.Infrastructure.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private AppDbContext _appDbContext;

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

        public UnitOfWork(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;

        }
    }
}
