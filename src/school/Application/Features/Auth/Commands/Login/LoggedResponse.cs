using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Security.Enums;
using NArchitecture.Core.Security.JWT;

namespace Application.Features.Auth.Commands.Login;

public class LoggedResponse : IResponse
{
    public AccessToken? AccessToken { get; set; }
    public Domain.Entities.RefreshToken? RefreshToken { get; set; }
    public AuthenticatorType? RequiredAuthenticatorType { get; set; }
    public string? Email { get; set; }
    public Guid SchoolId { get; set; }

    public LoggedHttpResponse ToHttpResponse()
    {
        return new() { AccessToken = AccessToken, RequiredAuthenticatorType = RequiredAuthenticatorType,
        Email = Email , SchoolId = SchoolId};
    }

    public class LoggedHttpResponse
    {
        public string? Email { get; set; }
        public AccessToken? AccessToken { get; set; }
        public AuthenticatorType? RequiredAuthenticatorType { get; set; }
        public Guid SchoolId { get; internal set; }
    }
}
