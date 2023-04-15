using Microsoft.AspNetCore.Mvc;
using UmagAPI.Data;
using UmagAPI.DTOs;
using UmagAPI.Models;

namespace UmagAPI.Controllers {
    [ApiController]
    [Route("api/sales")]
    
    public class SalesController : ControllerBase {
        private readonly ApplicationDbContext _context;
        public SalesController(ApplicationDbContext context) {
            _context= context;
        }

        [HttpGet]
        public JsonResult Get([FromQuery] long barcode, DateTime fromTime, DateTime toTime) {
            var sales = _context.TbSales
                .ToArray()
                .Where(x => x.Barcode == barcode && x.SaleTime.InRange(fromTime, toTime))
                .ToList();
            return new JsonResult(sales);
        }

        [HttpGet("{id}")]
        public async Task<JsonResult> GetById(int id) {
            var sale = await _context.Set<Sale>().FindAsync(id);
            return new JsonResult(sale);
        }

        [HttpPost]
        public async Task<JsonResult> Post([FromBody] CreateSaleDto createSaleDto) {
            var sale = new Sale() {
                Barcode = createSaleDto.Barcode,
                Quantity = createSaleDto.Quantity,
                Price = createSaleDto.Price,
                SaleTime = createSaleDto.SaleTime
            };

            var entity = await _context.Set<Sale>().AddAsync(sale);
            await _context.SaveChangesAsync();

            return new JsonResult(new{ id = entity.Entity.Id });
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Put(int id, [FromBody] UpdateSaleDto updateSaleDto) {
            var sale = await _context.TbSales.FindAsync(id);
            if(sale != null) {
                sale.Barcode = updateSaleDto.Barcode;
                sale.Quantity = updateSaleDto.Quantity;
                sale.Price = updateSaleDto.Price;
                sale.SaleTime = updateSaleDto.SaleTime;
                _context.TbSales.Update(sale);
                _context.SaveChanges();
            }
            return StatusCode(StatusCodes.Status204NoContent);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Delete(int id) {
            var sale = await _context.TbSales.FindAsync(id);
            if(sale != null) {
                _context.TbSales.Remove(sale);
                _context.SaveChanges();
            }
            return StatusCode(StatusCodes.Status204NoContent);
        }
    }
}
