using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolHealthReporting.Data;
using SchoolHealthReporting.Data.Models;
using SchoolHealthReporting.Services;
using System.Data;
using System.Text;

namespace SchoolHealthReporting.Controllers
{
    [ApiController]
    //[Route("api/ReportViewer")]
    [Route("[controller]")]

    public class ReportViewerController : ControllerBase
    {
        private readonly ISchoolReportService _schoolReportService;
        private readonly SchoolReportDBContext _context;

        public ReportViewerController(ISchoolReportService schoolReportService, SchoolReportDBContext schoolReportDBContext)
        {
            _context = schoolReportDBContext;
            _schoolReportService = schoolReportService;
        }

        //[HttpGet]
        //[Route("Export")]
        //public async Task<IActionResult> Export()
        //{
        //    var fileResult = await _schoolReportService.GetSchoolReportExport().ConfigureAwait(false);

        //    //if (fileResult == null)
        //    //{
        //    //    return NoContent();
        //    //}

        //    //var fileStream = new FileStream(fileResult.FilePath, FileMode.Open);

        //    // Client-side handles file naming
        //    return File(fileStream, MediaTypeNames.Text.Plain);
        //}


        //    [HttpGet]
        //    public async Task<ActionResult<IEnumerable<SchoolHealthReport>>> GetSchoolData()
        //    {
        //        return await _schoolReportDBContext.SchoolHealthReports.ToListAsync();
        //    }


        //[HttpGet]
        //[Route("ExportCSV")]
        //public async Task<FileResult> ExportCSV(
        //   //[FromRoute] int submissionWindowDefinitionId,
        //   //[FromRoute] string educationOrganizationId, [FromRoute] string resourceName, [FromRoute] string StudentUniqueId
        //   )
        //{
        //    //if (StudentUniqueId.Equals("undefined"))
        //    //{
        //    //    StudentUniqueId = "Null";
        //    //}
        //    //if (resourceName.Equals("undefined"))
        //    //{
        //    //    resourceName = "Null";
        //    //}


        //    var dt = await _schoolReportService.GetSchoolReportExport();
        //    //(educationOrganizationId, submissionWindowDefinitionId, resourceName, StudentUniqueId);

        //    Stream stream = DataTableToCsv(dt);
        //    return File(stream, "application/octet-stream");
        //}

        [EnableCors("_myAllowSpecificOrigins")]
        [HttpGet]
        [Route("SchoolsSubmittedReport")]
        public async Task<FileResult> SchoolsSubmittedReport()//string year, string reportFormat)
        {
            var dt = await _schoolReportService.GetSchoolReportExport();
            //(educationOrganizationId, submissionWindowDefinitionId, resourceName, StudentUniqueId);

            Stream stream = DataTableToCsv(dt);
            return File(stream, "application/octet-stream");
        }

        [HttpGet]
        [Route("NotHealthCompliantReport")]
        public async Task<FileResult> NotHealthCompliantReport(string year, string reportFormat)
        {
            var dt = await _schoolReportService.GetSchoolReportExport();
            //(educationOrganizationId, submissionWindowDefinitionId, resourceName, StudentUniqueId);

            Stream stream = DataTableToCsv(dt);
            return File(stream, "application/octet-stream");
        }

        [HttpGet]
        [Route("IncompleteHealthInformationReport")]
        public async Task<FileResult> IncompleteHealthInformationReport(string year, string reportFormat)
        {
            var dt = await _schoolReportService.GetSchoolReportExport();
            //(educationOrganizationId, submissionWindowDefinitionId, resourceName, StudentUniqueId);

            Stream stream = DataTableToCsv(dt);
            return File(stream, "application/octet-stream");
        }

        [HttpGet]
        [Route("SchoolHealthReport")]
        public async Task<FileResult> SchoolHealthReport(string year, string corp, string schl, string reportFormat)
        {
            var dt = await _schoolReportService.GetSchoolReportExport();
            //(educationOrganizationId, submissionWindowDefinitionId, resourceName, StudentUniqueId);

            Stream stream = DataTableToCsv(dt);
            return File(stream, "application/octet-stream");
        }

        [HttpGet]
        [Route("StateHealthTotalsReport")]
        public async Task<FileResult> StateHealthTotalsReport(string year, string schlType, string reportType)
        {
            var dt = await _schoolReportService.GetSchoolReportExport();
            //(educationOrganizationId, submissionWindowDefinitionId, resourceName, StudentUniqueId);

            Stream stream = DataTableToCsv(dt);
            return File(stream, "application/octet-stream");
        }

        [HttpGet]
        [Route("ContactInformationReport")]
        public async Task<FileResult> ContactInformationReport(string year, string reportFormat)
        {
            var dt = await _schoolReportService.GetSchoolReportExport();
            //(educationOrganizationId, submissionWindowDefinitionId, resourceName, StudentUniqueId);

            Stream stream = DataTableToCsv(dt);
            return File(stream, "application/octet-stream");
        }

        [HttpGet]
        [Route("KindergartenWaiverReport")]
        public async Task<FileResult> KindergartenWaiverReport(string year, string reportFormat)
        {
            var dt = await _schoolReportService.GetSchoolReportExport();
            //(educationOrganizationId, submissionWindowDefinitionId, resourceName, StudentUniqueId);

            Stream stream = DataTableToCsv(dt);
            return File(stream, "application/octet-stream");
        }

        [HttpGet]
        [Route("FirstGradeWaiverReport")]
        public async Task<FileResult> FirstGradeWaiverReport(string year, string reportFormat)
        {
            var dt = await _schoolReportService.GetSchoolReportExport();
            //(educationOrganizationId, submissionWindowDefinitionId, resourceName, StudentUniqueId);

            Stream stream = DataTableToCsv(dt);
            return File(stream, "application/octet-stream");
        }


        private static Stream DataTableToCsv(DataTable table)
        {
            try
            {
                StringBuilder builder = new StringBuilder();
                DataColumn column;
                int iColCount = table.Columns.Count;
                // Treat the header
                for (int i = 0; i < iColCount; i++)
                {
                    if (i != 0) builder.Append(",");
                    builder.Append("\"" + table.Columns[i].ColumnName + "\"");
                }
                builder.AppendLine();
                // Treat content
                foreach (DataRow row in table.Rows)
                {
                    for (int i = 0; i < iColCount; i++)
                    {
                        column = table.Columns[i];
                        if (i != 0) builder.Append(",");
                        if (Convert.IsDBNull(row[column])) builder.Append("\"\"");
                        //else if (row[column].ToString().StartsWith("0")) builder.Append("\"'" + row[column].ToString() + "\"");
                        else builder.Append("\"" + row[column].ToString() + "\"");
                    }
                    builder.AppendLine();
                }
                byte[] bytes = Encoding.GetEncoding("GB2312").GetBytes(builder.ToString());
                Stream stream = new MemoryStream(bytes);
                return stream;
            }
            catch (Exception)
            {
                return null;
            }
        }


    }
}