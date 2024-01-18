using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HRMSBackend.Models;

namespace HRMSBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private readonly HumanResourceManagementContext _context;
        WebAPIResponse response = new WebAPIResponse();

        public DepartmentsController(HumanResourceManagementContext context)
        {
            _context = context;
        }

        // GET: api/Departments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Department>>> GetDepartments()
        {

            try
            {
                if (_context.Departments == null)
                {
                    return NotFound();
                }
                return await _context.Departments.ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            
        }

        // GET: api/Departments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Department>> GetDepartment(int id)
        {
            try
            {
                if (_context.Departments == null)
                {
                    return NotFound();
                }
                var department = await _context.Departments.FindAsync(id);

                if (department == null)
                {
                    return NotFound();
                }

                return department;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private Task<bool> CheckDepartmentNameExistAsync(string deptName) => _context.Departments.AnyAsync(x => x.DepartmentName == deptName);
        private Task<bool> CheckDepartmentCodeExistAsync(int deptCode) => _context.Departments.AnyAsync(x => x.DepartmentCode == deptCode);

        // POST: api/Departments
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Department>> PostDepartment(Department department)
        {

            try
            {
                bool IsError = false;
                if (department == null)
                {
                    return BadRequest();
                }

                if (department.DepartmentId == 0)
                {
                    if (await CheckDepartmentNameExistAsync(department.DepartmentName) && await CheckDepartmentCodeExistAsync(department.DepartmentCode))
                    {
                        IsError = true;
                        response.Success = false;
                        response.Message = "Department Already Exist!";
                        return Ok(response);
                    }

                    //Check Department Name
                    if (await CheckDepartmentNameExistAsync(department.DepartmentName))
                    {
                        IsError = true;
                        response.Success = false;
                        response.Message = "Department Name Already Exist!";
                        return Ok(response);

                    }

                    //check Department Code 
                    if (await CheckDepartmentCodeExistAsync(department.DepartmentCode))
                    {
                        IsError = true;
                        response.Success = false;
                        response.Message = "Department Code Must be Unique!";
                        return Ok(response);
                    }



                    if (IsError == false)
                    {

                        Department dept = new Department();
                        dept.DepartmentName = department.DepartmentName;
                        dept.DepartmentCode = department.DepartmentCode;
                        dept.InsertDate = DateTime.Now;

                        await _context.Departments.AddAsync(dept);
                        await _context.SaveChangesAsync();

                        response.Success = true;
                        response.Message = "Department Added Successfully";
                    }
                }
                else
                {
                    if (await CheckDepartmentNameExistAsync(department.DepartmentName) || await CheckDepartmentCodeExistAsync(department.DepartmentCode))
                    {
                        IsError = true;
                        response.Success = false;
                        response.Message = "Department or Department Code Already Exist!";
                        return Ok(response);
                    }

                    if (IsError == false)
                    {

                        var Data = _context.Departments.Where(x => x.DepartmentId == department.DepartmentId).AsEnumerable().FirstOrDefault();
                        Data.DepartmentName = department.DepartmentName;
                        Data.DepartmentCode = department.DepartmentCode;
                        _context.Entry(Data).State = EntityState.Modified;
                        _context.SaveChangesAsync();

                        response.Success = true;
                        response.Message = "Department Updated Successfully";
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Ok(response);
        }


        // PUT: api/Departments/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDepartment(int id, Department department)
        {
            try
            {
                if (id != department.DepartmentId)
                {
                    return BadRequest();
                }

                _context.Entry(department).State = EntityState.Modified;

                //Check Department Name
                if (await CheckDepartmentNameExistAsync(department.DepartmentName))
                    return BadRequest(new { Message = " Department Already Exist! " });

                //check Department Code 
                if (await CheckDepartmentCodeExistAsync(department.DepartmentCode))
                    return BadRequest(new { Message = " Department Code Must be Unique! " });

                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DepartmentExists(id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                return NoContent();
            }
            catch(Exception ex) 
            {
                throw ex;
            }
            
        }


        // DELETE: api/Departments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDepartment(int id)
        {
            try
            {
                if (_context.Departments == null)
                {
                    return NotFound();
                }
                var department = await _context.Departments.FindAsync(id);
                if (department == null)
                {
                    return NotFound();
                }

                _context.Departments.Remove(department);
                await _context.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        private bool DepartmentExists(int id)
        {
            return (_context.Departments?.Any(e => e.DepartmentId == id)).GetValueOrDefault();
        }

        [HttpPost]
        [Route("GetDepartmentList")]
        public async Task<IActionResult> GetDepartmentList()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var Data = await _context.Departments.OrderByDescending(x => x.DepartmentId).ToListAsync();
            return Ok(Data);
        }
    }
}
