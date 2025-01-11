using SQLite;

namespace DealershipAudiMobile.Models
{
    public class Sale
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        public int CarID { get; set; }
        public int CustomerID { get; set; }
        public DateTime SaleDate { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
