using OmniGLM_API.db;

namespace GoalFundApi.Models
{
    public class Goal : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Cost { get; set; }
        public bool Completed { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? CompletedAt { get; set; }
        public ICollection<Requirement>? Requirements { get; set; }

        public Goal() {}

        public Goal(CreateGoalPayload payload)
        {
            Id = Guid.NewGuid();
            Name = payload.Name;
            Cost = payload.Cost;
            Completed = false;
            CreatedAt = DateTime.UtcNow;
        }
    }

    public class CreateGoalPayload
    {
        public string Name { get; set; }
        public int Cost { get; set; }
        public string[] Requirements { get; set; }
    }
}