using Microsoft.AspNetCore.Mvc;
using UmagAPI.Data;
using UmagAPI.DTOs;
using UmagAPI.Models;

namespace UmagAPI.Controllers {
    [ApiController]
    [Route("api/supplies")]
    public class SupplyController : ControllerBase {
        private readonly ApplicationDbContext _context;
        public SupplyController(ApplicationDbContext context) {
            _context= context;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] string barcode, DateTime fromTime, DateTime toTime) {
            // retriev from db
            // business logic
            return new JsonResult("Hello");
        }

        [HttpPost]
        public async Task<JsonResult> Post([FromBody] CreateSupplyDto createSupplyDto) {
            var supply = new Supply(
                createSupplyDto.Barcode,
                createSupplyDto.Quantity,
                createSupplyDto.Price,
                createSupplyDto.Time
            );

            var entity = await _context.Set<Supply>().AddAsync(supply);
            await _context.SaveChangesAsync();

            return new JsonResult(new{ id = entity.Entity.Id });
        }
    }
}
