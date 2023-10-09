using GoalFundApi.Models;

public interface IQuestService
{
    List<Quest> GetAllQuests();
}

public class QuestService : IQuestService
{
    public IQuestRepository _repo;
    public QuestService(IQuestRepository repo)
    {
        _repo = repo;
    }
    public List<Quest> GetAllQuests()
    {
        var results = _repo.GetAllQuests();

        return results;
    }
}