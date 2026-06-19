namespace AriTechno.Database.Entities;

public class Basket
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public int  UnitCount { get; set; }
    public decimal Price { get; set; }
    public int UserId { get; set; }
    public DateTime AddedDate { get; set; }
}
