using Microsoft.AspNetCore.Mvc;
using OpenAI;
using OpenAI.Images;

namespace SpaceObjectAI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AsteroidImageController : ControllerBase
    {
        private OpenAIClient openAIClient {get; set;}

        public AsteroidImageController(OpenAIClient openAIClient)
        {
            this.openAIClient = openAIClient;
        }

        [HttpGet("asteroid/{asteroidName}", Name = "GetAsteroidImageUrl")]
        public async Task<ActionResult<string>> GetAsteroidImageUrl([FromRoute] string asteroidName)
        {
            ImageGenerationOptions imageGenerationOptions = new ImageGenerationOptions() { 
                Quality = GeneratedImageQuality.Standard, 
                Size = GeneratedImageSize.W1024xH1024, 
                Style = GeneratedImageStyle.Vivid, 
                ResponseFormat = GeneratedImageFormat.Uri,
            };

            CancellationTokenSource cts = new CancellationTokenSource();
            cts.CancelAfter(TimeSpan.FromSeconds(20));

            var imageResponce = await openAIClient.GetImageClient("dall-e-3").GenerateImageAsync($"asteroid {asteroidName}", imageGenerationOptions, cts.Token);
            var url = imageResponce.Value.ImageUri.OriginalString;

            return Ok(url);
        }
    }
}
