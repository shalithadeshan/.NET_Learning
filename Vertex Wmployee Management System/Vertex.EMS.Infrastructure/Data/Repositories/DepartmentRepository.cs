using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vertex.EMS.Application.Common.Interfaces;
using Vertex.EMS.Domain.Model;

namespace Vertex.EMS.Infrastructure.Data.Repositories
{
    public class DepartmentRepository : RepositoryBase<Department>, IDepartmentRepository
    {

        public DepartmentRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }

    }
}
