using GoalFundApi.Models;

public interface IQuestService
{
    Task<ApiResponse<Quest>> CreateQuest(QuestPayload payload);
    Task<ApiResponse<Quest>> FetchQuest(Guid id);
    Task<ApiResponse<SearchMeta, SearchQuestsViewModel>> GetAllQuests();
}

public class QuestService : IQuestService
{
    public IQuestRepository _repo;
    public QuestService(IQuestRepository repo)
    {
        _repo = repo;
    }

    public async Task<ApiResponse<Quest>> CreateQuest(QuestPayload payload)
    {
        var result = await _repo.CreateQuest(new Quest(payload));

        return new ApiResponse<Quest>
        {
            Data = result
        };
    }

    public async Task<ApiResponse<Quest>> FetchQuest(Guid id)
    {
        var result = await _repo.FetchQuest(id);

        return new ApiResponse<Quest>
        {
            Data = result
        };
    }

    public async Task<ApiResponse<SearchMeta, SearchQuestsViewModel>> GetAllQuests()
    {
        var results = await _repo.GetAllQuests();

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

}