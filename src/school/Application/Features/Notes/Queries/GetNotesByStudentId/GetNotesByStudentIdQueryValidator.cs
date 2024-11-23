using FluentValidation;

namespace Application.Features.Notes.Queries.GetNotesByStudentId;

public class GetNotesByStudentIdQueryValidator : AbstractValidator<GetNotesByStudentIdQuery>
{
    public GetNotesByStudentIdQueryValidator() { }
}