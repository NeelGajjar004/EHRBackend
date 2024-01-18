using HRMSBackend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HRMSBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeQualificationsController : ControllerBase
    {
        private readonly HumanResourceManagementContext _context;
        WebAPIResponse response = new WebAPIResponse();
        bool IsError = false;

        public EmployeeQualificationsController()
        {
            _context = new HumanResourceManagementContext();
        }
        // GET: api/<EmployeeQualificationsController>
        [HttpPost]
        [Route("GetQualificationList")]
        public async Task<IActionResult> GetQualificationList()
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var Data = await _context.EmployeeQualifications.OrderByDescending(x => x.QualificationId).ToListAsync();
                if (Data.Count == 0)
                {
                    IsError = true;
                    response.Success = false;
                    response.Message = "Employee Qualification Not Found";
                    return Ok(response);
                }
                return Ok(Data);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // GET api/<EmployeeQualificationsController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetQualification(int id)
        {
            try
            {
                if (_context.EmployeeQualifications == null)
                {
                    IsError = true;
                    response.Success = false;
                    response.Message = "Employee Qualification Not Found!";
                    return Ok(response);
                }
                var qualification = await _context.EmployeeQualifications.FindAsync(id);

                if (qualification == null)
                {
                    IsError = true;
                    response.Success = false;
                    response.Message = "Employee Qualification Not Exists!";
                    return Ok(response);
                }

                return Ok(qualification);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // POST api/<EmployeeQualificationsController>
        [HttpPost]
        public async Task<IActionResult> PostAddQualification(EmployeeQualification qualification)
        {
            try
            {

                if (qualification == null) { return BadRequest(); }

                EmployeeQualification quali= new EmployeeQualification();
                quali.EmployeeId = qualification.EmployeeId;
                quali.QualificationName = qualification.QualificationName;
                quali.PassingYear = qualification.PassingYear;
                quali.Cgpa = qualification.Cgpa;
                quali.College = qualification.College;
                quali.InsertDate = DateTime.Now;


                await _context.EmployeeQualifications.AddAsync(quali);
                await _context.SaveChangesAsync();

                response.Success = true;
                response.Message = "Employee Qualification Insert Successfully!";
                response.Data = quali;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Ok(response);
        }


        private bool EmployeeQualificationExists(int id)
        {
            return (_context.EmployeeQualifications?.Any(e => e.QualificationId== id)).GetValueOrDefault();
        }

        // PUT api/<EmployeeQualificationsController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutQualification(int id, EmployeeQualification qualification)
        {
            try
            {
                if (id != qualification.QualificationId)
                {
                    IsError = true;
                    response.Success = false;
                    response.Message = "Employee Qualification Not Found!";
                    return Ok(response);
                }
                _context.Entry(qualification).State = EntityState.Modified;

                try
                {
                    await _context.SaveChangesAsync();
                    response.Success = true;
                    response.Message = "Employee Qualification Update Successfully!";
                    response.Data = qualification;
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeQualificationExists(id))
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

        // DELETE api/<EmployeeQualificationsController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteQualification(int id)
        {
            try
            {
                if (_context.EmployeeQualifications == null)
                {
                    return NotFound();
                }
                var quali = await _context.EmployeeQualifications.FindAsync(id);

                if (quali == null)
                {
                    return NotFound();
                }

                _context.EmployeeQualifications.Remove(quali);
                
                response.Success = true;
                response.Message = "Employee Qualification Delete Successfully!";

                await _context.SaveChangesAsync();

                return Ok(response);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
