using System.Diagnostics.Eventing.Reader;

namespace UmagAPI.DTOs {
    public class RevenueDto {
        public long Barcode { get; set; }
        public int Quantity { get; set; }
        public int Revenue { get; set; }
        public int NetProfit { get; set; }
    }
}
