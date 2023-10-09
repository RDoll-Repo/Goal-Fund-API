using GoalFundApi.Models;

public interface IQuestRepository
{
    List<Quest> GetAllQuests();
}

public class QuestRepository : IQuestRepository
{
    private static readonly List<Quest> _examples = new()
    {
        new Quest
        {
            Id = Guid.NewGuid(),
            TaskName = "Do the dishes",
            Completed = false,
            Reward = 1,
            Frequency = Frequency.ONCE
        },
        new Quest
        {
            Id = Guid.NewGuid(),
            TaskName = "Study Swift",
            Completed = false,
            Reward = 1,
            Frequency = Frequency.DAILY
        },
        new Quest
        {
            Id = Guid.NewGuid(),
            TaskName = "Do taxes",
            Completed = true,
            Reward = 3,
            Frequency = Frequency.YEARLY
        }
    };

    public List<Quest> GetAllQuests()
    {
        return _examples;
    }
}