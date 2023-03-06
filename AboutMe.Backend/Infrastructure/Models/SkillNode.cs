namespace AboutMe.Backend.Infrastructure.Models
{
    public class SkillNode
    {
        public Guid Id { get; set; }
        public Guid SkillTree { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Progress { get; set; } = 0;
        public string Icon { get; set; }
        public Guid RightNode { get; set; }
        public Guid LeftNode { get; set; }
        public Guid UpperNode { get; set; }
        public Guid LowerNode { get; set; }
    }
}
