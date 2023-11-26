using GoalFundApi.Models;
using Microsoft.EntityFrameworkCore;
using OmniGLM_API.db;

public interface IGoalRepository
{
    Task<Goal> CreateGoalAsync(Goal goal);
    Task<Goal?> FetchGoalAsync(Guid id);
}

public class GoalRepository : IGoalRepository
{
    public IEFCoreService<Goal, Guid> _efCoreService;

    public GoalRepository(IEFCoreService<Goal, Guid> efCoreService)
    {
        _efCoreService = efCoreService;
    }

    public async Task<Goal> CreateGoalAsync(Goal goal)
    {
        var result = await _efCoreService.CreateAsync(goal);

        return result;
    }

    public async Task<Goal?> FetchGoalAsync(Guid id)
    {
        var result = await _efCoreService.QueryableWhere(g => g.Id == id)
            .Include(g => g.Requirements)
            .FirstOrDefaultAsync();

        return result;
    }
}