using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using SpaceObjectAI.Infrastructures;
using SpaceObjectAI.Interfaces;

namespace SpaceObjectAI.Controllers
{
    [EnableCors("AllowAll")]
    [Route("api/[controller]")]
    [ApiController]
    public class AsteroidImageController : ControllerBase
    {
        private readonly ILogger<AsteroidImageController> logger;
        private readonly IAsteroidImageRepository asteroidImageRepository;

        public AsteroidImageController(ILogger<AsteroidImageController> logger, IAsteroidImageRepository asteroidImageRepository)
        {
            this.logger = logger;
            this.asteroidImageRepository = asteroidImageRepository;
        }

        [HttpGet("asteroid-image/{asteroidName}", Name = "GetAsteroidImageUrl")]
        public async Task<ActionResult<string>> GetAsteroidImageUrl([FromRoute] string asteroidName)
        {
            string name = asteroidName.ToLower();
            
            try
            {
                return await asteroidImageRepository.getUrl(asteroidName);
                //return "https://docfiles.blob.core.windows.net/files/asteroid/asteroid.png";
            }
            catch (AsteroidImageException ex){
                return NotFound($"Error! msg: {ex.Message} {ex.property}, source: {ex.Source}");
            }
            catch (Exception ex) {
                return BadRequest($"Error! msg: {ex.Message}, details: {ex.InnerException}");
            }
        }
    }
}
