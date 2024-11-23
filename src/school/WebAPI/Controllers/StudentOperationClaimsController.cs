using Application.Features.StudentOperationClaims.Commands.Create;
using Application.Features.UserOperationClaims.Commands.Create;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;
[Route("api/[controller]")]
[ApiController]
public class StudentOperationClaimsController : ControllerBase
{
    private readonly IMediator _mediator;

    public StudentOperationClaimsController(IMediator mediator)
    {
        _mediator = mediator;
    }
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateStudentOperationClaimCommand createStudentOperationClaimCommand)
    {
        CreatedStudentOperationClaimResponse result = await _mediator.Send(createStudentOperationClaimCommand);
        return Created(uri: "", result);
    }
}
