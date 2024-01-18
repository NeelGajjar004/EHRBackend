using HRMSBackend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HRMSBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DesignationsController : ControllerBase
    {
        private readonly HumanResourceManagementContext _context;
        WebAPIResponse response = new WebAPIResponse();

        public DesignationsController()
        {
            _context = new HumanResourceManagementContext();
        }


        // GET: api/<DesignationsController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Designation>>> GetDesignationList()
        {
            try
            {
                if (_context.Designations == null)
                {
                    return NotFound();
                }
                return await _context.Designations.ToListAsync();
            }catch(Exception ex)
            {
                throw ex;
            }
        }

        // GET api/<DesignationsController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Designation>> GetDesignation(int id)
        {
            try
            {
                if (_context.Designations == null)
                {
                    return NotFound();
                }
                var designation = await _context.Designations.FindAsync(id);

                if (designation == null)
                {
                    return NotFound();
                }

                return designation;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private Task<bool> CheckDesignationNameExistAsync(string designName) => _context.Designations.AnyAsync(x => x.DesignationName == designName);
        private Task<bool> CheckDesignationCodeExistAsync(int designCode) => _context.Designations.AnyAsync(x => x.DesignationCode == designCode);

        // POST api/<DesignationsController>
        [HttpPost]
        public async Task<ActionResult<Designation>> PostAddDesignation(Designation designation)
        {
                try
                {
                    if (designation == null)
                    {
                        return BadRequest();
                    }
                    bool IsError = false;
                    if (await CheckDesignationNameExistAsync(designation.DesignationName) && await CheckDesignationCodeExistAsync(designation.DesignationCode))
                    {
                        IsError = true;
                        response.Success = false;
                        response.Message = "Designation Already Exist!";
                        return Ok(response);
                    }   

                    //Check Designation Name
                    if (await CheckDesignationNameExistAsync(designation.DesignationName))
                        {
                            IsError = true;
                            response.Success = false;
                            response.Message = "Designation Name Already Exist!";
                            return Ok(response);

                    }

                    //check Designation Code 
                    if (await CheckDesignationCodeExistAsync(designation.DesignationCode))
                        {
                            IsError = true;
                            response.Success = false;
                            response.Message = "Designation Code Must be Unique!";
                            return Ok(response);
                    }
                    if (IsError == false)
                    {
                        if (designation.DesignationId == 0)
                        {


                            Designation design = new Designation();
                            design.DesignationName = designation.DesignationName;
                            design.DesignationCode = designation.DesignationCode;
                            design.InsertDate = DateTime.Now;
                            //design.DeleteDate = DateTime.Now;
                            //design.UpdateDate = DateTime.Now;


                            await _context.Designations.AddAsync(design);
                            await _context.SaveChangesAsync();

                            response.Success = true;
                            response.Message = "Designation Added Successfully";
                        }
                        else
                        {

                            var Data = _context.Designations.Where(x => x.DesignationId == designation.DesignationId).AsEnumerable().FirstOrDefault();
                            Data.DesignationName = designation.DesignationName;
                            Data.DesignationCode = designation.DesignationCode;
                            _context.Entry(Data).State = EntityState.Modified;
                            _context.SaveChangesAsync();

                            response.Success = true;
                            response.Message = "Designation Updated Successfully";
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            return Ok(response);
        }

        private bool DesignationExists(int id)
        {
            return (_context.Departments?.Any(e => e.DepartmentId == id)).GetValueOrDefault();
        }

        // PUT api/<DesignationsController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDesignation(int id, Designation designation)
        {
            try
            {

                if (id != designation.DesignationId)
                {
                    return BadRequest();
                }

                _context.Entry(designation).State = EntityState.Modified;

                //Check Designation Name
                if (await CheckDesignationNameExistAsync(designation.DesignationName))
                    return BadRequest(new { Message = " Designation Already Exist! " });

                //check Designation Code 
                if (await CheckDesignationCodeExistAsync(designation.DesignationCode))
                    return BadRequest(new { Message = " Designation Code Must be Unique! " });

                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DesignationExists(id))
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
            catch (Exception ex)
            {
                throw ex;
            }
        }
        // DELETE api/<DesignationsController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteDesignation(int id)
        {
            try
            {
                if (_context.Designations == null)
                {
                    return NotFound();
                }
                var designation = await _context.Designations.FindAsync(id);
                if (designation == null)
                {
                    return NotFound();
                }


                _context.Designations.Remove(designation);
                await _context.SaveChangesAsync();

                return NoContent();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        [Route("GetDesignationsList")]
        public async Task<IActionResult> GetDesignationsList()
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var Data = await _context.Designations.OrderByDescending(x=> x.DesignationId).ToListAsync();
            return Ok(Data);
        }
    }
}
