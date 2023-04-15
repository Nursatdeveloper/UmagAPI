namespace UmagAPI.DTOs {
    public class CreateSupplyDto {
        public long Barcode { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
        public DateTime SupplyTime { get; set; }
    }

    public record UpdateSupplyDto(long Barcode, int Quantity, int Price, DateTime SupplyTime);
}
