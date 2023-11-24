using GoalFundApi.Models;

public interface IGoalService
{
    Task<ApiResponse<Goal>> CreateGoalAsync(CreateGoalPayload payload);
    Task<ApiResponse<Goal>> FetchGoalAsync(Guid id);
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
        var newGoal = new Goal(payload);
        
        var requirements = payload.Requirements.Select(r => new Requirement(r, newGoal.Id));

        newGoal.Requirements = requirements.ToList();

        var result = await _repo.CreateGoalAsync(newGoal);

        return new ApiResponse<Goal>
        {
            Data = result
        };
    }

    public async Task<ApiResponse<Goal>> FetchGoalAsync(Guid id)
    {
        var result = await _repo.FetchGoalAsync(id);

        return new ApiResponse<Goal>
        {
            Data = result
        };
    }
}