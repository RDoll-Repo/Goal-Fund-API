using OmniGLM_API.db;

namespace GoalFundApi.Models
{
    public class Requirement : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool Completed { get; set; }

        public Guid GoalId { get; set; }
    }
}