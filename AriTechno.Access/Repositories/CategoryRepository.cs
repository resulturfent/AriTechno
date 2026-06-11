using AriTechno.Access.Repositories.Interfaces;
using AriTechno.Database;
using AriTechno.Database.Entities;

namespace AriTechno.Access.Repositories;

public class CategoryRepository : Repository<Category>,ICategoryRespository
{
    public CategoryRepository(AriTechnoDB ariTechnoDB) : base(ariTechnoDB)
    {
    }

    public int ProductCount(int categoryId)
    {
        throw new NotImplementedException();
    }
}
