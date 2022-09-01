﻿using Application.Features.Languages.Dtos;
using Application.Features.Languages.Commands.CreateLanguage;
using Application.Features.Languages.Commands.UpdateLanguage;
using Application.Features.Languages.Commands.DeleteLanguage;
using Application.Features.Languages.Queries.GetByIdLanguage;
using Application.Features.Languages.Queries.GetListLanguage;
using Core.Application.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MediatR;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LanguagesController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Add(CreateLanguageCommand createLanguageCommand)
        {
            CreatedLanguageDto result = await Mediator.Send(createLanguageCommand);
            return Created("", result);
        }
        [HttpPost("update")]
        public async Task<IActionResult> Update([FromBody] UpdateLanguageCommand updateLanguageCommand)
        {
            UpdatedLanguageDto result = await Mediator.Send(updateLanguageCommand);
            return NoContent();
        }
        [HttpPost("delete/{Id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteLanguageCommand deleteLanguageCommand)
        {
            await Mediator.Send(deleteLanguageCommand);
            return NoContent();
        }
        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListLanguageQuery getListLanguageQuery = new (){ PageRequest = pageRequest };
            LanguageListModel result = await Mediator.Send(getListLanguageQuery);
            return Ok(result);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdLanguageQuery getByIdLanguageQuery)
        {
            LanguageGetByIdDto languageGetByIdDto = await Mediator.Send(getByIdLanguageQuery);
            return Ok(languageGetByIdDto);
        }

    }
}