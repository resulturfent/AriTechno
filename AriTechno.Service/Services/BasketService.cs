using AriTechno.Access.Repositories.Interfaces;
using AriTechno.Core.EntityDTOS;
using AriTechno.Service.Services.Interfaces;

namespace AriTechno.Service.Services;

public class BasketService : IBasketService
{

    private readonly IProductRepository _productRepository;
    private IBasketRepository _basketRepository;

    public BasketService(IProductRepository productRepository, IBasketRepository basketRepository)
    {
        _productRepository = productRepository;
        _basketRepository = basketRepository;
    }

    public SepetDto SepeteEkle(SepetDto sepetDto)
    {
        List<SepetDto> sepet = new List<SepetDto>();//Mevcut Sepet gibi düşünülecek

        var varmiUrunSepette = sepet.Where(k => k.ProductId == sepetDto.ProductId).FirstOrDefault();

        if (varmiUrunSepette == null)
        {
            //Mapping işlemi yapılacak=> Mapper kullanılabilir
            _basketRepository.Save(new Database.Entities.Basket
            {
                Id = sepetDto.ProductId,
                UnitCount = sepetDto.Adet,
                AddedDate = sepetDto.EklenmeTarihi,
                UserId = sepetDto.EkleynId,
                Price= sepetDto.Fiyat,
                //Resimm = sepetDto.Resim
            });
            return sepetDto;
        }
        else
        {
           var getirUrun= _basketRepository.GetById(varmiUrunSepette.ProductId);

            getirUrun.UnitCount += 1;//Adet +1 yapılacak
            _basketRepository.Update(getirUrun);//artırılan adet DB de güncellenecek

            return varmiUrunSepette;
        }

    }

    public List<SepetDto> SepetList(int userId)
    {
        throw new NotImplementedException();
    }
}
