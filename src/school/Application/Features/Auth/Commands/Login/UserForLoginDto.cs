﻿using NArchitecture.Core.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Auth.Commands.Login;
public class UserForLoginDto : IDto
{
    public string Email { get; set; }
    public string Password { get; set; }
    public bool IsLoggerInstructor { get; set; }
    public string? AuthenticatorCode { get; set; }

    public UserForLoginDto()
    {
        Email = string.Empty;
        Password = string.Empty;
        IsLoggerInstructor = true;
    }

    public UserForLoginDto(string email, string password,bool isLoggerInstructor)
    {
        Email = email;
        Password = password;
        IsLoggerInstructor = isLoggerInstructor;
    }
}