using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using POS.Domain.Entities;

namespace POS.Infrastructure.Persistences.Context.Configurations
{
    public class PurcharseDetailConfiguration : IEntityTypeConfiguration<PurcharseDetail>
    {
        public void Configure(EntityTypeBuilder<PurcharseDetail> builder)
        {
            builder.HasKey(e => e.PurcharseDetailId).HasName("PK__Purchars__7353248BF48EB7C4");

            builder.Property(e => e.Price).HasColumnType("decimal(18, 2)");

            builder.HasOne(d => d.Product).WithMany(p => p.PurcharseDetails)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK__Purcharse__Produ__656C112C");

            builder.HasOne(d => d.Purcharse).WithMany(p => p.PurcharseDetails)
                .HasForeignKey(d => d.PurcharseId)
                .HasConstraintName("FK__Purcharse__Purch__66603565");
        }
    }
}
