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
    public IEnumerable<Quest> GetQuests()
    {
        var results = _service.GetAllQuests();

        return results; 
    }

    // Fetch

    // Add 

    // Update

    // Delete

    // Complete

}
