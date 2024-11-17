namespace SpaceObjectAI.Infrastructures
{
    public class AsteroidImageException : Exception
    {
        public string property { get; } = null!;

        public AsteroidImageException(string message, string property) 
        { 
            this.property = property;
        }
    }
}
