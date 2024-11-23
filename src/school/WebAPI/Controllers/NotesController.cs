using Application.Features.Notes.Commands.Create;
using Application.Features.Notes.Commands.Delete;
using Application.Features.Notes.Commands.Update;
using Application.Features.Notes.Queries.GetById;
using Application.Features.Notes.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;
using Application.Features.Notes.Queries.GetNotesByStudentId;
using Application.Features.Notes.Commands.UpdateGrades;
using Application.Features.Notes.Queries.GetNotesByCourseId;

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
    [HttpPut("update-grades")]
    public async Task<IActionResult> UpdateGrades([FromBody] UpdateGradesCommand command)
    {
        UpdatedGradesResponse response  = await Mediator.Send(command);
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
    public async Task<ActionResult<GetListResponse<GetListNoteListItemDto>>> GetList([FromQuery] GetListNoteQuery request)
    {
        GetListNoteQuery query = new() { StudentId = request.StudentId};

        GetListResponse<GetListNoteListItemDto> response = await Mediator.Send(query);

        return Ok(response);
    }
    
    [HttpGet("GetNotesByStudentId")]
    public async Task<ActionResult<GetNotesByStudentIdResponse>> GetNotesByStudentId([FromQuery] GetNotesByStudentIdQuery getNotesByStudentIdQuery)
    {
        GetNotesByStudentIdResponse response = await Mediator.Send(getNotesByStudentIdQuery);
        return Ok(response);
    }
    [HttpGet("GetNotesByCourseId")]
    public async Task<ActionResult<GetListResponse<GetListNoteListItemDto>>> GetList([FromQuery] GetNotesByCourseIdQuery request)
    {
        GetNotesByCourseIdQuery query = new() { CourseId = request.CourseId };

        GetListResponse<GetListNoteListItemDto> response = await Mediator.Send(query);

        return Ok(response);
    }
}
