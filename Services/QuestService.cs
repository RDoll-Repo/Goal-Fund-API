using GoalFundApi.Models;

public interface IQuestService
{
    Task<ApiResponse<Quest>> CreateQuestAsync(CreateQuestPayload payload);
    Task<ApiResponse<Quest>> FetchQuestAsync(Guid id);
    Task<ApiResponse<SearchMeta, SearchQuestsViewModel>> GetAllQuestsAsync();
    Task<ApiResponse<Quest>> UpdateQuestAsync(Guid id, UpdateQuestPayload updatedQuest);
}

public class QuestService : IQuestService
{
    public IQuestRepository _repo;
    public QuestService(IQuestRepository repo)
    {
        _repo = repo;
    }

    public async Task<ApiResponse<Quest>> CreateQuestAsync(CreateQuestPayload payload)
    {
        var result = await _repo.CreateQuestAsync(new Quest(payload));

        return new ApiResponse<Quest>
        {
            Data = result
        };
    }

    public async Task<ApiResponse<Quest>> FetchQuestAsync(Guid id)
    {
        var result = await _repo.FetchQuestAsync(id);

        return new ApiResponse<Quest>
        {
            Data = result
        };
    }

    // TODO: Replace with proper search and/or get all for user
    public async Task<ApiResponse<SearchMeta, SearchQuestsViewModel>> GetAllQuestsAsync()
    {
        var results = await _repo.GetAllQuestsAsync();

        var response = new ApiResponse<SearchMeta, SearchQuestsViewModel>
        {
            Meta = new SearchMeta
            {
                ReturnedResults = results.ReturnedResults,
                TotalResults = results.TotalResults
            },
            Data = new SearchQuestsViewModel(results.Results)
        };

        return response;
    }

    public async Task<ApiResponse<Quest>> UpdateQuestAsync(Guid id, UpdateQuestPayload payload)
    {
        var updatedQuest = await _repo.FetchQuestAsync(id);

        if (updatedQuest is null) 
        {
            // TODO: Replace with actual 404
            System.Console.WriteLine("Not found");
            return null;
        }

        updatedQuest.SetValues(payload);

        var updated = await _repo.UpdateQuestAsync(updatedQuest);

        return new ApiResponse<Quest>
        {
            Data = updated
        };
    }
}