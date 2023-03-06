using AboutMe.Backend.Infrastructure.Models;

namespace AboutMe.Backend.Infrastructure.Repositories.SkillTries
{
    internal class SkillTriesRepository : SkillTreeRepositoryBase, ISkillTriesRepository
    {
        internal SkillTriesRepository(IMongoDatabase mongoDatabase) : base(mongoDatabase) {}

        public async Task<SkillNode> FindSkillNode(Guid skillNodeId)
        {
            var result = await SkillNodesCollection.FindAsync(c => c.Id == skillNodeId);
            return await result.SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<SkillNode>> FindSkillNodes(Guid skillTreeId)
        {
            var result = await SkillNodesCollection.FindAsync(c => c.SkillTree == skillTreeId);
            return result.ToEnumerable();
        }

        public async Task<SkillTree> FindSkillTree(Guid skillTreeId)
        {
            var result = await SkillTriesCollection.FindAsync(c => c.Id == skillTreeId);
            return await result.SingleOrDefaultAsync();
        }
    }
}

