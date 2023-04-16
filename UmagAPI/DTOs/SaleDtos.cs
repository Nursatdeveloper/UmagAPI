namespace UmagAPI.DTOs {
    public class CreateSaleDto {
        public long Barcode { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
        public string SaleTime { get; set; }
    }

    public class UpdateSaleDto {
        public long Barcode { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
        public string SaleTime { get; set; }
    }
}