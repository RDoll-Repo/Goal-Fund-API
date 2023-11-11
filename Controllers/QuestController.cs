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

    [HttpPost]
    public async Task<ActionResult<ApiResponse<Quest>>> CreateQuest(ApiPayload<CreateQuestPayload> payload)
    {
        var result = await _service.CreateQuestAsync(payload.Data);

        return Created("", result);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<Quest>>> FetchQuest(Guid id)
    {
        var result = await _service.FetchQuestAsync(id);

        return result;
    }

    [HttpGet]
    public async Task<ActionResult<ApiResponse<SearchMeta, SearchQuestsViewModel>>> GetQuests()
    {
        var results = await _service.GetAllQuestsAsync();

        return results; 
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<ApiResponse<Quest>>> UpdateQuestAsync(
        Guid id,
        ApiPayload<UpdateQuestPayload> payload
    )
    {
        var results = await _service.UpdateQuestAsync(id, payload.Data);

        return results;
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteQuestAsync(Guid id)
    {
        await _service.DeleteQuestAsync(id);

        return NoContent();
    }
}