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
            loan.Amount = 25000;
            loan.InterestRate = 5m;
            loan.Term = 60;

            
            return View(loan);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(Loan loan)
        {
            Loan thisLoan = new();
            LoanCalculatorHelper loanHelper = new();
            thisLoan = loanHelper.CalcPaymentSchedule(loan);
            return View(thisLoan);
        }

    }
}
