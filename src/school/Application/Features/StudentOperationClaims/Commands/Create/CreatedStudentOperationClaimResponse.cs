using NArchitecture.Core.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.StudentOperationClaims.Commands.Create;
public class CreatedStudentOperationClaimResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid StudentId { get; set; }
    public int OperationClaimId { get; set; }
}
