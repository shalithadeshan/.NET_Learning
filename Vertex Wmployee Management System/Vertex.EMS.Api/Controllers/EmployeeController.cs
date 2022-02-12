using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vertex.EMS.Application.Common.Interfaces;
using Vertex.EMS.Domain.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Vertex.EMS.Api.Controllers
{
    [Route("api/employee")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {

        public IUnitOfWork _unitOfWork { get; }


        public EmployeeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


       
        // GET: api/<EmployeeController>
        [HttpGet]
        public async Task<IEnumerable<Employee>> Get()
        {
            return await _unitOfWork.EmployeeRepository.FindAllWithIncludeAsync(x => x.Department);
        }

        // GET api/<EmployeeController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<EmployeeController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<EmployeeController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<EmployeeController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
