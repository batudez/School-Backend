using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class Course : Entity<Guid>
{
    public  Instructor Instructor { get; set; }
    public Guid InstructorId { get; set; }
    public ICollection<Student> Students { get; set; }
    public string CourseName { get; set; }
    public string CourseCode { get; set; }
    public bool AttendanceObligation { get; set; }
    public ICollection<Note> Notes { get; set; }
}
