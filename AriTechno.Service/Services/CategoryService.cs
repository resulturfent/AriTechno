using AriTechno.Access.Repositories.Interfaces;
using AriTechno.Database.Entities;
using AriTechno.Service.Services.Interfaces;

namespace AriTechno.Service.Services;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;

    public CategoryService(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;

    }
    public bool Delete(int id)
    {
        throw new NotImplementedException();
    }

    public List<Category> GetAll()
    {
        return _categoryRepository.GetAll();
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
        throw new NotImplementedException();
    }
    public Category Ekle(Category category)
    {
        try
        {
            Category ekle = new Category();


            ekle.Adi = category.Adi;
            ekle.Aciklama = category.Aciklama;


            _categoryRepository.Save(ekle);
            return ekle;
        }
        catch (Exception)
        {

            return null;

        }
    }

    public Category Guncelle(Category category)
    {

        try
        {
            Category guncelle = new Category();
            if (guncelle == null)
            {
                return null;
            }

            guncelle.Adi = guncelle.Adi;
            guncelle.Aciklama = guncelle.Aciklama;
            _categoryRepository.Update(guncelle);
            return guncelle;
        }
        catch (Exception)
        {
            return null;
        }

    }

    public bool Update(Category category)
    {
        throw new NotImplementedException();
    }
}
