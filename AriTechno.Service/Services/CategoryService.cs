using AriTechno.Access.Repositories.Interfaces;
using AriTechno.Database.Entities;
using AriTechno.Service.Services.Interfaces;

namespace AriTechno.Service.Services;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRespository _categoryRespository;//DI

    public CategoryService(ICategoryRespository categoryRespository)
    {
        _categoryRespository = categoryRespository;
    }

    public bool Delete(int id)
    {
        throw new NotImplementedException();
    }

    public List<Category> GetAll()
    {
        return _categoryRespository.GetAll();
    }

    public Category GetById(int id)
    {
        throw new NotImplementedException();
    }

    public int ProductCount(int categoryId)
    {
        throw new NotImplementedException();
    }

    public bool Save(Category category)
    {
        try
        {
            Category ekle = new Category();
            ekle.Adi = category.Adi;
            ekle.Aciklama = category.Aciklama;
            _categoryRespository.Save(ekle);
            return true;
        }
        catch (Exception)
        {
            return false;
        }


    }

    public bool Update(Category category)
    {
        throw new NotImplementedException();
    }
}
