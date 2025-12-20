using Microsoft.AspNetCore.Mvc;
using WebProgramlamaProje.Services;

namespace WebProgramlamaProje.Controllers.Api
{
    [ApiController]
    [Route("api/[controller]")]
    public class WorkoutSuggestionsController : ControllerBase
    {
        private readonly IAISuggestionService _aiService;

        public WorkoutSuggestionsController(IAISuggestionService aiService)
        {
            _aiService = aiService;
        }

        [HttpGet]
        public async Task<IActionResult> GetSuggestion(string goal, string level = "beginner", string notes = "")
        {
            if (string.IsNullOrEmpty(goal)) return BadRequest("Hedef (goal) belirtilmelidir.");
            
            var suggestion = await _aiService.GetExerciseSuggestionAsync(goal, level, notes);
            return Ok(new { Goal = goal, Level = level, Notes = notes, Suggestion = suggestion });
        }
    }
}
