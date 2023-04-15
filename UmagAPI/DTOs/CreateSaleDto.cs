namespace UmagAPI.DTOs {
    public class CreateSaleDto {
        public long Barcode { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
        public DateTime SaleTime { get; set; }
    }
 
    public record UpdateSaleDto(long Barcode, int Quantity, int Price, DateTime SaleTime);
}