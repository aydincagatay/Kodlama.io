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

namespace Application.Features.LanguageTechs.Commands.DeleteLanguageTech
{
    public partial class DeleteLanguageTechCommand:IRequest<DeletedLanguageTechDto>
    {
        public int Id { get; set; }

        public class DeleteLanguageCommandHandler : IRequestHandler<DeleteLanguageTechCommand, DeletedLanguageTechDto>
        {
            private readonly ILanguageTechRepository _languageTechRepository;
            private readonly IMapper _mapper;
            private readonly LanguageTechsBusinessRules _languageTechBusinessRules;

            public DeleteLanguageCommandHandler(ILanguageTechRepository languageTechRepository, IMapper mapper, LanguageTechsBusinessRules languageTechBusinessRules)
            {
                _languageTechRepository = languageTechRepository;
                _mapper = mapper;
                _languageTechBusinessRules = languageTechBusinessRules;
            }

            public async Task<DeletedLanguageTechDto> Handle(DeleteLanguageTechCommand request, CancellationToken cancellationToken)
            {
                LanguageTech? languageTech = await _languageTechRepository.GetAsync(b => b.Id == request.Id);
                _languageTechBusinessRules.LanguageTechShouldExistWhenDeleted(languageTech);
                LanguageTech deletedLanguageTech = await _languageTechRepository.DeleteAsync(languageTech);
                DeletedLanguageTechDto deletedLanguageTechDto = _mapper.Map<DeletedLanguageTechDto>(deletedLanguageTech);
                return deletedLanguageTechDto;
            }
        }
    }
}
