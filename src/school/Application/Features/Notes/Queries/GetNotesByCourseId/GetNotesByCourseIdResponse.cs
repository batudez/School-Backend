using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Notes.Queries.GetNotesByCourseId;
public class GetNotesByCourseIdResponse
{
    public Guid StudentId { get; set; }
    public StudentDto Student { get; set; }
    public int Value { get; set; }
}
