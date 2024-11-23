using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class StudentOperationClaim : StudentOpClaim<Guid, Guid, int>
{
    public virtual Student Student { get; set; } = default!;
    public virtual OperationClaim OperationClaim { get; set; } = default!;
}
