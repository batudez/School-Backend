using Application.Features.Notes.Commands.Create;
using Application.Features.Notes.Commands.Delete;
using Application.Features.Notes.Commands.Update;
using Application.Features.Notes.Queries.GetById;
using Application.Features.Notes.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class NotesController : BaseController
{
    [HttpPost]
    public async Task<ActionResult<CreatedNoteResponse>> Add([FromBody] CreateNoteCommand command)
    {
        CreatedNoteResponse response = await Mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { response.Id }, response);
    }

    [HttpPut]
    public async Task<ActionResult<UpdatedNoteResponse>> Update([FromBody] UpdateNoteCommand command)
    {
        UpdatedNoteResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<DeletedNoteResponse>> Delete([FromRoute] Guid id)
    {
        DeleteNoteCommand command = new() { Id = id };

        DeletedNoteResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetByIdNoteResponse>> GetById([FromRoute] Guid id)
    {
        GetByIdNoteQuery query = new() { Id = id };

        GetByIdNoteResponse response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<GetListResponse<GetListNoteListItemDto>>> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListNoteQuery query = new() { PageRequest = pageRequest };

        GetListResponse<GetListNoteListItemDto> response = await Mediator.Send(query);

        return Ok(response);
    }
}