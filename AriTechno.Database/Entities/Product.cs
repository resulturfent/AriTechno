namespace AriTechno.Database.Entities;

public class Product
{

    public int Id { get; set; }
    public string Adi { get; set; }
    public decimal Fiyat { get; set; }
    public int Stok { get; set; }
    public string Aciklama { get; set; }
    public DateTime EklemeTarihi { get; set; }
    public int EkleyenId { get; set; }
    public DateTime GuncellemeTarihi { get; set; }
    public int GuncelleyenId { get; set; }
}
