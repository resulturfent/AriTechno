using AriTechno.Core.EntityDTOS;
using AriTechno.Database.Entities;

namespace AriTechno.Service.Services.Interfaces;

public interface IBasketService
{
    SepetDto SepeteEkle(SepetDto sepetDto);
    List<SepetDto> SepetList(int userId);
    SepetDto GetById(int urunId);
    SepetDto Update(SepetDto basket);
}
