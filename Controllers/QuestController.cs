using GoalFundApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace GoalFundApi.Controllers;

[ApiController]
[Route("quests")]
public class QuestController : ControllerBase
{
    public IQuestService _service;
    public ApplicationConfig _config;

    public QuestController(IQuestService service, ApplicationConfig config)
    {
        _service = service;
        _config = config;
    }

    // Get
    [HttpGet]
    public async Task<ActionResult<ApiResponse<SearchMeta, SearchQuestsViewModel>>> GetQuests()
    {
        var results = await _service.GetAllQuests();

        return results; 
    }
}
