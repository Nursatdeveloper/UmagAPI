using System.ComponentModel.DataAnnotations;

namespace UmagAPI.Models {
    public class Supply {
        [Key]
        public int Id { get; set; }
        public long Barcode { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
        public DateTime SupplyTime { get; set; }

    }
}
