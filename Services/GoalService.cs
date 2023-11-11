using GoalFundApi.Models;

public interface IGoalService
{
    Task<ApiResponse<Goal>> CreateGoalAsync(CreateGoalPayload payload);
}

public class GoalService : IGoalService
{
    public IGoalRepository _repo;

    public GoalService(IGoalRepository repo)
    {
        _repo = repo;
    }

    public async Task<ApiResponse<Goal>> CreateGoalAsync(CreateGoalPayload payload)
    {
        // Separate out requirements from payload
        var requirements = payload.Requirements.Select(r => new Requirement(r)).ToList();

        var newGoal = new Goal(payload, requirements);

        var result = await _repo.CreateGoalAsync(newGoal);

        return new ApiResponse<Goal>
        {
            Data = result
        };
    }
}