using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PedroPOE
{
    public class HomeLoan : Expense
    {
        //  public int HomeLoanID { get; set; }
        public decimal PurchasePriceProperty { get; set; }
        public decimal TotalDeposit { get; set; }
        public decimal InterestRate { get; set; }
        public decimal NumMonthsRepay { get; set; }

        public decimal LoanRepayment()
        {
            decimal P = PurchasePriceProperty - TotalDeposit;
            decimal percent = InterestRate / 100;
            int years = (int)(NumMonthsRepay / 12);
            decimal A = P * (1 + percent * years);
            decimal monthlyRepayment = A / NumMonthsRepay;
            return monthlyRepayment;
        }
    }
}
