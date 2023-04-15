using System.ComponentModel.DataAnnotations;

namespace UmagAPI.Models {
    public class Sale {
        [Key]
        public long Id { get; set; }
        public string Barcode { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public DateTime Time { get; set; }
    }
}
