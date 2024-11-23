using Application.Features.Notes.Commands.Create;
using Application.Features.Notes.Commands.Delete;
using Application.Features.Notes.Commands.Update;
using Application.Features.Notes.Queries.GetById;
using Application.Features.Notes.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;
using Application.Features.Notes.Queries.GetNotesByStudentId;
using Application.Features.Notes.Commands.UpdateGrades;
using Application.Features.Notes.Queries.GetNotesByCourseId;

namespace Application.Features.Notes.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateNoteCommand, Note>();
        CreateMap<Note, CreatedNoteResponse>();

        CreateMap<UpdateNoteCommand, Note>();
        CreateMap<Note, UpdatedNoteResponse>();

        CreateMap<StudentGradeUpdateDto, Note>().ReverseMap();
        CreateMap<UpdateGradesCommand, Note>().ReverseMap();

        CreateMap<Course,CourseDto>().ReverseMap();
        CreateMap<Student,StudentDto>().ReverseMap();

       // CreateMap<Note, GetListNoteListItemDto>()
        //   .ForMember(dest => dest.CourseCode, opt => opt.MapFrom(src => src.Course.CourseCode));

        CreateMap<DeleteNoteCommand, Note>();
        CreateMap<Note, DeletedNoteResponse>();

        CreateMap<Note,GetNotesByStudentIdResponse>().ReverseMap();
        CreateMap<Note, GetNotesByCourseIdResponse>().ReverseMap();

        //CreateMap<Note, GetNotesByCourseIdResponse>()
       //    .ForMember(dest => dest.Student, opt => opt.MapFrom(src => src.Student)); // Doðru map yapýldýðýndan emin olun.

       // CreateMap<Student, StudentDto>()
           // .ForMember(dest => dest.NameSurname, opt => opt.MapFrom(src => src.NameSurname)); // Öðrenci isminin doðru eþlendiðinden emin olun.


        CreateMap<Note, GetByIdNoteResponse>();

        CreateMap<Note, GetListNoteListItemDto>();
        CreateMap<IPaginate<Note>, GetListResponse<GetListNoteListItemDto>>();
    }
}