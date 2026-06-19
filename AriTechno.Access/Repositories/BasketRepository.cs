using AriTechno.Access.Repositories.Interfaces;
using AriTechno.Database;
using AriTechno.Database.Entities;

namespace AriTechno.Access.Repositories;

public class BasketRepository : Repository<Basket>, IBasketRepository
{
    public BasketRepository(AriTechnoDB ariTechnoDB) : base(ariTechnoDB)
    {
    }
}
