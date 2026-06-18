using AriTechno.Access.Repositories.Interfaces;
using AriTechno.Core.EntityDTOS;
using AriTechno.Service.Services.Interfaces;

namespace AriTechno.Service.Services;

public class SepetService : ISepetService
{

    private readonly IProductRepository _productRepository;

    public SepetService(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public SepetDto SepeteEkle(int urunId)
    {
        List<SepetDto> sepet = new List<SepetDto>();//Mevcut Sepet gibi düşünülecek

        var varmiUrunSepette = sepet.Where(k => k.ProductId == urunId).FirstOrDefault();

        if (varmiUrunSepette == null)
        {
            var sepetUrunu = _productRepository.GetById(urunId);
            return new SepetDto
            {
                ProductId = sepetUrunu.Id,
                Adet = 1,
                EklenmeTarihi = DateTime.Now,
                EkleynId = 1, // Kullanıcı Id'si gelecek
                Fiyat = sepetUrunu.Fiyat,
                Resim = "Resim Url'si gelecek",
                Toplam = sepetUrunu.Fiyat * 1
            };
        }
        else
        {
            varmiUrunSepette.Adet += 1;
            return varmiUrunSepette;
        }




        throw new NotImplementedException();
    }

    public List<SepetDto> SepetList(int userId)
    {
        throw new NotImplementedException();
    }
}
