using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PedroPOE
{
    public abstract class Expense
    {
        [Key]
        public int ExpenseID { get; set; }
        public decimal Groceries { get; set; }
        public decimal Water { get; set; }
        public decimal Travel { get; set; }
        public decimal Cell { get; set; }
        public decimal Other { get; set; }

        public decimal GetTotalExpense()
        {
            decimal total = Groceries + Water + Travel + Cell + Other;
            return total;
        }

        public decimal GetNetIncome(decimal grossIncome, decimal taxDeducated)
        {
            decimal netIncome = grossIncome - taxDeducated;
            return Math.Abs(netIncome);
        }
    }
}
