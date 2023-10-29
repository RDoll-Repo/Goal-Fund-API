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
    private static readonly List<Quest> _examples = new()
    {
        new Quest
        {
            Id = Guid.Parse("3f384a19-45be-4661-8ae5-eab45f04920b"),
            TaskName = "Do the dishes",
            Completed = false,
            Reward = 1,
            Frequency = Frequency.ONCE
        },
        new Quest
        {
            Id = Guid.Parse("ff6d61e0-44cf-4640-8681-d4d28186c14e"),
            TaskName = "Study Swift",
            Completed = false,
            Reward = 1,
            Frequency = Frequency.DAILY
        },
        new Quest
        {
            Id = Guid.Parse("b4da5e97-f5d1-405c-8c7e-ccfc5a20a21a"),
            TaskName = "Do taxes",
            Completed = true,
            Reward = 3,
            Frequency = Frequency.YEARLY
        }
    };

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
        // TODO: This will be asynchronous once we implement the database
        var results = new SearchResults<Quest>
        {
            ReturnedResults = _examples.Count(),
            TotalResults = _examples.Count() * 10,  // TODO: Just a placeholder. 
            Results = _examples
        };

        return results;
    }

}