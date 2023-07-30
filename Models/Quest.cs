namespace GoalFundApi
{
    public class Quest
    {
        public string Name { get; set; }
        public bool Completed { get; set; }
        public bool Radiant { get; set; }
        public int Reward { get; set; }
        public Frequency Frequency { get; set; }
    }
}