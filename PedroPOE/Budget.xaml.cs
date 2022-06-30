using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PedroPOE
{
    /// <summary>
    /// Interaction logic for Budget.xaml
    /// </summary>
    public partial class Budget : Window
    {
        public Budget()
        {
            InitializeComponent();
        }
        private void CalculateHomeRentalCover(string qualificationMessage)
        {
            if (rdoRent.IsChecked == true)
            {
                HomeRental homeRental = new HomeRental();
                decimal netIncome = homeRental.GetNetIncome(Convert.ToDecimal(txtGMI.Text), Convert.ToDecimal(txtTaxDeduct.Text));

                homeRental.Groceries = Convert.ToDecimal(txtGroceries.Text);
                homeRental.Water = Convert.ToDecimal(txtWater.Text);
                homeRental.Travel = Convert.ToDecimal(txtTravelCost.Text);
                homeRental.Cell = Convert.ToDecimal(txtCell.Text);
                homeRental.Other = Convert.ToDecimal(txtOther.Text);

                decimal totalRentalExpense = homeRental.GetTotalExpense() + Convert.ToDecimal(txtAmount.Text);

                if (totalRentalExpense > netIncome)
                {
                    qualificationMessage = "You don't qualify for a home rental";
                }
                else
                {
                    qualificationMessage = $"You do qualify for a home rental.\n You have {netIncome - totalRentalExpense} left";
                }
                //Messages should appear
                MessageBox.Show(qualificationMessage, "Qualification Message");

            }

        }




        private void CalculateHomeLoanCover(string qualificationMessage)
        {
            if (rdoBuy.IsChecked == true)
            {
                HomeLoan homeLoan = new HomeLoan();
                decimal netIncome = homeLoan.GetNetIncome(Convert.ToDecimal(txtGMI.Text), Convert.ToDecimal(txtTaxDeduct.Text));
                homeLoan.Groceries = Convert.ToDecimal(txtGroceries.Text);
                homeLoan.Water = Convert.ToDecimal(txtWater.Text);
                homeLoan.Travel = Convert.ToDecimal(txtTravelCost.Text);
                homeLoan.Cell = Convert.ToDecimal(txtCell.Text);
                homeLoan.Other = Convert.ToDecimal(txtOther.Text);

                homeLoan.PurchasePriceProperty = Convert.ToDecimal(txtPurchase.Text);
                homeLoan.TotalDeposit = Convert.ToDecimal(txtTotal.Text);
                homeLoan.InterestRate = Convert.ToDecimal(txtInterest.Text);
                homeLoan.NumMonthsRepay = Convert.ToDecimal(txtRepay.Text);

                decimal loanRepayment = homeLoan.LoanRepayment();

                var totalHomeLoanExpense = (netIncome / loanRepayment);

                if (totalHomeLoanExpense > 33)
                {
                    qualificationMessage = "You don't qualify for a home loan";
                }
                else
                {
                    qualificationMessage = $"You qualify for a home loan.\n You have {netIncome - loanRepayment} left";
                }
                //Message to implemt
                MessageBox.Show(qualificationMessage, "Qualification Message");

            }
        }
        private void CalculateVehicleCover(string qualificationMessage)
        {
            if (chkYesNo.IsChecked == true)
            {
                VehicleLoan vehicleLoan = new VehicleLoan();
                decimal netIncome = vehicleLoan.GetNetIncome(Convert.ToDecimal(txtGMI.Text), Convert.ToDecimal(txtTaxDeduct.Text));
                vehicleLoan.Groceries = Convert.ToDecimal(txtGroceries.Text);
                vehicleLoan.Water = Convert.ToDecimal(txtWater.Text);
                vehicleLoan.Travel = Convert.ToDecimal(txtTravelCost.Text);
                vehicleLoan.Cell = Convert.ToDecimal(txtCell.Text);
                vehicleLoan.Other = Convert.ToDecimal(txtOther.Text);

                vehicleLoan.PurchasePrice = Convert.ToDecimal(txtPrice.Text);
                vehicleLoan.TotalDeposit = Convert.ToDecimal(txtTotalDep.Text);
                vehicleLoan.InterestRate = Convert.ToDecimal(txtInterestRate.Text);
                vehicleLoan.NumYearRepay = Convert.ToDecimal(txtRepayment.Text);
                vehicleLoan.EstimatedInsurance = Convert.ToDecimal(txtEstimate.Text);

                decimal monthlyCost = vehicleLoan.TotalMonthlyCost();


                if (monthlyCost > netIncome)
                {
                    qualificationMessage = "You don't qualify for a vehicle purchase";
                }
                else
                {
                    qualificationMessage = $"You do qualify for a vehicle purchase.\n You have {netIncome - monthlyCost} left";
                }
                // Message
                MessageBox.Show(qualificationMessage, "Qualification Message");
            }
        }
        private void rdoBuy_Click(object sender, RoutedEventArgs e)
        {

        }

        private void rdoRent_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            string qualificationMessage = "";
            CalculateHomeRentalCover(qualificationMessage);
            CalculateHomeLoanCover(qualificationMessage);
            CalculateVehicleCover(qualificationMessage);
        }

        private void rdoRent_Checked(object sender, RoutedEventArgs e)
        {
            tabControl.Visibility = Visibility.Visible;
            tabRentP.IsEnabled = true;
            tabBuyP.IsEnabled = false;
            tabControl.SelectedItem = tabRentP;
            btnSubmit.IsEnabled = true;
            if (chkYesNo.IsChecked != true)
                tabBuyVhicle.IsEnabled = false;
        }

        private void rdoBuy_Checked(object sender, RoutedEventArgs e)
        {
            tabControl.Visibility = Visibility.Visible;
            tabBuyP.IsEnabled = true;
            tabRentP.IsEnabled = false;
            tabControl.SelectedItem = tabBuyP;
            btnSubmit.IsEnabled = true;
            if (chkYesNo.IsChecked != true)
                tabBuyVhicle.IsEnabled = false;
        }

        private void chkYesNo_Checked(object sender, RoutedEventArgs e)
        {
            if (chkYesNo.IsChecked == true)
            {
                tabControl.Visibility = Visibility.Visible;
                tabBuyVhicle.IsEnabled = true;
                tabControl.SelectedItem = tabBuyVhicle;
                btnSubmit.IsEnabled = true;
            }
            else
            {
                tabBuyVhicle.IsEnabled = false;

            }
        }

        private void btnCalculate_Click(object sender, RoutedEventArgs e)
        {
            Calculator c = new Calculator();
            c.ShowDialog();
        }
    }

}
