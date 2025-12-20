using Microsoft.AspNetCore.Mvc;
using WebProgramlamaProje.Services;

namespace WebProgramlamaProje.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkoutSuggestionsController : ControllerBase
    {
        private readonly IAISuggestionService _aiService;

        public WorkoutSuggestionsController(IAISuggestionService aiService)
        {
            _aiService = aiService;
        }

        [HttpGet]
        public IActionResult GetSuggestion(string goal, string level = "beginner")
        {
            if (string.IsNullOrEmpty(goal)) return BadRequest("Hedef (goal) belirtilmelidir.");
            
            var suggestion = _aiService.GetExerciseSuggestion(goal, level);
            return Ok(new { Goal = goal, Level = level, Suggestion = suggestion });
        }
    }
}
