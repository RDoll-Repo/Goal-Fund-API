namespace GoalFundApi.Models
{
    public class Quest
    {
        public Guid Id { get; set; }
        public string TaskName { get; set; }
        public bool Completed { get; set; }
        public int Reward { get; set; }
        public Frequency Frequency { get; set; }
    }
}