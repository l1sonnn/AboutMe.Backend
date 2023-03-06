using AboutMe.Backend.Infrastructure.Models;
using MongoDB.Driver;

namespace AboutMe.Backend.Infrastructure.Repositories.SkillTries
{
    public abstract class SkillTreeRepositoryBase
    {
        internal readonly IMongoCollection<SkillTree> SkillTriesCollection;
        internal readonly IMongoCollection<SkillNode> SkillNodesCollection;
        internal SkillTreeRepositoryBase(IMongoDatabase mongoDatabase)
        {
            SkillTriesCollection = mongoDatabase.GetCollection<SkillTree>("SkillTries");
            SkillNodesCollection = mongoDatabase.GetCollection<SkillNode>("SkillNodes");
        }
    }
}
