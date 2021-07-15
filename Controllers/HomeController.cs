using FirstMVCApp.Helpers;
using FirstMVCApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace FirstMVCApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        //Palindrome Exercise

        [HttpGet]
        public IActionResult Reverse()
        {
            Palindrome palindrome = new();
            
            return View(palindrome);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Reverse(Palindrome palindrome)
        {

            if (palindrome.InputWord == null) return View(palindrome);

            PalindromeHelper pal = new();            
                                   
            palindrome.RevWord = pal.ReverseWord(palindrome.InputWord);
            palindrome.IsPalindrome = pal.IsPalindrome(palindrome.InputWord);                                              
            palindrome.Message = $"{(palindrome.IsPalindrome ? "is" : "is NOT")} a Palindrome ";
            
            return View(palindrome);
        }

        //FizzBuzz Exercise 
        [HttpGet]
        public IActionResult FizzBuzz()
        {
            FizzBuzz fizzBuzz = new();
            fizzBuzz.FizzValue = 3;
            fizzBuzz.BuzzValue = 5;
            return View(fizzBuzz);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult FizzBuzz(FizzBuzz fizzBuzz)
        {
            FizzBuzzHelper fbHelper = new();
                        
            return View(fbHelper.GetResult(fizzBuzz));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
