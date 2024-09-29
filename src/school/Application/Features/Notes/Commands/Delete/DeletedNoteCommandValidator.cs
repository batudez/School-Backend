using FluentValidation;

namespace Application.Features.Notes.Commands.Delete;

public class DeleteNoteCommandValidator : AbstractValidator<DeleteNoteCommand>
{
    public DeleteNoteCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}