using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.LanguageTechs.Rules
{
    public class LanguageTechsBusinessRules
    {
        private readonly ILanguageTechRepository _languageTechRepository;

        public LanguageTechsBusinessRules(ILanguageTechRepository languageTechRepository)
        {
            _languageTechRepository = languageTechRepository;
        }

        //public async Task LanguageNameCanNotBeDuplicatedWhenInserted(string name)
        //{
        //    IPaginate<Language> result = await _languageTechRepository.GetListAsync(b => b.Name == name);
        //    if (result.Items.Any()) throw new BusinessException("Language name exists.");
        //}

        //public async Task LanguageNameCanNotBeDuplicatedWhenUpdated(string name)
        //{
        //    IPaginate<Language> result = await _languageTechRepository.GetListAsync(b => b.Name == name);
        //    if (result.Items.Any()) throw new BusinessException("Language name exists.");
        //}
        //public async Task LanguageShouldExistWhenUpdated(int Id)
        //{
        //    Language? result = await _languageTechRepository.GetAsync(p => p.Id == Id);
        //    if (result == null) throw new BusinessException("Language does not exist");
        //}

        public void LanguageTechShouldExistWhenRequested(LanguageTech languageTech) 
        {
            if (languageTech == null) throw new BusinessException("Requested language tech does not exist.");
        }

        public void LanguageTechShouldExistWhenDeleted(LanguageTech? languageTech)
        {
            if (languageTech == null) throw new BusinessException("Delete failed, requested language tech does not exist.");
        }
    }
}
