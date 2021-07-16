using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FirstMVCApp.Models;

namespace FirstMVCApp.Helpers
{
    public class LoanCalculatorHelper
    {
        public decimal CalcMonthlyPayment(Loan loan)
        {
            double interestPart = Math.Pow((1 + Convert.ToDouble(loan.InterestRate) / 1200), -loan.Term);
            return loan.Amount * loan.InterestRate / 1200 / (1 - Convert.ToDecimal(interestPart));            
        }

        public Loan CalcPaymentSchedule(Loan loan)
        {
            Loan _loan = new();
            _loan.InterestRate = loan.InterestRate;
            _loan.Amount = loan.Amount;
            _loan.Term = loan.Term;            
            
            decimal monthlyPayment = CalcMonthlyPayment(loan);
            decimal previousBalance = loan.Amount;
            decimal totalPrincipal = 0;
            decimal totalInterest = 0;

            for (var i=1; i<= loan.Term; i++)
            {
                LoanPayment lp = new();
                lp.MonthNumber = i;
                lp.Payment = monthlyPayment;
                lp.Interest = previousBalance * loan.InterestRate / 1200;
                totalInterest += lp.Interest;                
                lp.InterestRunningTotal += totalInterest;
                lp.Principal = monthlyPayment - lp.Interest;
                totalPrincipal += lp.Principal;
                lp.Balance = previousBalance - lp.Principal;
                previousBalance = lp.Balance;
                _loan.PaymentSchedule.Add(lp);
            }

            _loan.MonthlyPayment = monthlyPayment;
            _loan.TotalPrincipal = totalPrincipal;
            _loan.TotalInterest = totalInterest;
            _loan.TotalCost = totalPrincipal + totalInterest;
            
            return _loan;
        }
    }
}
