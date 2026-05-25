using System;
using System.Collections.Generic;
using System.Text;

namespace AriTechno.Database.Entities
{
    public class Order
    {
        public int Id { get; set; } //PK
        public DateTime Tarih { get; set; }
        public string? MusteriAdi { get; set; }
        public decimal ToplamTutar { get; set; }

        public ICollection<OrderDetail> OrderDetail { get; set; }
    }
}
