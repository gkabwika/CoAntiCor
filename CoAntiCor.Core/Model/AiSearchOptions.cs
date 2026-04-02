namespace CoAntiCor.Core.Model
{
    /// <summary>
    /// Plugging a real LLM endpoint into /api/search/ai
    /// Assume we have an LLM endpoint(e.g., Azure OpenAI) that returns structured filters from natural language.
    /// </summary>
    public class AiSearchOptions
    {
        public string Endpoint { get; set; } = default!;
        public string ApiKey { get; set; } = default!;
        public string Deployment { get; set; } = default!;
    }

}
