using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.LanguageTechs.Dtos
{
    public class CreatedLanguageTechDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Active { get; set; }
        public int LanguageId { get; set; }
    }
}
