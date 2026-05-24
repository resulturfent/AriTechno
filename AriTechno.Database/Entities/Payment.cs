

namespace AriTechno.Database.Entities
{
    public class Payment
    {
        public int Id { get; set; }

        public string TeslimatAdresi { get; set; }

        public string OdemeSecenekleri { get; set; }

        public int KartNo {get; set; }

        public DateTime  KartSonTarih {  get; set; }

        public int CVC {get; set; }        

        public string TaksitSecenekleri { get; set; }

    }
}
