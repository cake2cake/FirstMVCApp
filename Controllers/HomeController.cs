using FirstMVCApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

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
            string inputWord = palindrome.InputWord;
            string revWord = "";

            if (palindrome.InputWord == null) return View(palindrome);

            for (int i=inputWord.Length-1; i>0; i--)
            {
                revWord += inputWord[i];
            }

            palindrome.RevWord = revWord;

            inputWord = Regex.Replace(inputWord.ToLower(), "[^a-zA-Z0-9]+", "");
            revWord = Regex.Replace(revWord.ToLower(), "[^a-zA-Z0-9]+", "");
            if (revWord==inputWord)
            {
                palindrome.IsPalindrome = true; 
                palindrome.Message = "is a Palindrome!";
            } 
            else
            {
                palindrome.IsPalindrome = false;
                palindrome.Message = "is NOT a Palindrome!";
            }
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
            int startValue = 1;
            int endValue = 100;
            fizzBuzz.Result = new();

            if (fizzBuzz.FizzValue < 1 || fizzBuzz.BuzzValue < 1) return View(fizzBuzz);

            int fizzbuzzValue; 

            if (fizzBuzz.FizzValue == fizzBuzz.BuzzValue)
            {
                fizzbuzzValue = fizzBuzz.FizzValue;
            } 
            else if (fizzBuzz.FizzValue % fizzBuzz.BuzzValue == 0)
            {
                fizzbuzzValue = fizzBuzz.FizzValue;
            }
            else if (fizzBuzz.BuzzValue % fizzBuzz.FizzValue == 0)
            {
                fizzbuzzValue = fizzBuzz.BuzzValue;
            }
            else
            {
                fizzbuzzValue = fizzBuzz.FizzValue* fizzBuzz.BuzzValue;
            }
            

            for (var i = startValue; i<= endValue; i++)
            {                                
                if (i % fizzbuzzValue == 0)
                {
                    fizzBuzz.Result.Add("FizzBuzz");
                } 
                else if (i % fizzBuzz.FizzValue == 0)
                {
                    fizzBuzz.Result.Add("Fizz");
                }
                else if (i % fizzBuzz.BuzzValue == 0)
                {
                    fizzBuzz.Result.Add("Buzz");
                } else
                {
                    //fizzBuzz.Result.Add(i.ToString());
                    fizzBuzz.Result.Add(i.ToString());
                }                
            }            
            
            return View(fizzBuzz);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
