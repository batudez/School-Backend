using NArchitecture.Core.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Notes.Queries.GetNotesByCourseId;
public class StudentDto : IDto
{
    public string NameSurname { get; set; }

}
