using Application.Features.LanguageTechs.Dtos;
using Application.Features.LanguageTechs.Commands.CreateLanguageTech;
using Application.Features.LanguageTechs.Commands.UpdateLanguageTech;
using Application.Features.LanguageTechs.Commands.DeleteLanguageTech;
using Application.Features.LanguageTechs.Queries.GetListLanguageTech;
using Core.Application.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MediatR;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LanguageTechsController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Add(CreateLanguageTechCommand createLanguageTechCommand)
        {
            CreatedLanguageTechDto result = await Mediator.Send(createLanguageTechCommand);
            return Created("", result);
        }
        [HttpPost("update")]
        public async Task<IActionResult> Update([FromBody] UpdateLanguageTechCommand updateLanguageTechCommand)
        {
            UpdatedLanguageTechDto result = await Mediator.Send(updateLanguageTechCommand);
            return NoContent();
        }
        [HttpPost("delete/{Id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteLanguageTechCommand deleteLanguageTechCommand)
        {
            await Mediator.Send(deleteLanguageTechCommand);
            return NoContent();
        }
        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListLanguageTechQuery getListLanguageTechQuery = new (){ PageRequest = pageRequest };
            LanguageTechListModel result = await Mediator.Send(getListLanguageTechQuery);
            return Ok(result);
        }

    }
}
