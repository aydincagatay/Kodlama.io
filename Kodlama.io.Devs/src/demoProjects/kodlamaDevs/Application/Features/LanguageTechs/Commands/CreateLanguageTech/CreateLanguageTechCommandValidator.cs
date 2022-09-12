using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.LanguageTechs.Commands.CreateLanguageTech
{
    public class CreateLanguageTechCommandValidator:AbstractValidator<CreateLanguageTechCommand>
    {
        public CreateLanguageTechCommandValidator()
        {
            RuleFor(c => c.Name).NotEmpty();
            RuleFor(c => c.Name).MinimumLength(1);
        }
    }
}
