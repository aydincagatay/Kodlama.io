using Application.Features.Languages.Dtos;
using Core.Persistence.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.LanguageTechs.Dtos
{
    public class LanguageTechListModel:BasePageableModel
    {
        public IList<LanguageTechListDto> Items { get; set; }
    }
}
