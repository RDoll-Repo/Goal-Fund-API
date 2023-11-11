using GoalFundApi.Models;

public interface IGoalService
{
    Task<ApiResponse<Goal>> CreateGoalAsync(CreateGoalPayload payload);
}

public class GoalService : IGoalService
{
    public IGoalRepository _goalRepo;
    public IRequirementRepository _reqRepo;

    public GoalService(IGoalRepository goalRepo, IRequirementRepository reqRepo)
    {
        _goalRepo = goalRepo;
        _reqRepo = reqRepo;
    }

    public async Task<ApiResponse<Goal>> CreateGoalAsync(CreateGoalPayload payload)
    {
        var newGoal = new Goal(payload);

        var result = await _goalRepo.CreateGoalAsync(newGoal);

        // Separate out requirements from payload
        var requirements = payload.Requirements.Select(r => new Requirement(r, newGoal.Id)).ToList();

        // This seems like a fucking antipattern to me. TODO: do it better
        requirements.ForEach(async r => await _reqRepo.CreateRequirementAsync(r));

        return new ApiResponse<Goal>
        {
            Data = result
        };
    }
}