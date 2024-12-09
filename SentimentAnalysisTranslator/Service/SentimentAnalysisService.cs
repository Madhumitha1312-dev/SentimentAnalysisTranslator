using Azure.AI.TextAnalytics;
using Azure;

namespace SentimentAnalysisTranslator.Service
{
    public class SentimentAnalysisService
    {
        private readonly string _apiKey;
        private readonly string _endpoint;

        public SentimentAnalysisService(IConfiguration configuration)
        {
            _apiKey = configuration["Azure:TextAnalyticsKey"];
            _endpoint = configuration["Azure:TextAnalyticsEndpoint"];
        }

        public async Task<string> AnalyzeSentimentAsync(string text)
        {
            // Initialize a TextAnalyticsC0lient using the API key and endpoint
            var credentials = new AzureKeyCredential(_apiKey);
            var client = new TextAnalyticsClient(new Uri(_endpoint), credentials);

            // Analyze sentiment
            var response = await client.AnalyzeSentimentAsync(text);
            var sentiment = response.Value.Sentiment.ToString();

            return sentiment; // Possible values: "Positive", "Negative", "Neutral"
        }
    }
}
