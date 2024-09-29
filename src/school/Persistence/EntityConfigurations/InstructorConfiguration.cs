using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class InstructorConfiguration : IEntityTypeConfiguration<Instructor>
{
    public void Configure(EntityTypeBuilder<Instructor> builder)
    {
        builder.ToTable("Instructors").HasKey(i => i.Id);

        builder.Property(i => i.Id).HasColumnName("Id").IsRequired();
        builder.Property(i => i.NameSurname).HasColumnName("NameSurname").IsRequired();
        builder.Property(i => i.Email).HasColumnName("Email").IsRequired();
        builder.Property(i => i.Address).HasColumnName("Address").IsRequired();
        builder.Property(i => i.Password).HasColumnName("Password").IsRequired();
        builder.Property(i => i.PasswordConfirm).HasColumnName("PasswordConfirm").IsRequired();
        builder.Property(i => i.ImageUrl).HasColumnName("ImageUrl").IsRequired();
        builder.Property(i => i.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(i => i.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(i => i.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(i => !i.DeletedDate.HasValue);
    }
}