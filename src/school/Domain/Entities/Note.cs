using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class Note : Entity<Guid>
{
    public int Value { get; set; }
    public  Student Student { get; set; }
    public Guid StudentId { get; set; }
    public  Course Course { get; set; }
    public Guid CourseId { get; set; }
    public Instructor Instructor  { get; set; }
    public Guid InstructorId { get; set; }
}
