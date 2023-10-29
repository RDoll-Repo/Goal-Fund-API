using GoalFundApi.Models;
using OmniGLM_API.db;

public interface IQuestRepository
{
    Task<Quest> CreateQuestAsync(Quest quest);
    Task<Quest?> FetchQuestAsync(Guid id);
    Task<SearchResults<Quest>> GetAllQuestsAsync();
    Task<Quest> UpdateQuestAsync(Quest quest);
    Task DeleteQuestAsync(Quest quest);
}

public class QuestRepository : IQuestRepository
{
    public IEFCoreService<Quest, Guid> _efCoreService;

    public QuestRepository(IEFCoreService<Quest, Guid> efCoreService)
    {
        _efCoreService = efCoreService;
    }

    public async Task<Quest> CreateQuestAsync(Quest quest)
    {
        var result = await _efCoreService.CreateAsync(quest);

        return result;
    }

    public async Task<Quest?> FetchQuestAsync(Guid id)
    {
        var result = await _efCoreService.FetchAsync(id);

        return result;
    }

    public async Task<SearchResults<Quest>> GetAllQuestsAsync()
    {
        var results = await _efCoreService.WhereAsync(t => true);

        var response = new SearchResults<Quest>
        {
            ReturnedResults = results.Count(),
            // TODO: placeholder, actual pagination
            TotalResults = results.Count() * 10,
            Results = results.ToList()
        };

        return response;
    }

    public async Task<Quest> UpdateQuestAsync(Quest quest)
    {
        var results = await _efCoreService.UpdateAsync(quest);

        return results;
    }

    public async Task DeleteQuestAsync(Quest quest)
    {
        await _efCoreService.DeleteAsync(quest);
    }
}