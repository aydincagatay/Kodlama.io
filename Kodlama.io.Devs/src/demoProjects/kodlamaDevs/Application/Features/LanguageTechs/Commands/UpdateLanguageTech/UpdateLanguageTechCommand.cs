using Application.Features.Languages.Dtos;
using Application.Features.LanguageTechs.Dtos;
using Application.Features.LanguageTechs.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.LanguageTechs.Commands.UpdateLanguage
{
    public partial class UpdateLanguageTechCommand : IRequest<UpdatedLanguageTechDto>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Active { get; set; }

        public class UpdateLanguageTechCommandHandler : IRequestHandler<UpdateLanguageTechCommand, UpdatedLanguageTechDto>
        {
            private readonly ILanguageTechRepository _languageTechRepository;
            private readonly IMapper _mapper;
            private readonly LanguageTechsBusinessRules _languageTechBusinessRules;

            public UpdateLanguageTechCommandHandler(ILanguageTechRepository languageTechRepository, IMapper mapper, LanguageTechsBusinessRules languageTechBusinessRules)
            {
                _languageTechRepository = languageTechRepository;
                _mapper = mapper;
                _languageTechBusinessRules = languageTechBusinessRules;
            }

            public async Task<UpdatedLanguageTechDto> Handle(UpdateLanguageTechCommand request, CancellationToken cancellationToken)
            {
                //await _languageTechBusinessRules.LanguageShouldExistWhenUpdated(request.Id);
                //await _languageTechBusinessRules.LanguageNameCanNotBeDuplicatedWhenUpdated(request.Name);

                LanguageTech? languageTech = await _languageTechRepository.GetAsync(p => p.Id == request.Id);
                _mapper.Map(request, languageTech);
                LanguageTech updatedLanguageTech = await _languageTechRepository.UpdateAsync(languageTech);
                UpdatedLanguageTechDto updatedLanguageTechDto = _mapper.Map<UpdatedLanguageTechDto>(updatedLanguageTech);

                return updatedLanguageTechDto;

            }
        }
    }
}
