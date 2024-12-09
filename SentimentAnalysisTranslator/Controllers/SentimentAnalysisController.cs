using Azure.AI.TextAnalytics;
using Azure;
using Microsoft.AspNetCore.Mvc;
using SentimentAnalysisTranslator.Service;

namespace SentimentAnalysisTranslator.Controllers
{
    public class SentimentAnalysisController : Controller
    {
        private readonly SentimentAnalysisService _sentimentService;
        public SentimentAnalysisController(SentimentAnalysisService sentimentService)
        {
            _sentimentService = sentimentService;            
        }

        // POST method to handle sentiment analysis
        [HttpPost]
        public async Task<IActionResult> AnalyzeSentiment(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return View("Index", "Please enter some text.");
            }

            var sentiment = await _sentimentService.AnalyzeSentimentAsync(text);
            ViewBag.Message = sentiment;
            return View("Index");
        }

        // GET method to show the index page
        public IActionResult Index(string message = "")
        {
            ViewBag.Message = message;
            return View();
        }
    }
}
