using AriTechno.Database.Entities;

namespace AriTechno.Service.Services.Interfaces;

public interface ICategoryService
{

    public bool Save(Category category);
    public bool Update(Category category);

    public bool Delete(int id);

    public List<Category> GetAll();

    public Category GetById(int id);

    public int ProductCount(int categoryId);

}
