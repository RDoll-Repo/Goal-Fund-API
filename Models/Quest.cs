using OmniGLM_API.db;

namespace GoalFundApi.Models
{
    public class Quest : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public string TaskName { get; set; }
        public bool Completed { get; set; }
        public int Reward { get; set; }
        public Frequency Frequency { get; set; }

        // TODO: Remove at end of Phase 1
        public Quest() {}

        public Quest(QuestPayload payload)
        {
            Id = Guid.NewGuid();
            TaskName = payload.TaskName;
            Completed = false;
            Reward = payload.Reward;
            Frequency = payload.Frequency;
        }
    }

    public class SearchQuestsViewModel
    {
        public IEnumerable<Quest> Quests { get; set; }

        public SearchQuestsViewModel(IEnumerable<Quest> quests)
        {
            Quests = quests;
        }
    }

    public class QuestPayload
    {
        public string TaskName { get; set; }
        public int Reward { get; set; }
        public Frequency Frequency { get; set; } = Frequency.ONCE;
    }
}