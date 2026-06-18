namespace AriTechno.Core.EntityDTOS;

public class SepetDto
{
    public int ProductId { get; set; }
    public int Adet { get; set; }
    public decimal Fiyat { get; set; }
    public DateTime EklenmeTarihi { get; set; }
    public int EkleynId { get; set; }
    public string Resim { get; set; }
    public decimal Toplam { get; set; }
}
