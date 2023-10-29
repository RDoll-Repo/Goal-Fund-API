using GoalFundApi.Models;
using OmniGLM_API.db;

public interface IQuestRepository
{
    Task<Quest> CreateQuest(Quest quest);
    Task<Quest?> FetchQuest(Guid id);
    Task<SearchResults<Quest>> GetAllQuests();
}

public class QuestRepository : IQuestRepository
{
    public IEFCoreService<Quest, Guid> _efCoreService;

    public QuestRepository(IEFCoreService<Quest, Guid> efCoreService)
    {
        _efCoreService = efCoreService;
    }

    public async Task<Quest> CreateQuest(Quest quest)
    {
        var result = await _efCoreService.CreateAsync(quest);

        return result;
    }

    public async Task<Quest?> FetchQuest(Guid id)
    {
        var result = await _efCoreService.FetchAsync(id);

        return result;
    }

    public async Task<SearchResults<Quest>> GetAllQuests()
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

}