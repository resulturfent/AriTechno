using AriTechno.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AriTechno.Database.Configuration
{
    internal class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn(); 

            builder.Property(x => x.Adi).IsRequired().HasMaxLength(250); // ad zorunlu alan ve maksimum 250 karakter

            builder.Property(x => x.Aciklama).HasMaxLength(500); // MAKSİMUM 500 DEĞER GİRİLİR

            builder.Property(x => x.Fiyat).IsRequired().HasColumnType("decimal(18,2)"); // fiyat zorunlu alan ve para birimi olduğu için 2 ondalık basamak yeterli

            builder.Property(x => x.Stok).IsRequired(); // stok zorunlu alan ürünün mutlaka bir stok değeri olmak zorunda

            builder.HasOne(k => k.Category).WithMany(k => k.Product).HasForeignKey(k => k.CategoryId);
        }
    }
}