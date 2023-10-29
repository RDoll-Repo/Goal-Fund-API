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

        public Quest() {}

        public Quest(CreateQuestPayload payload)
        {
            Id = Guid.NewGuid();
            TaskName = payload.TaskName;
            Completed = false;
            Reward = payload.Reward;
            Frequency = payload.Frequency;
        }

        public void SetValues(UpdateQuestPayload payload)
        {
            TaskName = payload.TaskName;
            Completed = payload.Completed;
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

    public class CreateQuestPayload
    {
        public string TaskName { get; set; }
        public int Reward { get; set; }
        public Frequency Frequency { get; set; } = Frequency.ONCE;
    }

    // TODO: Probably a temp implementation
    public class UpdateQuestPayload : CreateQuestPayload
    {
        public bool Completed { get; set; }
    }
}