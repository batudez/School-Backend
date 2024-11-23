using NArchitecture.Core.Application.Dtos;

namespace Application.Features.Students.Queries.GetList;

public class GetListStudentListItemDto : IDto
{
    public Guid Id { get; set; }
    public string NameSurname { get; set; }
    public string Email { get; set; }
    public string TelephoneNumber { get; set; }
    public string Address { get; set; }
    public string Password { get; set; }
    public string PasswordConfirm { get; set; }
    public string ImageUrl { get; set; }
    public Guid UserId { get; set; }
}