using GoalFundApi.Models;

public interface IQuestService
{
    Task<ApiResponse<SearchMeta, SearchQuestsViewModel>> GetAllQuests();
}

public class QuestService : IQuestService
{
    public IQuestRepository _repo;
    public QuestService(IQuestRepository repo)
    {
        _repo = repo;
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