using Application.Features.LanguageTechs.Commands.CreateLanguageTech;
using Application.Features.LanguageTechs.Commands.DeleteLanguageTech;
using Application.Features.LanguageTechs.Commands.UpdateLanguageTech;
using Application.Features.LanguageTechs.Dtos;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.LanguageTechs.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<LanguageTech, CreatedLanguageTechDto>().ReverseMap();
            CreateMap<LanguageTech, CreateLanguageTechCommand>().ReverseMap();
            CreateMap<IPaginate<LanguageTech>, LanguageTechListModel>().ReverseMap();
            CreateMap<LanguageTech, LanguageTechListDto>().ReverseMap();
            CreateMap<LanguageTech, UpdatedLanguageTechDto>().ReverseMap();
            CreateMap<LanguageTech, UpdateLanguageTechCommand>().ReverseMap();
            CreateMap<LanguageTech, DeletedLanguageTechDto>().ReverseMap();
            CreateMap<LanguageTech, DeleteLanguageTechCommand>().ReverseMap();
            CreateMap<LanguageTech, LanguageTechListDto>().ForMember(c => c.LanguageName, opt => opt.MapFrom(c => c.Language.Name)).ReverseMap();
        }
    }
}
