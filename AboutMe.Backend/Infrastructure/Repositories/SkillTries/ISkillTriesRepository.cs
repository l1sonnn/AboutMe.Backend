using AboutMe.Backend.Infrastructure.Models;

namespace AboutMe.Backend.Infrastructure.Repositories.SkillTries
{
    internal interface ISkillTriesRepository
    {
        Task<IEnumerable<SkillNode>> FindSkillNodes(Guid skillTreeId);
        Task<SkillTree> FindSkillTree(Guid skillTreeId);
        Task<SkillNode> FindSkillNode(Guid skillNodeId);
    }
}
