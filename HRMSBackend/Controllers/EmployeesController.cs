using HRMSBackend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HRMSBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly HumanResourceManagementContext _context;
        WebAPIResponse response = new WebAPIResponse();
        bool IsError = false;

        public EmployeesController()
        {
            _context = new HumanResourceManagementContext();
        }


        // GET: api/<EmployeesController>
        [HttpPost]
        [Route("GetEmployeeList")]
        public async Task<IActionResult> GetEmployeeList()
        {
            try
            {

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var Data = await _context.Employees.OrderByDescending(x => x.EmployeeId).ToListAsync();
                if(Data.Count == 0) {
                    IsError = true;
                    response.Success = false;
                    response.Message = "Employees Not Found";
                    return Ok(response);
                }
                return Ok(Data);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        // GET api/<EmployeesController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetEmployee(int id)
        {
            try
            {
                if (_context.Employees == null)
                {
                    IsError = true;
                    response.Success = false;
                    response.Message = "Employees Not Found!";
                    return Ok(response);
                }
                var employee = await _context.Employees.FindAsync(id);

                if (employee == null)
                {
                    IsError = true;
                    response.Success = false;
                    response.Message = "Employee Not Exists!";
                    return Ok(response);
                }

                return Ok(employee);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private Task<bool> CheckEmployeeCodeExistAsync(int empCode) => _context.Employees.AnyAsync(x => x.EmployeeCode == empCode);

        // POST api/<EmployeesController>
        [HttpPost]
        [Route("PostAddEmployee")]
        public async Task<IActionResult> PostAddEmployee(Employee employee)
        {
            try
            {

                if(await CheckEmployeeCodeExistAsync(employee.EmployeeCode))
                {
                    IsError = true;
                    response.Success = false;
                    response.Message = "Employee Code Must Be Unique!";
                    return Ok(response);
                }

                if (employee == null) { return BadRequest(); }

                Employee emp = new Employee();
                emp.EmployeeCode = employee.EmployeeCode;
                emp.FirstName = employee.FirstName;
                emp.MiddleName = employee.MiddleName;
                emp.LastName = employee.LastName;
                emp.Designation = employee.Designation;
                emp.Department = employee.Department;
                emp.DateofBirth = employee.DateofBirth;
                emp.MobileNo = employee.MobileNo;
                emp.Gender = employee.Gender;
                emp.Address = employee.Address;
                emp.City = employee.City;
                emp.State = employee.State;
                emp.Pincode = employee.Pincode;
                emp.EmailId = employee.EmailId;
                emp.MaritalStatus = employee.MaritalStatus;
                emp.DateofJoining = employee.DateofJoining;
                emp.EmployeeImage = employee.EmployeeImage;
                emp.ResignDate = employee.ResignDate;
                emp.LeaveDate = employee.LeaveDate;
                emp.Remark = employee.Remark;
                emp.InsertDate = DateTime.Now;


                await _context.Employees.AddAsync(emp);
                await _context.SaveChangesAsync();

                response.Success = true;
                response.Message = "Employee Insert Successfully!";
                response.Data = emp;
            }
            catch(Exception ex) 
            {
                throw ex;
            }
            return Ok(response);
        }

        private bool EmployeeExists(int id)
        {
            return (_context.Employees?.Any(e => e.EmployeeId == id)).GetValueOrDefault();
        }

        // PUT api/<EmployeesController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployee(int id, Employee employee)
        {
            try
            {
                if(id != employee.EmployeeId)
                {
                    IsError = true;
                    response.Success = false;
                    response.Message = "Employee Not Found!";
                    return Ok(response);
                }
                 _context.Entry(employee).State = EntityState.Modified;

                try
                {
                    await _context.SaveChangesAsync();
                    response.Success = true;
                    response.Message = "Employee Update Successfully!";
                    response.Data = employee;
                }
                catch (DbUpdateConcurrencyException)
                {
                    if(!EmployeeExists(id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return Ok(response);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // DELETE api/<EmployeesController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteEmployee(int id)
        {
            try
            {
                if (_context.Employees == null)
                {
                    return NotFound();
                }
                var emp = await _context.Employees.FindAsync(id);
                
                if (emp == null)
                {
                    return NotFound();
                }

                _context.Employees.Remove(emp);

                await _context.SaveChangesAsync();

                return NoContent();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
