using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.LanguageTechs.Dtos
{
    public class LanguageTechListDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Active { get; set; }
        public string LanguageName { get; set; }
    }
}
