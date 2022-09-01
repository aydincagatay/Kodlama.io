﻿using Application.Features.Languages.Dtos;
using Application.Features.Languages.Queries.GetListLanguage;
using Application.Features.Languages.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Languages.Queries.GetByIdLanguage
{
    public class GetByIdLanguageQuery:IRequest<LanguageGetByIdDto>
    {
        public int Id { get; set; }

        public class GetByIdLanguageQueryHandler : IRequestHandler<GetByIdLanguageQuery, LanguageGetByIdDto>
        {
            private readonly ILanguageRepository _languageRepository;
            private readonly IMapper _mapper;
            private readonly LanguagesBusinessRules _languageBusinessRules;

            public GetByIdLanguageQueryHandler(ILanguageRepository languageRepository, IMapper mapper, LanguagesBusinessRules languageBusinessRules)
            {
                _languageRepository = languageRepository;
                _mapper = mapper;
                _languageBusinessRules = languageBusinessRules;
            }

            public async Task<LanguageGetByIdDto> Handle(GetByIdLanguageQuery request, CancellationToken cancellationToken)
            {
                Language? language = await _languageRepository.GetAsync(b=>b.Id == request.Id && b.Active == 1);
                _languageBusinessRules.LanguageShouldExistWhenRequested(language);
                LanguageGetByIdDto languageGetByIdDto = _mapper.Map<LanguageGetByIdDto>(language);
                return languageGetByIdDto;
            }
        }

    }
}
