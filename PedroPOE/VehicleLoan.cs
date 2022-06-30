using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PedroPOE
{
    public class VehicleLoan : Expense
    {
        //  public int VehicleLoanID { get; set; }
        public decimal Model { get; set; }
        public decimal PurchasePrice { get; set; }
        public decimal TotalDeposit { get; set; }
        public decimal InterestRate { get; set; }
        public decimal NumYearRepay { get; set; }
        public decimal EstimatedInsurance { get; set; }

        public decimal TotalMonthlyCost()
        {
            decimal P = PurchasePrice - TotalDeposit;
            decimal percent = InterestRate / 100;
            int years = (int)NumYearRepay;
            decimal A = P * (1 + percent * years);
            decimal monthlyRepayment = A / NumYearRepay;
            return monthlyRepayment + EstimatedInsurance;
        }
    }
}
