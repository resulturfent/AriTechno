namespace AriTechno.Database.Entities
{
    public class Product
    {
        public int Id { get; set; } //PK 
        public string Adi { get; set; } //bir ürün eklerken adı yazmak zorundayız
        public string? Aciklama { get; set; } // boş bırakılabilir
        public decimal Fiyat { get; set; }
        public int Stok { get; set; }


        public int CategoryId { get; set; }


        public Category Category { get; set; }
    }
}