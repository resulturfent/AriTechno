using AriTechno.Database.Entities;

namespace AriTechno.Service.Services.Interfaces;

public interface IProductService
{
    List<Product> GetAll();
    Product GetById(int id);
    Product Save(Product product);
    Product Update(Product product);
    bool Delete(int id);

}

