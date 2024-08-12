using JWTAuthentication.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_development.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobTelemetryController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public JobTelemetryController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/JobTelemetry
        [HttpGet]
        public async Task<ActionResult<IEnumerable<JobTelemetry>>> GetJobTelemetries()
        {
            return await _context.JobTelemetry.ToListAsync();
        }

        // GET: api/JobTelemetry/5
        [HttpGet("{id}")]
        public async Task<ActionResult<JobTelemetry>> GetJobTelemetry(int id)
        {
            var jobTelemetry = await _context.JobTelemetry.FindAsync(id);

            if (jobTelemetry == null)
            {
                return NotFound();
            }

            return Ok(jobTelemetry);
        }

        // POST: api/JobTelemetry
        [HttpPost]
        public async Task<ActionResult<JobTelemetry>> PostJobTelemetry(JobTelemetry jobTelemetry)
        {
            if (jobTelemetry == null)
            {
                return BadRequest("JobTelemetry object is null.");
            }

            _context.JobTelemetry.Add(jobTelemetry);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetJobTelemetry), new { id = jobTelemetry.Id }, jobTelemetry);
        }

        // PATCH: api/JobTelemetry/5
        [HttpPatch("{id}")]
        public async Task<IActionResult> PatchJobTelemetry(int id, [FromBody] JobTelemetry updatedJobTelemetry)
        {
            if (updatedJobTelemetry == null)
            {
                return BadRequest("JobTelemetry object is null");
            }

            if (!JobTelemetryExists(id))
            {
                return NotFound();
            }

            var jobTelemetry = await _context.JobTelemetry.FindAsync(id);

            // Update fields
            jobTelemetry.ProccesId = updatedJobTelemetry.ProccesId;
            jobTelemetry.JobId = updatedJobTelemetry.JobId;
            jobTelemetry.QueueId = updatedJobTelemetry.QueueId;
            jobTelemetry.StepDescription = updatedJobTelemetry.StepDescription;
            jobTelemetry.HumanTime = updatedJobTelemetry.HumanTime;
            jobTelemetry.UniqueReference = updatedJobTelemetry.UniqueReference;
            jobTelemetry.UniqueReferenceType = updatedJobTelemetry.UniqueReferenceType;
            jobTelemetry.BusinessFunction = updatedJobTelemetry.BusinessFunction;
            jobTelemetry.Geography = updatedJobTelemetry.Geography;
            jobTelemetry.ExcludeFromTimeSaving = updatedJobTelemetry.ExcludeFromTimeSaving;
            jobTelemetry.AdditionalInfo = updatedJobTelemetry.AdditionalInfo;
            jobTelemetry.EntryDate = updatedJobTelemetry.EntryDate;

            if (!TryValidateModel(jobTelemetry))
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JobTelemetryExists(id))
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

        // DELETE: api/JobTelemetry/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteJobTelemetry(int id)
        {
            if (!JobTelemetryExists(id))
            {
                return NotFound();
            }

            var jobTelemetry = await _context.JobTelemetry.FindAsync(id);
            _context.JobTelemetry.Remove(jobTelemetry);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JobTelemetryExists(id))
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

        // GET: api/JobTelemetry/savings?reference=123&startDate=2024-01-01&endDate=2024-12-31
        [HttpGet("savings")]
        public async Task<ActionResult<SavingsResult>> GetSavings([FromQuery] string reference, [FromQuery] DateTime startDate, [FromQuery] DateTime endDate)
        {
            if (string.IsNullOrEmpty(reference))
            {
                return BadRequest("Reference is required.");
            }

            if (startDate == default || endDate == default || endDate < startDate)
            {
                return BadRequest("Invalid date range.");
            }

            // Query JobTelemetry based on the given criteria
            var telemetryData = await _context.JobTelemetry
                .Where(jt => jt.EntryDate >= startDate && jt.EntryDate <= endDate && jt.UniqueReference == reference)
                .ToListAsync();

            if (!telemetryData.Any())
            {
                return NotFound("No telemetry data found for the specified criteria.");
            }

            // Retrieve Process data separately if needed
            var processIds = telemetryData.Select(jt => jt.ProccesId).Distinct();
            var processes = await _context.Process
                .Where(p => processIds.Contains(p.ProcessID.ToString()))  // Convert if necessary
                .ToListAsync();

            var totalHumanTimeSaved = telemetryData.Sum(jt => jt.HumanTime);
            var totalCostSaved = 0; // Placeholder: Compute based on additional logic if needed

            var result = new SavingsResult
            {
                TotalHumanTimeSaved = totalHumanTimeSaved,
                TotalCostSaved = totalCostSaved,
                Processes = processes // Include process details in the result if needed
            };

            return Ok(result);
        }





        private bool JobTelemetryExists(int id)
        {
            return _context.JobTelemetry.Any(e => e.Id == id);
        }
    }
}
