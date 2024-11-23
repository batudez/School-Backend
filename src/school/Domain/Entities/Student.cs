using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class Student : Entity<Guid>
{
    public string NameSurname { get; set; }
    public string Email { get; set; }
    public string TelephoneNumber { get; set; }
    public string Address { get; set; }
    public string Password { get; set; }
    public string PasswordConfirm { get; set; }
    public string ImageUrl { get; set; }
    public Guid UserId { get; set; }
    public ICollection<Course> TakingCourses { get; set; }
    public ICollection<Note> Notes { get; set; }
    public ICollection<Instructor> Instructors { get; set; }
    public virtual ICollection<StudentOperationClaim> StudentOperationClaims { get; set; } = default!;

}
