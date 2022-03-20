using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolHealthReporting.Data;
using SchoolHealthReporting.Data.Models;

namespace SchoolHealthReporting.Controllers
{
    [Route("api/HealthReport")]
    [ApiController]
    public class SchoolHealthReportController : ControllerBase
    {
        private readonly SchoolReportDBContext _context;

        public SchoolHealthReportController(SchoolReportDBContext context)
        {
            _context = context;
        }

        // GET: api/SchoolHealthReport
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SchoolHealthReport>>> GetSchoolHealthReports()
        {
            return await _context.SHR_Health_Report.ToListAsync();
        }

        // GET: api/SchoolHealthReport/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SchoolHealthReport>> GetSchoolHealthReport(int id)
        {
            var schoolHealthReport = await _context.SHR_Health_Report.FindAsync(id);

            if (schoolHealthReport == null)
            {
                return NotFound();
            }

            return schoolHealthReport;
        }

        // PUT: api/SchoolHealthReport/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSchoolHealthReport(int id, SchoolHealthReport schoolHealthReport)
        {
            if (id != schoolHealthReport.AcademicYear)
            {
                return BadRequest();
            }

            _context.Entry(schoolHealthReport).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SchoolHealthReportExists(id))
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

        // POST: api/SchoolHealthReport
        [HttpPost]
        public async Task<ActionResult<SchoolHealthReport>> PostSchoolHealthReport(SchoolHealthReport schoolHealthReport)
        {
            _context.SHR_Health_Report.Add(schoolHealthReport);
            await _context.SaveChangesAsync();

            return CreatedAtAction("PostSchoolHealthReport", new { id = schoolHealthReport.AcademicYear }, schoolHealthReport);
        }

        // DELETE: api/SchoolHealthReport/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSchoolHealthReport(int id)
        {
            var schoolHealthReports = await _context.SHR_Health_Report.FindAsync(id);
            if (schoolHealthReports == null)
            {
                return NotFound();
            }

            _context.SHR_Health_Report.Remove(schoolHealthReports);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SchoolHealthReportExists(int id)
        {
            return _context.SHR_Health_Report.Any(e => e.AcademicYear == id);
        }
    }
}