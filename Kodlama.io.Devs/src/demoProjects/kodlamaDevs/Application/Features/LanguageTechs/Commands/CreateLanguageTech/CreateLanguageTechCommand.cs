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

namespace Application.Features.LanguageTechs.Commands.CreateLanguageTech
{
    public partial class CreateLanguageTechCommand : IRequest<CreatedLanguageTechDto>
    {
        public string Name { get; set; }
        public int LanguageId { get; set; }

        public class CreateLanguageTechCommandHandler : IRequestHandler<CreateLanguageTechCommand, CreatedLanguageTechDto>
        {
            private readonly ILanguageTechRepository _languageTechRepository;
            private readonly IMapper _mapper;
            private readonly LanguageTechsBusinessRules _languageTechBusinessRules;

            public CreateLanguageTechCommandHandler(ILanguageTechRepository languageTechRepository, IMapper mapper, LanguageTechsBusinessRules languageTechBusinessRules)
            {
                _languageTechRepository = languageTechRepository;
                _mapper = mapper;
                _languageTechBusinessRules = languageTechBusinessRules;
            }

            public async Task<CreatedLanguageTechDto> Handle(CreateLanguageTechCommand request, CancellationToken cancellationToken)
            {
                //await _languageTechBusinessRules.LanguageTechNameCanNotBeDuplicatedWhenInserted(request.Name);

                LanguageTech mappedLanguageTech = _mapper.Map<LanguageTech>(request);
                mappedLanguageTech.Active = 1;
                LanguageTech createdLanguageTech = await _languageTechRepository.AddAsync(mappedLanguageTech);
                CreatedLanguageTechDto createdLanguageTechDto = _mapper.Map<CreatedLanguageTechDto>(createdLanguageTech);

                return createdLanguageTechDto;

            }
        }
    }
}
