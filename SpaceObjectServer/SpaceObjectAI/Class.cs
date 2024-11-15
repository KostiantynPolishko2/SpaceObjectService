using OpenAI;

namespace SpaceObjectAI
{
    public class Class
    {
        private OpenAIClient openAIClient {  get; set; }
        public Class() 
        {
            openAIClient = new OpenAIClient("api_key");
        }
    }
}
