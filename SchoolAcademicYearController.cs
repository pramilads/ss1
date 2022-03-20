using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolHealthReporting.Data;
using SchoolHealthReporting.Data.Models;
using SchoolHealthReporting.Services;
using System.Text;

namespace SchoolHealthReporting.Controllers
{
    [Route("api/AcademicYear")]
    [ApiController]
    public class SchoolAcademicYearController : ControllerBase
    {
        private readonly SchoolReportDBContext _context;
        private readonly ISchoolReportService _schoolReportService;


        public SchoolAcademicYearController(SchoolReportDBContext context, ISchoolReportService schoolReportService)
        {
            _context = context;
            _schoolReportService = schoolReportService;
        }

        //[HttpGet]
        //public IActionResult DownloadExcel()
        //{
        //    List<SchoolAcademicYear> result = new List<SchoolAcademicYear>();
        //    result.Add(new SchoolAcademicYear { AcademicYear = 2019, IsCurrentYear = "N" });
        //    return new ExcelResult<SchoolAcademicYear>(result, "Sheet1", "SchoolAcademicYearReport");
        //}

        // GET: api/AcademicYearDetail
        //Get: api/Export/GetDynamicExcel
        //[HttpGet]
        //[Route("GetDynamicExcel")]
        //public IActionResult GetDynamicExcel()
        //{
        //    //try
        //    //{
        //        return Ok(BuildeExcel());
        //    //}
        //    //catch (Exception ex)
        //    //{
        //    //    throw (ex);
        //    //}
        //}

        // Create an excel on the fly and return as Base64 format
        private string BuildeExcel()
        {
            StringBuilder table = new StringBuilder();
            table.Append("<table border=`" + "1px" + "`b>");
            table.Append("<tr>");
            table.Append("<td><b><font face=Arial Narrow size=3>AcademicYear</font></b></td>");
            table.Append("<td><b><font face=Arial Narrow size=3>IsCurrentYear</font></b></td>");
            table.Append("</tr>");

            foreach (var item in GetEmployeeAll())
            {
                table.Append("<tr>");
                table.Append("<td><font face=Arial Narrow size=" + "14px" + ">" + item.AcademicYear.ToString() + "</font></td>");
                table.Append("<td><font face=Arial Narrow size=" + "14px" + ">" + item.IsCurrentYear.ToString() + "</font></td>");
               
                table.Append("</tr>");
            }

            table.Append("</table>");
            byte[] temp = System.Text.Encoding.UTF8.GetBytes(table.ToString());
            return System.Convert.ToBase64String(temp);

        }


        // Return list of employee
        private List<SchoolAcademicYear> GetEmployeeAll()
        {
            List<SchoolAcademicYear> employees = new List<SchoolAcademicYear>
            {
                new SchoolAcademicYear(){AcademicYear = 1, IsCurrentYear = "N"},
                new SchoolAcademicYear(){AcademicYear = 1, IsCurrentYear = "N"},
                new SchoolAcademicYear(){AcademicYear = 1, IsCurrentYear = "N"},
                new SchoolAcademicYear(){AcademicYear = 1, IsCurrentYear = "N"}
            };

            return employees;
        }


        // GET: api/AcademicYearDetail
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SchoolAcademicYear>>> GetAcademicYearDetails()
        {
            return await _context.SHR_Academic_Year.ToListAsync();
        }

        // GET: api/AcademicYearDetail/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SchoolAcademicYear>> GetAcademicYearDetail(int id)
        {
            var academicYearDetail = await _context.SHR_Academic_Year.FindAsync(id);

            if (academicYearDetail == null)
            {
                return NotFound();
            }

            return academicYearDetail;
        }

        // PUT: api/AcademicYearDetail/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAcademicYearDetail(int id, SchoolAcademicYear academicYearDetail)
        {
            if (id != academicYearDetail.AcademicYear)
            {
                return BadRequest();
            }

            _context.Entry(academicYearDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SchoolAcademicYearExists(id))
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

        // POST: api/AcademicYearDetail
        [HttpPost]
        public async Task<ActionResult<SchoolAcademicYear>> PostAcademicYearDetailDetail(SchoolAcademicYear schoolAcademicYear)
        {
            _context.SHR_Academic_Year.Add(schoolAcademicYear);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAcademicYearDetail", new { id = schoolAcademicYear.AcademicYear }, schoolAcademicYear);
        }

        // DELETE: api/AcademicYearDetail/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAcademicYearDetail(int id)
        {
            var academicYearDetail = await _context.SHR_Academic_Year.FindAsync(id);
            if (academicYearDetail == null)
            {
                return NotFound();
            }

            _context.SHR_Academic_Year.Remove(academicYearDetail);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SchoolAcademicYearExists(int id)
        {
            return _context.SHR_Academic_Year.Any(e => e.AcademicYear == id);
        }
    }
}