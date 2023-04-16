using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UmagAPI.Data;
using UmagAPI.DTOs;

namespace UmagAPI.Controllers { 
    [ApiController]
    [Route("api/reports")]
    public class ReportsController : ControllerBase {
        private readonly ApplicationDbContext _context;
        public ReportsController(ApplicationDbContext context) {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] long barcode, DateTime fromTime, DateTime toTime) {
            var sales = _context.TbSales.ToArray()
                .Where(x => x.Barcode == barcode && x.SaleTime.InRange(fromTime, toTime))
                .ToArray();

            var revenueDto = new RevenueDto() {
                Barcode = barcode,
                Quantity = sales.Sum(x => x.Quantity),
                NetProfit = sales.Sum(x => x.Profit),
                Revenue = sales.Sum(x => x.Revenue)
            };
            return new JsonResult(revenueDto);

        }
    }
}
