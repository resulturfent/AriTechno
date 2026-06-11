using AriTechno.Access.Repositories.Interfaces;
using AriTechno.Database.Entities;
using AriTechno.Service.Services.Interfaces;

namespace AriTechno.Service.Services;

public class ProductService:IProductService
{
    private readonly IRepository<Product> _productRepository;

    public ProductService(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }
    public Product Ekle(Product product)
    {
        try
        {
            Product ekle = new Product();
            ekle.Adi = ekle.Adi;
            ekle.Stok = ekle.Stok;
            ekle.Fiyat = ekle.Fiyat;
            ekle.Aciklama = ekle.Aciklama;
            ekle.CategoryId = ekle.CategoryId;
            _productRepository.Save(ekle);
            return ekle;
        }
        catch (Exception) {

            return null;
        
        }

        

    }


}
