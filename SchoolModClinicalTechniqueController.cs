using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolHealthReporting.Data;
using SchoolHealthReporting.Data.Models;

namespace SchoolHealthReporting.Controllers
{
    [Route("api/SchoolModClinicalTechnique")]
    [ApiController]
    public class SchoolModClinicalTechniqueController : ControllerBase
    {
        private readonly SchoolReportDBContext _context;

        public SchoolModClinicalTechniqueController(SchoolReportDBContext context)
        {
            _context = context;
        }

        // GET: api/SchoolModClinicalTechnique
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SchoolModClinicalTechnique>>> GetSchoolModClinicalTechniqueDetails()
        {
            return await _context.SHR_Mod_Clinical_Technique.ToListAsync();
        }

        // GET: api/SchoolModClinicalTechnique/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SchoolModClinicalTechnique>> GetSchoolHealthReport(int id)
        {
            var schoolModClinicalTechnique = await _context.SHR_Mod_Clinical_Technique.FindAsync(id);

            if (schoolModClinicalTechnique == null)
            {
                return NotFound();
            }

            return schoolModClinicalTechnique;
        }

        //************ FOR NOW NOT REQUIRED PER REQUIREMENT *********************//


        ////// PUT: api/SchoolModClinicalTechnique/5
        ////[HttpPut("{id}")]
        ////public async Task<IActionResult> PutSchoolModClinicalTechnique(int id, SchoolModClinicalTechnique schoolModClinicalTechnique)
        ////{
        ////    if (id != schoolModClinicalTechnique.Id)
        ////    {
        ////        return BadRequest();
        ////    }

        ////    _context.Entry(schoolModClinicalTechnique).State = EntityState.Modified;

        ////    try
        ////    {
        ////        await _context.SaveChangesAsync();
        ////    }
        ////    catch (DbUpdateConcurrencyException)
        ////    {
        ////        if (!SchoolModClinicalTechniqueExists(id))
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

        // POST: api/SchoolModClinicalTechnique
        [HttpPost]
        public async Task<ActionResult<SchoolHealthReport>> PostSchoolModClinicalTechniqueDetails(SchoolModClinicalTechnique schoolModClinicalTechnique)
        {
            _context.SHR_Mod_Clinical_Technique.Add(schoolModClinicalTechnique);
            await _context.SaveChangesAsync();

            return CreatedAtAction("PostSchoolModClinicalTechniqueDetails", new { id = schoolModClinicalTechnique.Id }, schoolModClinicalTechnique);
        }


        //************ FOR NOW NOT REQUIRED PER REQUIREMENT *********************//


        ////// DELETE: api/SchoolModClinicalTechnique/5
        ////[HttpDelete("{id}")]
        ////public async Task<IActionResult> DeleteSchoolModClinicalTechnique(int id)
        ////{
        ////    var schoolModClinicalTechnique = await _context.SHR_Mod_Clinical_Technique.FindAsync(id);
        ////    if (schoolModClinicalTechnique == null)
        ////    {
        ////        return NotFound();
        ////    }

        ////    _context.SHR_Mod_Clinical_Technique.Remove(schoolModClinicalTechnique);
        ////    await _context.SaveChangesAsync();

        ////    return NoContent();
        ////}


        private bool SchoolModClinicalTechniqueExists(int id)
        {
            return _context.SHR_Mod_Clinical_Technique.Any(e => e.Id == id);
        }
    }
}