using System;
using System.Collections.Generic;
using System.Text;

namespace AriTechno.Database.Entities
{
    public class OrderDetail
    {
        public int Id { get; set; } //PK
        public int Miktar { get; set; } // null olamaz, CS8618 uyarısı verir
        public decimal BirimFiyat { get; set; }

        public int OrderId { get; set; }
        public Order? Order { get; set; } // null olabilir, hata vermez

        public int ProductId { get; set; }
        public Product? Product { get; set; } // null olabilir - ? - anlamı product? - 
    }
}
