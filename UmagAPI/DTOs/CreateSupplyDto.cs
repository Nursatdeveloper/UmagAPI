namespace UmagAPI.DTOs {
    public class CreateSupplyDto {
        public long Barcode { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
        public DateTime Time { get; set; }
    }
}
