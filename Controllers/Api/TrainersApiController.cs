using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebProgramlamaProje.Data;
using WebProgramlamaProje.Models;

namespace WebProgramlamaProje.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainersApiController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public TrainersApiController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/TrainersApi?specialty=Yoga
        [HttpGet]
        public async Task<IActionResult> GetTrainers(string? specialty, int? gymId)
        {
            // LINQ query for requirement #4 in PDF
            IQueryable<Trainer> query = _context.Trainers.Include(t => t.Gym);

            if (!string.IsNullOrEmpty(specialty))
            {
                query = query.Where(t => t.Specialty.Contains(specialty));
            }

            if (gymId.HasValue)
            {
                query = query.Where(t => t.GymId == gymId.Value);
            }

            var trainers = await query.Select(t => new {
                t.Id,
                t.Name,
                t.Specialty,
                t.ExperienceYears,
                t.Availability,
                GymName = t.Gym != null ? t.Gym.Name : "Belirtilmemiş"
            }).ToListAsync();

            return Ok(trainers);
        }
    }
}
