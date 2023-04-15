using Microsoft.AspNetCore.Mvc;

namespace UmagAPI.Controllers {
    [ApiController]
    [Route("api/supplies")]
    public class SupplyController : ControllerBase {
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] string barcode, DateTime fromTime, DateTime toTime) {
            // retriev from db
            // business logic
            return new JsonResult("Hello1");
        }
    }
}
