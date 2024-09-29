using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class NoteConfiguration : IEntityTypeConfiguration<Note>
{
    public void Configure(EntityTypeBuilder<Note> builder)
    {
        builder.ToTable("Notes").HasKey(n => n.Id);

        builder.Property(n => n.Id).HasColumnName("Id").IsRequired();
        builder.Property(n => n.Value).HasColumnName("Value").IsRequired();
        builder.Property(n => n.StudentId).HasColumnName("StudentId").IsRequired();
        builder.Property(n => n.CourseId).HasColumnName("CourseId").IsRequired();
        builder.Property(n => n.InstructorId).HasColumnName("InstructorId").IsRequired();
        builder.Property(n => n.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(n => n.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(n => n.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(n => !n.DeletedDate.HasValue);
    }
}