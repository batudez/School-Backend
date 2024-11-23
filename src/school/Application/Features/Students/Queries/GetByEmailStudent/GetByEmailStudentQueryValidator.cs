using FluentValidation;

namespace Application.Features.Students.Queries.GetByEmailStudent;

public class GetByEmailStudentQueryValidator : AbstractValidator<GetByEmailStudentQuery>
{
    public GetByEmailStudentQueryValidator() { }
}