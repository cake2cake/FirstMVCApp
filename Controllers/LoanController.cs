using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FirstMVCApp.Models;
using FirstMVCApp.Helpers;

namespace FirstMVCApp.Controllers
{
    public class LoanController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            Loan loan = new();
            
            return View(loan);
        }

    }
}
