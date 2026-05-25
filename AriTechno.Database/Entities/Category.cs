namespace AriTechno.Database.Entities;

public class Category
{
    public int Id { get; set; } //PK
    public string Adi { get; set; }
    public string Aciklama { get; set; }

    public ICollection<Product> Product { get; set; }
}
