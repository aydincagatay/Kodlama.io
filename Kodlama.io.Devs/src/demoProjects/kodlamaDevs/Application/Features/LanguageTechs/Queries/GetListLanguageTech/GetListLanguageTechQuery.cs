using Application.Features.Languages.Dtos;
using Application.Features.LanguageTechs.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.LanguageTechs.Queries.GetListLanguageTech
{
    public class GetListLanguageTechQuery:IRequest<LanguageTechListModel>
    {

        public PageRequest PageRequest { get; set; }

        public class GetListLanguageTechQueryHandler : IRequestHandler<GetListLanguageTechQuery, LanguageTechListModel>
        {
            ILanguageTechRepository _languageTechRepository;
            IMapper _mapper;

            public GetListLanguageTechQueryHandler(ILanguageTechRepository languageTechRepository, IMapper mapper)
            {
                _languageTechRepository = languageTechRepository;
                _mapper = mapper;
            }

            public async Task<LanguageTechListModel> Handle(GetListLanguageTechQuery request, CancellationToken cancellationToken)
            {
                IPaginate<LanguageTech> languageTechs = await _languageTechRepository.GetListAsync(include:
                    m=>m.Include(c=>c.Language),
                    index: request.PageRequest.Page, 
                    size:request.PageRequest.PageSize);

                LanguageTechListModel mappedLanguageTechListModel = _mapper.Map<LanguageTechListModel>(languageTechs);
                return mappedLanguageTechListModel;
            }
        }
    }
}
