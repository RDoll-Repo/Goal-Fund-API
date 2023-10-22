namespace GoalFundApi.Models
{
    public class Goal
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Cost { get; set; }
        public Requirement[]? Requirements { get; set; }
        public bool Completed { get; set; }
        public DateOnly DateAdded { get; set; }
        public DateOnly DateCompleted { get; set; }
    }
}