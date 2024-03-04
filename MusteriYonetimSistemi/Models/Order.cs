using System.Data.SqlTypes;

namespace MusteriYonetimSistemi.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public double UnitPrice { get; set; }
        public int Quantity { get; set; }
    }
}
