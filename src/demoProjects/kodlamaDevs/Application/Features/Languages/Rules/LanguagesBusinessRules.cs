using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Languages.Rules
{
    public class LanguagesBusinessRules
    {
        private readonly ILanguageRepository _languageRepository;

        public LanguagesBusinessRules(ILanguageRepository languageRepository)
        {
            _languageRepository = languageRepository;
        }

        public async Task LanguageNameCanNotBeDuplicatedWhenInserted(string name)
        {
            IPaginate<Language> result = await _languageRepository.GetListAsync(b => b.Name == name);
            if (result.Items.Any()) throw new BusinessException("Language name exists.");
        }

        public async Task LanguageNameCanNotBeDuplicatedWhenUpdated(string name)
        {
            IPaginate<Language> result = await _languageRepository.GetListAsync(b => b.Name == name);
            if (result.Items.Any()) throw new BusinessException("Language name exists.");
        }
        public async Task LanguageShouldExistWhenUpdated(int Id)
        {
            Language? result = await _languageRepository.GetAsync(p => p.Id == Id);
            if (result == null) throw new BusinessException("Language does not exist");
        }

        public void LanguageShouldExistWhenRequested(Language language) 
        {
            if (language == null) throw new BusinessException("Requested language does not exist.");
        }

        public void LanguageShouldExistWhenDeleted(Language? language)
        {
            if (language == null) throw new BusinessException("Delete failed, requested language does not exist.");
        }
    }
}
