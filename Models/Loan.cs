using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstMVCApp.Models
{
    public class Loan
    {
        public decimal Amount { get; set; }
        // Loan Term (Months)
        public int Term { get; set; }
        
        // Interest Rate
        public decimal InterestRate { get; set; }
        public decimal TotalPrincipal { get; set; }
        public decimal TotalInterest { get; set; }
        public decimal TotalCost { get; set; }
        public List<LoanPayment> PaymentSchedule { get; set; } = new();

    }
}
