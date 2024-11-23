using Application.Features.Auth.Constants;
using Application.Features.OperationClaims.Constants;
using Application.Features.UserOperationClaims.Constants;
using Application.Features.Users.Constants;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NArchitecture.Core.Security.Constants;
using Application.Features.Students.Constants;
using Application.Features.Courses.Constants;
using Application.Features.Announcements.Constants;
using Application.Features.Instructors.Constants;
using Application.Features.Notes.Constants;
using Application.Features.Students.Constants;
using Application.Features.Students.Constants;
using Application.Features.Students.Constants;
using Application.Features.Students.Constants;










namespace Persistence.EntityConfigurations;

public class OperationClaimConfiguration : IEntityTypeConfiguration<OperationClaim>
{
    public void Configure(EntityTypeBuilder<OperationClaim> builder)
    {
        builder.ToTable("OperationClaims").HasKey(oc => oc.Id);

        builder.Property(oc => oc.Id).HasColumnName("Id").IsRequired();
        builder.Property(oc => oc.Name).HasColumnName("Name").IsRequired();
        builder.Property(oc => oc.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(oc => oc.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(oc => oc.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(oc => !oc.DeletedDate.HasValue);

        builder.HasData(_seeds);

        builder.HasBaseType((string)null!);
    }

    public static int AdminId => 1;
    private IEnumerable<OperationClaim> _seeds
    {
        get
        {
            yield return new() { Id = AdminId, Name = GeneralOperationClaims.Admin };

            IEnumerable<OperationClaim> featureOperationClaims = getFeatureOperationClaims(AdminId);
            foreach (OperationClaim claim in featureOperationClaims)
                yield return claim;
        }
    }

#pragma warning disable S1854 // Unused assignments should be removed
    private IEnumerable<OperationClaim> getFeatureOperationClaims(int initialId)
    {
        int lastId = initialId;
        List<OperationClaim> featureOperationClaims = new();

        #region Auth
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = AuthOperationClaims.Admin },
                new() { Id = ++lastId, Name = AuthOperationClaims.Read },
                new() { Id = ++lastId, Name = AuthOperationClaims.Write },
                new() { Id = ++lastId, Name = AuthOperationClaims.RevokeToken },
            ]
        );
        #endregion

        #region OperationClaims
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = OperationClaimsOperationClaims.Admin },
                new() { Id = ++lastId, Name = OperationClaimsOperationClaims.Read },
                new() { Id = ++lastId, Name = OperationClaimsOperationClaims.Write },
                new() { Id = ++lastId, Name = OperationClaimsOperationClaims.Create },
                new() { Id = ++lastId, Name = OperationClaimsOperationClaims.Update },
                new() { Id = ++lastId, Name = OperationClaimsOperationClaims.Delete },
            ]
        );
        #endregion

        #region UserOperationClaims
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = UserOperationClaimsOperationClaims.Admin },
                new() { Id = ++lastId, Name = UserOperationClaimsOperationClaims.Read },
                new() { Id = ++lastId, Name = UserOperationClaimsOperationClaims.Write },
                new() { Id = ++lastId, Name = UserOperationClaimsOperationClaims.Create },
                new() { Id = ++lastId, Name = UserOperationClaimsOperationClaims.Update },
                new() { Id = ++lastId, Name = UserOperationClaimsOperationClaims.Delete },
            ]
        );
        #endregion

        #region Users
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = UsersOperationClaims.Admin },
                new() { Id = ++lastId, Name = UsersOperationClaims.Read },
                new() { Id = ++lastId, Name = UsersOperationClaims.Write },
                new() { Id = ++lastId, Name = UsersOperationClaims.Create },
                new() { Id = ++lastId, Name = UsersOperationClaims.Update },
                new() { Id = ++lastId, Name = UsersOperationClaims.Delete },
            ]
        );
        #endregion

        
        #region Students CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = StudentsOperationClaims.Admin },
                new() { Id = ++lastId, Name = StudentsOperationClaims.Read },
                new() { Id = ++lastId, Name = StudentsOperationClaims.Write },
                new() { Id = ++lastId, Name = StudentsOperationClaims.Create },
                new() { Id = ++lastId, Name = StudentsOperationClaims.Update },
                new() { Id = ++lastId, Name = StudentsOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region Courses CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = CoursesOperationClaims.Admin },
                new() { Id = ++lastId, Name = CoursesOperationClaims.Read },
                new() { Id = ++lastId, Name = CoursesOperationClaims.Write },
                new() { Id = ++lastId, Name = CoursesOperationClaims.Create },
                new() { Id = ++lastId, Name = CoursesOperationClaims.Update },
                new() { Id = ++lastId, Name = CoursesOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region Announcements CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = AnnouncementsOperationClaims.Admin },
                new() { Id = ++lastId, Name = AnnouncementsOperationClaims.Read },
                new() { Id = ++lastId, Name = AnnouncementsOperationClaims.Write },
                new() { Id = ++lastId, Name = AnnouncementsOperationClaims.Create },
                new() { Id = ++lastId, Name = AnnouncementsOperationClaims.Update },
                new() { Id = ++lastId, Name = AnnouncementsOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region Instructors CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = InstructorsOperationClaims.Admin },
                new() { Id = ++lastId, Name = InstructorsOperationClaims.Read },
                new() { Id = ++lastId, Name = InstructorsOperationClaims.Write },
                new() { Id = ++lastId, Name = InstructorsOperationClaims.Create },
                new() { Id = ++lastId, Name = InstructorsOperationClaims.Update },
                new() { Id = ++lastId, Name = InstructorsOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region Notes CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = NotesOperationClaims.Admin },
                new() { Id = ++lastId, Name = NotesOperationClaims.Read },
                new() { Id = ++lastId, Name = NotesOperationClaims.Write },
                new() { Id = ++lastId, Name = NotesOperationClaims.Create },
                new() { Id = ++lastId, Name = NotesOperationClaims.Update },
                new() { Id = ++lastId, Name = NotesOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region Students CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = StudentsOperationClaims.Admin },
                new() { Id = ++lastId, Name = StudentsOperationClaims.Read },
                new() { Id = ++lastId, Name = StudentsOperationClaims.Write },
                new() { Id = ++lastId, Name = StudentsOperationClaims.Create },
                new() { Id = ++lastId, Name = StudentsOperationClaims.Update },
                new() { Id = ++lastId, Name = StudentsOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region Students CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = StudentsOperationClaims.Admin },
                new() { Id = ++lastId, Name = StudentsOperationClaims.Read },
                new() { Id = ++lastId, Name = StudentsOperationClaims.Write },
                new() { Id = ++lastId, Name = StudentsOperationClaims.Create },
                new() { Id = ++lastId, Name = StudentsOperationClaims.Update },
                new() { Id = ++lastId, Name = StudentsOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region Students CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = StudentsOperationClaims.Admin },
                new() { Id = ++lastId, Name = StudentsOperationClaims.Read },
                new() { Id = ++lastId, Name = StudentsOperationClaims.Write },
                new() { Id = ++lastId, Name = StudentsOperationClaims.Create },
                new() { Id = ++lastId, Name = StudentsOperationClaims.Update },
                new() { Id = ++lastId, Name = StudentsOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region Students CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = StudentsOperationClaims.Admin },
                new() { Id = ++lastId, Name = StudentsOperationClaims.Read },
                new() { Id = ++lastId, Name = StudentsOperationClaims.Write },
                new() { Id = ++lastId, Name = StudentsOperationClaims.Create },
                new() { Id = ++lastId, Name = StudentsOperationClaims.Update },
                new() { Id = ++lastId, Name = StudentsOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        featureOperationClaims.Add(new() { Id = ++lastId, Name = StudentsOperationClaims.GetByEmailStudent });
        
        featureOperationClaims.Add(new() { Id = ++lastId, Name = NotesOperationClaims.GetNotesByStudentId });
        return featureOperationClaims;
    }
#pragma warning restore S1854 // Unused assignments should be removed
}
