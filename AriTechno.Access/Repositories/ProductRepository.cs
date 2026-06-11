using AriTechno.Access.Repositories.Interfaces;
using AriTechno.Database;
using AriTechno.Database.Entities;

namespace AriTechno.Access.Repositories;

public class ProductRepository : Repository<Product>, IProductRepository
{
    public ProductRepository(AriTechnoDB ariTechnoDB) : base(ariTechnoDB)
    {

    }
}
