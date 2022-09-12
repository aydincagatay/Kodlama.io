using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class LanguageTech : Entity
    {
        public int LanguageId { get; set; }
        public string Name { get; set; }
        public int Active { get; set; }
        public virtual Language? Language { get; set; }

        public LanguageTech()
        {
        }

        public LanguageTech(int id, string name, int active, int languageId) : this()
        {
            Id = id;
            LanguageId = languageId;
            Name = name;
            Active = active;
        }
    }
}
