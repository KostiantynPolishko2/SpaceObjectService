using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SpaceObject.Entities;

namespace SpaceObject.EF
{
    public class AsteroidImageConfig : IEntityTypeConfiguration<AsteroidImage>
    {
        public void Configure(EntityTypeBuilder<AsteroidImage> builder)
        {
            builder.ToTable("asteroid_images").HasKey(am => am.id);
            builder.Property(am => am.idAsteroidItem).HasColumnName("FK_IdAsteroidItem");
            builder.HasIndex(am => am.idAsteroidItem).IsUnique().HasDatabaseName("IX_AsteroidImage_idAsteroidItem");
        }
    }
}
