using Book.Data;
using Book.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WepAPIReact.Controllers
{


    //public class Employe
    //{
    //    public string Title { get; set; }
    //    public string Body { get; set; }

    //    public string UserId { get; set; }

    //}
    [EnableCors]
    [Route("api/[controller]")]
    [ApiController]
    public class FormController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public FormController(ApplicationDbContext context)
        {
                _context=context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeEY>>> GetEmployees()
        {
            if (_context.EmployeesEY == null)
            {
                return NotFound();
            }
            return await _context.EmployeesEY.ToListAsync(); 
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeEY>> GetEmployees(int Id)
        {
            if (_context.EmployeesEY == null)
            {
                return NotFound();
            }
            var emp = await _context.EmployeesEY.FindAsync(Id);
            if(emp == null)
            {
                return NotFound();
            }
            return  emp;
        }

        [HttpPost]
        public async Task<ActionResult<EmployeeEY>> Employees(EmployeeEY emp)
        {
             _context.EmployeesEY.Add(emp);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetEmployees), new {Id=emp.Id},emp);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<EmployeeEY>> Employees(int id,EmployeeEY emp)
        {
            if (id != emp.Id)
            {
                return BadRequest();
            }
             _context.Entry(emp).State=EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch(Exception e)
            {
                throw;
            }
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<IEnumerable<EmployeeEY>>> Delete(int id)
        {
            if (_context.EmployeesEY == null)
            {
                return NotFound();
            }
            var emp = await _context.EmployeesEY.FindAsync(id);

             _context.EmployeesEY.Remove(emp);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
