using System.ComponentModel.DataAnnotations;

namespace UmagAPI.Models {
    public class Sale {
        [Key]
        public int Id { get; set; }
        public long Barcode { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
        public DateTime SaleTime { get; set; }
        public int Revenue { get; set; }
        public int Profit { get; set; }
    }
}
