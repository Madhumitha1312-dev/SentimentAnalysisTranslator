using Azure;
using Azure.AI.Translation.Text;

namespace SentimentAnalysisTranslator.Service
{
    public class TranslatorService
    {
        private readonly string _translatorKey;
        private readonly string _translatorEndpoint;

        public TranslatorService(IConfiguration configuration)
        {
            _translatorKey = configuration["Azure:TranslatorKey"];            
        }

        public async Task<string> TranslateTextAsync(string text, string targetLanguage)
        {
            AzureKeyCredential credential = new(_translatorKey);
            TextTranslationClient client = new(credential, "eastus");
            var response = await client.TranslateAsync(targetLanguage, text).ConfigureAwait(false);
            return response.Value[0].Translations[0].Text;
        }
    }
}
