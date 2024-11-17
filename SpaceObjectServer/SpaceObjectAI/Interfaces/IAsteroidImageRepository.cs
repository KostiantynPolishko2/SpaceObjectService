namespace SpaceObjectAI.Interfaces
{
    public interface IAsteroidImageRepository
    {
        public Task<string> getUrl(string name);
    }
}
