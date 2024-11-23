using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class StudentOpClaim<TId, TStudentId, TOperationClaimId> : Entity<TId>
{
    public TStudentId StudentId { get; set; }

    public TOperationClaimId OperationClaimId { get; set; }

    public StudentOpClaim()
    {
        StudentId = default(TStudentId);
        OperationClaimId = default(TOperationClaimId);
    }

    public StudentOpClaim(TStudentId studentId, TOperationClaimId operationClaimId)
    {
        StudentId = studentId;
        OperationClaimId = operationClaimId;
    }

    public StudentOpClaim(TId id, TStudentId studentId, TOperationClaimId operationClaimId)
        : base(id)
    {
        StudentId = studentId;
        OperationClaimId = operationClaimId;
    }
}
