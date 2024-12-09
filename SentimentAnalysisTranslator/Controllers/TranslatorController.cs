using Microsoft.AspNetCore.Mvc;
using SentimentAnalysisTranslator.Service;

namespace SentimentAnalysisTranslator.Controllers
{
    public class TranslatorController : Controller
    {
        private readonly TranslatorService _translationService;


        public TranslatorController(TranslatorService translationService)
        {
            _translationService = translationService;
        }

        // POST method for translation
        [HttpPost]
        public async Task<IActionResult> TranslateText(string text, string targetLanguage)
        {
            if (string.IsNullOrEmpty(text) || string.IsNullOrEmpty(targetLanguage))
            {
                return View("Index", "Please provide text and a target language.");
            }

            var translatedText = await _translationService.TranslateTextAsync(text, targetLanguage);
            ViewBag.Message = translatedText;
            return View("Index", $"Translated Text: {translatedText}");
        }

        // GET method to show the index page
        public IActionResult Index(string message = "")
        {
            ViewBag.Message = message;
            return View();
        }

    }
}
