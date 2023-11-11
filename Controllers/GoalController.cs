using GoalFundApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace GoalFundApi.Controllers;

[ApiController]
[Route("goals")]
public class GoalController : ControllerBase
{
    public IGoalService _service;

    public GoalController(IGoalService service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task<ActionResult<ApiResponse<Goal>>> CreateGoal(
        ApiPayload<CreateGoalPayload> payload
    )
    {
        var result = await _service.CreateGoalAsync(payload.Data);

        return Created("", result);
    }
}