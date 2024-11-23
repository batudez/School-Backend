using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class StudentConfiguration : IEntityTypeConfiguration<Student>
{
    public void Configure(EntityTypeBuilder<Student> builder)
    {
        builder.ToTable("Students").HasKey(s => s.Id);

        builder.Property(s => s.Id).HasColumnName("Id").IsRequired();
        builder.Property(s => s.NameSurname).HasColumnName("NameSurname").IsRequired();
        builder.Property(s => s.Email).HasColumnName("Email").IsRequired();
        builder.Property(s => s.TelephoneNumber).HasColumnName("TelephoneNumber").IsRequired();
        builder.Property(s => s.Address).HasColumnName("Address").IsRequired();
        builder.Property(s => s.Password).HasColumnName("Password").IsRequired();
        builder.Property(s => s.PasswordConfirm).HasColumnName("PasswordConfirm").IsRequired();
        builder.Property(s => s.ImageUrl).HasColumnName("ImageUrl").IsRequired();
        builder.Property(s => s.UserId).HasColumnName("UserId").IsRequired();
        builder.Property(s => s.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(s => s.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(s => s.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(s => !s.DeletedDate.HasValue);
    }
}