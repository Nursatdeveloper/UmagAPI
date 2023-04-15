namespace UmagAPI.DTOs {
    public class CreateSupplyDto {
        public string Barcode { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public DateTime Time { get; set; }
    }
}
