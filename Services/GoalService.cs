using GoalFundApi.Models;

public interface IGoalService
{
    Task<ApiResponse<Goal>> CreateGoalAsync(CreateGoalPayload payload);
}

public class GoalService : IGoalService
{
    public IGoalRepository _goalRepo;

    public GoalService(IGoalRepository goalRepo)
    {
        _goalRepo = goalRepo;
    }

    public async Task<ApiResponse<Goal>> CreateGoalAsync(CreateGoalPayload payload)
    {
        var newGoal = new Goal(payload);
        
        var requirements = payload.Requirements.Select(r => new Requirement(r, newGoal.Id));

        newGoal.Requirements = requirements.ToList();

        var result = await _goalRepo.CreateGoalAsync(newGoal);

        return new ApiResponse<Goal>
        {
            Data = result
        };
    }
}