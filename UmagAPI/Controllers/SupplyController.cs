using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using UmagAPI.Data;
using UmagAPI.DTOs;
using UmagAPI.Models;

namespace UmagAPI.Controllers {
    [ApiController]
    [Route("api/supplies")]
    public class SupplyController : ControllerBase {
        private readonly ApplicationDbContext _context;
        private readonly IMemoryCache _memoryCache;
        public SupplyController(ApplicationDbContext context, IMemoryCache memoryCache) {
            _context= context;
            _memoryCache= memoryCache;
        }

        [HttpGet]
        public JsonResult Get([FromQuery] long barcode, DateTime fromTime, DateTime toTime) {
            var supplies = _context.TbSupplies
                .ToArray()
                .Where(x => x.Barcode == barcode && x.SupplyTime.InRange(fromTime, toTime))
                .ToList();
            return new JsonResult(supplies);
        }
        [HttpGet("{id}")]
        public async Task<JsonResult> GetById(int id) {
            var supply = await _context.Set<Supply>().FindAsync(id);
            return new JsonResult(supply);
        }

        [HttpPost]
        public async Task<JsonResult> Post([FromBody] CreateSupplyDto createSupplyDto) {
            var supply = new Supply() {
                Barcode = createSupplyDto.Barcode,
                Quantity = createSupplyDto.Quantity,
                Price = createSupplyDto.Price,
                SupplyTime = DateTime.Parse(createSupplyDto.SupplyTime)
            };

            var entity = await _context.Set<Supply>().AddAsync(supply);
            await _context.SaveChangesAsync();

            return new JsonResult(new{ id = entity.Entity.Id });
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Put(int id, [FromBody] UpdateSupplyDto updateSupplyDto) {
            var supply = await _context.TbSupplies.FindAsync(id);
            if(supply != null) {
                supply.Barcode = updateSupplyDto.Barcode;
                supply.Quantity = updateSupplyDto.Quantity;
                supply.Price = updateSupplyDto.Price;
                supply.SupplyTime = DateTime.Parse(updateSupplyDto.SupplyTime);
                _context.TbSupplies.Update(supply);
                _context.SaveChanges();
            }
            return StatusCode(StatusCodes.Status204NoContent);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Delete(int id) {
            var supply = await _context.TbSupplies.FindAsync(id);
            if(supply != null) {
                _context.TbSupplies.Remove(supply);
                _context.SaveChanges();
            }
            return StatusCode(StatusCodes.Status204NoContent);
        }
    }
}
