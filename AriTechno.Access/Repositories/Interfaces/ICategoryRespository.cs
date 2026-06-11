using AriTechno.Database.Entities;

namespace AriTechno.Access.Repositories.Interfaces;

public interface ICategoryRespository:IRepository<Category>
{
    public int ProductCount(int categoryId);

}
