using AriTechno.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AriTechno.Database.Configuration
{
    internal class OrderDetailConfiguration : IEntityTypeConfiguration<OrderDetail>
    {
        public void Configure(EntityTypeBuilder<OrderDetail> builder)
        {
            builder.ToTable("OrderDetails");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn(); // id primary key her kayıtta otomatik artıyor

            builder.Property(x => x.Miktar).IsRequired(); // miktar alanı boş geçilemez her siparişin mutlaka bir miktarı olmak zorunda 

            builder.Property(x => x.BirimFiyat).IsRequired().HasColumnType("decimal(18,2)"); // fiyat alanı para birimi olduğu için virgülden sonra 2 basamak yeterli

            builder.HasOne(x => x.Product).WithMany().HasForeignKey(x => x.ProductId);
        }
    }
}
