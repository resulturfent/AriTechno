using AriTechno.Database.Entities;

namespace AriTechno.Service.Services.Interfaces;

public interface IProductService
{
    public bool Save(Product product);
    public bool Update(Product product);
    public bool Delete(int id);
    public List<Product> GetAll();
    public Product GetById(int id);
}

