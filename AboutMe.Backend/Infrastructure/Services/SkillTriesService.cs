
using AboutMe.Backend.Infrastructure.Protos;
using AboutMe.Backend.Infrastructure.Repositories.SkillTries;
using AutoMapper;
using Grpc.Core;
using Microsoft.AspNetCore.Authorization;

namespace AboutMe.Backend.Infrastructure.Services
{
    [Authorize]
    internal class SkillTriesService : SkillTries.SkillTriesBase
    {
        private readonly ISkillTriesRepository _skillTreeRepository;
        private readonly IMapper _mapper;
        public SkillTriesService(ISkillTriesRepository skillTriesRepository, IMapper mapper)
        {
            _skillTreeRepository = skillTriesRepository;
            _mapper = mapper;
        }

        public async override Task<SkillTreeResponse>? GetSkillTree(SkillTreeRequest request, ServerCallContext context)
        {
            var skillTreeIdLine = request.Id;
            if (string.IsNullOrEmpty(skillTreeIdLine)) return null;

            var skillTreeId = Guid.Empty;
            Guid.TryParse(skillTreeIdLine, out skillTreeId);
            if(skillTreeId == Guid.Empty) return null;

            var skillTree = await _skillTreeRepository.FindSkillTree(skillTreeId);
            if (skillTree is null) return null;
   
            var skillTreeResponse = _mapper.Map<SkillTreeResponse>(skillTree);

            return skillTreeResponse;
        }

        
    }
}
