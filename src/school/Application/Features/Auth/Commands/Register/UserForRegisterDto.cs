using NArchitecture.Core.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Auth.Commands.Register;
public class UserForRegisterDto : IDto
{
    public string NameSurname { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string TelephoneNumber { get; set; }
    public string Address { get; set; }
    public string ImageUrl { get; set; }
    public bool IsInstructor { get; set; }
    public UserForRegisterDto()
    {
        NameSurname = string.Empty;
        Email = string.Empty;
        Password = string.Empty;
        TelephoneNumber = string.Empty;
        Address = string.Empty;
        ImageUrl = string.Empty;
        IsInstructor = false;
    }

    public UserForRegisterDto(string email, string password,string nameSurname,bool isInstructor,string telephoneNumber,string address,string imageUrl)
    {
        NameSurname = nameSurname;
        Email = email;
        Password = password;
        IsInstructor = isInstructor;
        TelephoneNumber = telephoneNumber;
        Address = address;
        ImageUrl = imageUrl;
    }
}
