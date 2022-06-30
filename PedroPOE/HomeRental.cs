using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PedroPOE
{
    public class HomeRental : Expense
    {
        public decimal RentalAmount { get; set; }

        public decimal TotalRentalExpense { get; set; }
    }
}
