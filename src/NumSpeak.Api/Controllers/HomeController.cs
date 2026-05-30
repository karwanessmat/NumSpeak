using Microsoft.AspNetCore.Mvc;
using NumSpeaks;

namespace NumSpeak.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        /// <summary>
        /// number
        /// </summary>
        /// <param name="number">you can use any type of number</param>
        /// <returns></returns>
        [HttpGet("kurdish/{number:decimal}")]
        public IActionResult WordsToKurdish(decimal number, CurrencyCode? currencyCode = null)
        {
            var textNumber = number.ToKurdishWords(currencyCode);
            return Ok(textNumber);
        }


        [HttpGet("arabic/{number:decimal}")]
        public IActionResult WordsToArabic(decimal number, CurrencyCode? currencyCode = null)
        {
            var textNumber = number.ToArabicWords(currencyCode);
            return Ok(textNumber);
        }

        [HttpGet("english/{number:decimal}")]
        public IActionResult WordsToEnglish(decimal number, CurrencyCode? currencyCode = null)
        {
            var textNumber = number.ToEnglishWords(currencyCode);
            return Ok(textNumber);
        }
    }
}
