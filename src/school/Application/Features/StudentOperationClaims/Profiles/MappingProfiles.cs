using Application.Features.StudentOperationClaims.Commands.Create;
using Application.Features.Students.Commands.Create;
using Application.Features.Students.Commands.Delete;
using Application.Features.Students.Commands.Update;
using Application.Features.Students.Queries.GetById;
using Application.Features.Students.Queries.GetList;
using Application.Features.UserOperationClaims.Commands.Create;
using Application.Features.UserOperationClaims.Commands.Delete;
using Application.Features.UserOperationClaims.Commands.Update;
using Application.Features.UserOperationClaims.Queries.GetById;
using Application.Features.UserOperationClaims.Queries.GetList;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.StudentOperationClaims.Profiles;
public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<StudentOperationClaim, CreateStudentOperationClaimCommand>().ReverseMap();
        CreateMap<StudentOperationClaim, CreatedStudentOperationClaimResponse>().ReverseMap();
       
    }
}