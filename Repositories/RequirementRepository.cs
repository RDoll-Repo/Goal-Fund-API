using GoalFundApi.Models;
using OmniGLM_API.db;

public interface IRequirementRepository
{
    Task<Requirement> CreateRequirementAsync(Requirement requirement);
}

public class RequirementRepository : IRequirementRepository
{
    public IEFCoreService<Requirement, Guid> _efCoreService;

    public RequirementRepository(IEFCoreService<Requirement, Guid> efCoreService)
    {
        _efCoreService = efCoreService;
    }

    public async Task<Requirement> CreateRequirementAsync(Requirement requirement)
    {
        var result = await _efCoreService.CreateAsync(requirement);

        return result;
    }
}