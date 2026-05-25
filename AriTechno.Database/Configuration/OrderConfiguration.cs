using AriTechno.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AriTechno.Database.Configuration
{
    internal class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Orders");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();

            builder.Property(x => x.MusteriAdi).IsRequired().HasMaxLength(250);

            builder.Property(x => x.Tarih).IsRequired();

            builder.Property(x => x.ToplamTutar).IsRequired().HasColumnType("decimal(18,2)");

            builder.HasOne(x => x.OrderDetail).WithOne(x => x.Order).HasForeignKey<OrderDetail>(x => x.OrderId);
        }
    }
}