namespace UmagAPI.DTOs {
    public class CreateSupplyDto {
        public long Barcode { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
        public string SupplyTime { get; set; }
    }

    public class UpdateSupplyDto {
        public long Barcode { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
        public string SupplyTime { get; set; }
    }

}
