using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Instructors.Queries.GetByEmail;
public class GetByEmailInstructorResponse
{
    public Guid Id { get; set; }
    public string NameSurname { get; set; }
    public string Email { get; set; }
}
