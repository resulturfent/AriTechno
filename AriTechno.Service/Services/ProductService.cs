using AriTechno.Access.Repositories;
using AriTechno.Access.Repositories.Interfaces;
using AriTechno.Database.Entities;
using AriTechno.Service.Services.Interfaces;

namespace AriTechno.Service.Services;

public class ProductService : IProductService

{
    private readonly IProductRepository _productRepository;
    public ProductService(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }
    public bool Delete(int id)
    {
        throw new NotImplementedException();
    }

    public List<Product> GetAll()
    {
        return _productRepository.GetAll();
    }

    public Product GetById(int id)
    {
        return _productRepository.GetById(id);
    }

    public bool Save(Product product)
    {
        throw new NotImplementedException();
    }

    public Product Kaydet(Product product)
    {
        try
        {
            _productRepository.Save(product);
            return product;
        }
        catch(Exception) 
        {
                return null;

        }
    }
    public bool Update(Category category)
    {
        throw new NotImplementedException();
    }

    public bool Update(Product product)
    {
        throw new NotImplementedException();
    }
}