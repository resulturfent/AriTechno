using AriTechno.Core.EntityDTOS;

namespace AriTechno.Service.Services.Interfaces;

public interface IBasketService
{
    public SepetDto SepeteEkle(SepetDto sepetDto);
    public List<SepetDto> SepetList(int userId);
}
