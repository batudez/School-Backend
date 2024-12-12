using Application.Features.Auth.Rules;
using Application.Services.AuthenticatorService;
using Application.Services.AuthService;
using Application.Services.Instructors;
using Application.Services.Students;
using Application.Services.UsersService;
using Domain.Entities;
using MediatR;
using NArchitecture.Core.Security.Enums;
using NArchitecture.Core.Security.JWT;

namespace Application.Features.Auth.Commands.Login;

public class LoginCommand : IRequest<LoggedResponse>
{
    //public UserForLoginDto UserForLoginDto { get; set; }
    public UserForLoginDto UserForLoginDto { get; set; }
    public string IpAddress { get; set; }

    public LoginCommand()
    {
        UserForLoginDto = null!;
        IpAddress = string.Empty;
    }

    public LoginCommand(UserForLoginDto userForLoginDto, string ipAddress)
    {
        UserForLoginDto = userForLoginDto;
        IpAddress = ipAddress;
    }

    public class LoginCommandHandler : IRequestHandler<LoginCommand, LoggedResponse>
    {
        private readonly AuthBusinessRules _authBusinessRules;
        private readonly IAuthenticatorService _authenticatorService;
        private readonly IAuthService _authService;
        private readonly IUserService _userService;
        private readonly IStudentService _studentService; // todo
        private readonly IInstructorService _instructorService;
        public LoginCommandHandler(
            IUserService userService,
            IAuthService authService,
            AuthBusinessRules authBusinessRules,
            IAuthenticatorService authenticatorService
,
            IStudentService studentService,
            IInstructorService instructorService)
        {
            _userService = userService;
            _authService = authService;
            _authBusinessRules = authBusinessRules;
            _authenticatorService = authenticatorService;
            _studentService = studentService;
            _instructorService = instructorService;
        }

        public async Task<LoggedResponse> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            User? user = await _userService.GetAsync(
                predicate: u => u.Email == request.UserForLoginDto.Email,
                cancellationToken: cancellationToken
            );

            await _authBusinessRules.UserShouldBeExistsWhenSelected(user);
            await _authBusinessRules.UserPasswordShouldBeMatch(user!, request.UserForLoginDto.Password);
            LoggedResponse loggedResponse = new();

            // todo: student or instructor check
            if (request.UserForLoginDto.IsLoggerInstructor)
            {
                Instructor instructor = await _instructorService.GetAsync(predicate: u => u.Email == request.UserForLoginDto.Email);
                if (instructor != null)
                {
                    loggedResponse.SchoolId = instructor.Id;
                }
                else
                {
                    return null;
                }
            } else
            {
                Student student = await _studentService.GetAsync(predicate: u => u.Email == request.UserForLoginDto.Email);
                if (student != null)
                {
                    loggedResponse.SchoolId = student.Id;
                }
                else
                {
                    return null;
                }     
            }
           
            loggedResponse.Email = request.UserForLoginDto.Email;

            if (user!.AuthenticatorType is not AuthenticatorType.None)
            {
                if (request.UserForLoginDto.AuthenticatorCode is null)
                {
                    await _authenticatorService.SendAuthenticatorCode(user);
                    loggedResponse.RequiredAuthenticatorType = user.AuthenticatorType;
                    return loggedResponse;
                }

                await _authenticatorService.VerifyAuthenticatorCode(user, request.UserForLoginDto.AuthenticatorCode);
            }

            AccessToken createdAccessToken = await _authService.CreateAccessToken(user);

            Domain.Entities.RefreshToken createdRefreshToken = await _authService.CreateRefreshToken(user, request.IpAddress);
            Domain.Entities.RefreshToken addedRefreshToken = await _authService.AddRefreshToken(createdRefreshToken);
            await _authService.DeleteOldRefreshTokens(user.Id);
            loggedResponse.AccessToken = createdAccessToken;
            loggedResponse.RefreshToken = addedRefreshToken;
            return loggedResponse;
        }
    }
}
