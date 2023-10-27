using OmniGLM_API.db;

namespace GoalFundApi.Models
{
    public class Goal : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Cost { get; set; }
        public bool Completed { get; set; }
        public DateOnly CreatedAt { get; set; }
        public DateOnly CompletedAt { get; set; }
        public Requirement[]? Requirements { get; set; }
    }
}