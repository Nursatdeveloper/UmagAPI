using System.ComponentModel.DataAnnotations;

namespace UmagAPI.Models {
    public class Supply {
        [Key]
        public long Id { get; set; }
        public string Barcode { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public DateTime Time { get; set; }

        public Supply(string barcode, int quantity, decimal price, DateTime time) {
            Barcode= barcode;
            Quantity= quantity;
            Price= price;
            Time= time;
        }
    }
}
