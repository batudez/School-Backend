using Application.Features.Notes.Commands.Update;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Notes.Commands.UpdateGrades;
public class UpdatedGradesResponse
{
    public List<UpdatedNoteResponse> UpdatedNotes { get; set; }
}