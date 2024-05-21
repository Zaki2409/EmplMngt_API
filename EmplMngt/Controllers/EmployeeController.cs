using EmplMngt.Data;
using EmplMngt.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmplMngt.Controllers
{

    [ApiController]
    [Route("/api/[controller]")]
    public class EmployeeController : Controller
    {

        private readonly EmplMngtDbContext _EmplMngtDbContext;

        public EmployeeController(EmplMngtDbContext emplMngtDbContext)
        {
            _EmplMngtDbContext = emplMngtDbContext;
        }
        //GET ALL EMPLOYEES
        [HttpGet]
        public async Task<IActionResult> GetAllEmployees()
        {
            var all_employees = await _EmplMngtDbContext.Employees.ToListAsync();
            return Ok(all_employees);
        }

        //POST EMPLAYEE 
        [HttpPost]

        public async Task<IActionResult> AddEmployee([FromBody] Employee employeeRequest)
        {
            employeeRequest.Id = new Guid();
            await _EmplMngtDbContext.Employees.AddAsync(employeeRequest);
            await _EmplMngtDbContext.SaveChangesAsync();
            return Ok(employeeRequest);

        }

        //GET EMPLYEE BY ID 
        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetEmployee([FromRoute] Guid id)
        {

            var empdetid = await _EmplMngtDbContext.Employees.FirstOrDefaultAsync(x => x.Id == id);
            if (empdetid == null)
            {
                return NotFound();
            }
            return Ok(empdetid);

        }

        //UPDATE THE EMPLYEE
        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> UpdateEmployee([FromRoute] Guid id, Employee empludatereq)
        {

            var emp = await _EmplMngtDbContext.Employees.FindAsync(id);
            if (emp == null)
            {
                return NotFound(id);
            }

            emp.Name = empludatereq.Name;
            emp.Email = empludatereq.Email;
            emp.Gender = empludatereq.Gender;
            emp.Phone = empludatereq.Phone;
            emp.Salary = empludatereq.Salary;
            emp.Department = empludatereq.Department;

            await _EmplMngtDbContext.SaveChangesAsync();
            return Ok(emp);
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> DeleteEmployee([FromRoute] Guid id)
        {

            var emp = await _EmplMngtDbContext.Employees.FindAsync(id);
            if (emp == null)
            {
                return NotFound(id);
            }
            _EmplMngtDbContext.Employees.Remove(emp);
            await _EmplMngtDbContext.SaveChangesAsync();
            return Ok(emp);
        }

    }
}
