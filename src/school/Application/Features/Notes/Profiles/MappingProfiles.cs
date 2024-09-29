using Application.Features.Notes.Commands.Create;
using Application.Features.Notes.Commands.Delete;
using Application.Features.Notes.Commands.Update;
using Application.Features.Notes.Queries.GetById;
using Application.Features.Notes.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.Notes.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateNoteCommand, Note>();
        CreateMap<Note, CreatedNoteResponse>();

        CreateMap<UpdateNoteCommand, Note>();
        CreateMap<Note, UpdatedNoteResponse>();

        CreateMap<DeleteNoteCommand, Note>();
        CreateMap<Note, DeletedNoteResponse>();

        CreateMap<Note, GetByIdNoteResponse>();

        CreateMap<Note, GetListNoteListItemDto>();
        CreateMap<IPaginate<Note>, GetListResponse<GetListNoteListItemDto>>();
    }
}