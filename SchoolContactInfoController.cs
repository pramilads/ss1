using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolHealthReporting.Data;
using SchoolHealthReporting.Data.Models;

namespace SchoolHealthReporting.Controllers
{
    [Route("api/SchoolContactInformation")]
    [ApiController]
    public class SchoolContactInfoController : ControllerBase
    {
        private readonly SchoolReportDBContext _context;

        public SchoolContactInfoController(SchoolReportDBContext context)
        {
            _context = context;
        }

        // GET: api/SchoolContactInformation
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SchoolContactInformation>>> GetSchoolContactInformations()
        {
            return await _context.SHR_Contact_Information.ToListAsync();
        }

        // GET: api/SchoolContactInformation/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SchoolContactInformation>> GetSchoolContactInformation(int id)
        {
            var schoolContactInformation = await _context.SHR_Contact_Information.FindAsync(id);

            if (schoolContactInformation == null)
            {
                return NotFound();
            }

            return schoolContactInformation;
        }

        //************ FOR NOW NOT REQUIRED PER REQUIREMENT *********************//

        ////// PUT: api/SchoolContactInformation/5
        ////[HttpPut("{id}")]
        ////public async Task<IActionResult> PutSchoolContactInformation(int id, SchoolContactInformation schoolContactInformation)
        ////{
        ////    if (id != schoolContactInformation.Id)
        ////    {
        ////        return BadRequest();
        ////    }

        ////    _context.Entry(schoolContactInformation).State = EntityState.Modified;

        ////    try
        ////    {
        ////        await _context.SaveChangesAsync();
        ////    }
        ////    catch (DbUpdateConcurrencyException)
        ////    {
        ////        if (!SchoolContactInformationExists(id))
        ////        {
        ////            return NotFound();
        ////        }
        ////        else
        ////        {
        ////            throw;
        ////        }
        ////    }

        ////    return NoContent();
        ////}

        // POST: api/SchoolContactInformation
        [HttpPost]
        public async Task<ActionResult<SchoolContactInformation>> PostSchoolContactInformation(SchoolContactInformation schoolContactInformation)
        {
            _context.SHR_Contact_Information.Add(schoolContactInformation);
            await _context.SaveChangesAsync();

            return CreatedAtAction("PostSchoolContactInformation", new { id = schoolContactInformation.Id }, schoolContactInformation);
        }

        //************ FOR NOW NOT REQUIRED PER REQUIREMENT *********************//

        ////// DELETE: api/SchoolContactInformation/5
        ////[HttpDelete("{id}")]
        ////public async Task<IActionResult> DeleteSchoolContactInformation(int id)
        ////{
        ////    var schoolContactInformation = await _context.SHR_Contact_Information.FindAsync(id);
        ////    if (schoolContactInformation == null)
        ////    {
        ////        return NotFound();
        ////    }

        ////    _context.SHR_Contact_Information.Remove(schoolContactInformation);
        ////    await _context.SaveChangesAsync();

        ////    return NoContent();
        ////}

        private bool SchoolContactInformationExists(int id)
        {
            return _context.SHR_Contact_Information.Any(e => e.Id == id);
        }
    }
}