namespace AboutMe.Backend.Infrastructure.Models
{
    public class SkillTree
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid[] SkillNodes { get; set; }
    }
}
