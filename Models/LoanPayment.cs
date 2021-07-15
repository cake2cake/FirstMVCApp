using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstMVCApp.Models
{
    public class LoanPayment
    {
        // Month number within Loan Term
        public int MonthNumber { get; set; }
        public decimal Payment { get; set; }
        // Principal payment for the month
        public decimal Principal { get; set; }
        // Interest payment for the month
        public decimal Interest { get; set; }
        public decimal InterestRunningTotal { get; set; }
        public decimal Balance { get; set; }

    }
}
