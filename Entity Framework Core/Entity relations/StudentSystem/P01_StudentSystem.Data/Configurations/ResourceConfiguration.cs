namespace P01_StudentSystem.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using P01_StudentSystem.Data.Models;

    public class ResourceConfiguration : IEntityTypeConfiguration<Resource>
    {
        public void Configure(EntityTypeBuilder<Resource> resource)
        {
            resource
                 .HasKey(k => k.ResourceId);

            resource
                .Property(p => p.Name)
                .HasMaxLength(50)
                .IsRequired(true)
                .IsUnicode(true);

            resource
                .Property(p => p.Url)
                .IsUnicode(false)
                .IsRequired(false);

            resource
                .Property(p => p.ResourceType)
                .IsRequired(true);

            resource
             .HasOne(c => c.Course)
             .WithMany(r => r.Resources)
             .HasForeignKey(fk => fk.CourseId);
        }
    }
}
