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

    [HttpPost]
    public async Task<ActionResult<ApiResponse<Quest>>> CreateQuest(ApiPayload<QuestPayload> payload)
    {
        var result = await _service.CreateQuest(payload.Data);

        return result;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<Quest>>> FetchQuest(Guid id)
    {
        var result = await _service.FetchQuest(id);

        return result;
    }

    [HttpGet]
    public async Task<ActionResult<ApiResponse<SearchMeta, SearchQuestsViewModel>>> GetQuests()
    {
        var results = await _service.GetAllQuests();

        return results; 
    }

}