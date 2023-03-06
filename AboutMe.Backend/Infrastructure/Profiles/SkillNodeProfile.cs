using AutoMapper;

namespace AboutMe.Backend.Infrastructure.Profiles
{
    public class SkillNodeProfile : Profile
    {
        public SkillNodeProfile()
        {
            CreateMap<Models.SkillTree, Protos.SkillTree>();
            CreateMap<Protos.SkillTree, Models.SkillTree>();
            CreateMap<Models.SkillTree, Protos.SkillTreeResponse>();
        }
    }
}
