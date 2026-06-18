using AriTechno.Core.EntityDTOS;

namespace AriTechno.Service.Services.Interfaces;

public interface ISepetService
{
    public SepetDto SepeteEkle(int urunId);
    public List<SepetDto> SepetList(int userId);
}
