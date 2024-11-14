using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

namespace SpaceObject.Entities
{
    public class AsteroidImage
    {
        [Key]
        [SwaggerIgnore]
        public int id { get; set; }
        public string name { get; set; } = null!;
        public string path { get; set; } = null!;

        [SwaggerIgnore]
        public int idAsteroidItem { get; set; }
        [SwaggerIgnore]
        public AsteroidItem? asteroidItem { get; set; }
    }
}
