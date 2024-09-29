using NArchitecture.Core.Application.Responses;

namespace Application.Features.Instructors.Queries.GetById;

public class GetByIdInstructorResponse : IResponse
{
    public Guid Id { get; set; }
    public string NameSurname { get; set; }
    public string Email { get; set; }
    public string Address { get; set; }
    public string Password { get; set; }
    public string PasswordConfirm { get; set; }
    public string ImageUrl { get; set; }
}