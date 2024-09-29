using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class Instructor : Entity<Guid>
{
    public string NameSurname { get; set; }
    public string Email { get; set; }
    public string Address { get; set; }
    public string Password { get; set; }
    public string PasswordConfirm { get; set; }
    public ICollection<Course> Courses { get; set; }
    public ICollection<Student> Students { get; set; }
    public string ImageUrl { get; set; }

}
