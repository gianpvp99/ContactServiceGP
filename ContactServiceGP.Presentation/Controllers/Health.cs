using Microsoft.AspNetCore.Mvc;

namespace ContactServiceGP.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class Health : ControllerBase
    {
        /// <summary>
        /// Endpoint de prueba para verificar que el servidor está activo
        /// </summary>
        [HttpGet("status")]
        public IActionResult GetStatus()
        {
            return Ok(new
            {
                message = "Servidor activo ✅",
                timestamp = DateTime.UtcNow,
                version = "1.0.0",
                environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")
            });
        }

        /// <summary>
        /// Ping simple para verificar conectividad
        /// </summary>
        [HttpGet("ping")]
        public IActionResult Ping()
        {
            return Ok("pong");
        }

        /// <summary>
        /// Información de la aplicación
        /// </summary>
        [HttpGet("info")]
        public IActionResult GetInfo()
        {
            return Ok(new
            {
                app = "ContactServiceGP",
                framework = ".NET 8",
                timestamp = DateTime.UtcNow
            });
        }
    }
}
