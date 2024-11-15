using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using OpenAI;
using OpenAI.Images;
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

        [HttpGet("asteroid/{asteroidName}", Name = "GetAsteroidImageUrl")]
        public async Task<ActionResult<string>> GetAsteroidImageUrl([FromRoute] string asteroidName)
        {
            try
            {
                return await asteroidImageRepository.getUrl(asteroidName);
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
