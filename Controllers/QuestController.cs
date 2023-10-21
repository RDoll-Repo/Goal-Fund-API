using GoalFundApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace GoalFundApi.Controllers;

[ApiController]
[Route("quests")]
public class QuestController : ControllerBase
{
    public IQuestService _service;
    public QuestController(IQuestService service)
    {
        _service = service;
    }

    // Get
    [HttpGet]
    public async Task<ActionResult<ApiResponse<SearchMeta, SearchQuestsViewModel>>> GetQuests()
    {
        var results = await _service.GetAllQuests();

        return results; 
    }

    // Fetch
    [HttpGet("id")]
    public Quest FetchQuest()
    {
        return null;
    }
    // Add 

    // Update

    // Delete

    // Complete

}
