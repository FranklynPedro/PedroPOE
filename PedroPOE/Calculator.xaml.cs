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
    /// Interaction logic for Calculator.xaml
    /// </summary>
    public partial class Calculator : Window
    {
        public Calculator()
        {
            InitializeComponent();
        }
        private void btnCalculate_Click(object sender, RoutedEventArgs e)
        {

            double InterestRate = Convert.ToDouble(txtInterest.Text);
            double monthlyInterestRate = InterestRate / 1200;

            int years = Convert.ToInt32(txtMonths.Text);
            double Amount = Convert.ToDouble(txtSave.Text);

            double MonthylyPayment = Amount * monthlyInterestRate / (1 - 1 / Math.Pow(1 + monthlyInterestRate, years * 12));

            string iMonthlyPayment = Convert.ToString(MonthylyPayment);
            iMontly.Content = (iMonthlyPayment);


            double TotalPayment = MonthylyPayment * years * 12;
            string iTotalPayment = Convert.ToString(TotalPayment);
            iTotal.Content = (iTotalPayment);

            txtSave.Text = Amount.ToString();

        }

        private void btnPrint_Click(object sender, RoutedEventArgs e)
        {
            rtfRecipt.AppendText("Saving Management System Calculator" + "\n");
            rtfRecipt.AppendText("--------------------------------------------- " + "\n");
            rtfRecipt.AppendText("Enter amount to Save:" + "\t" + txtSave.Text + "\n");
            rtfRecipt.AppendText("Enter Number of Year:" + "\t" + txtMonths.Text + "\n");
            rtfRecipt.AppendText("Enter Interest Rate:" + "\t" + txtInterest.Text + "\n");
            rtfRecipt.AppendText("Monthly Payment:" + "\t" + "\t" + iMontly.Content + "\n");
            rtfRecipt.AppendText("Total Payment:" + "\t" + "\t" + "\t" + iTotal.Content + "\n");
            rtfRecipt.AppendText("------------------------------------------------------------------------" + "\n");
            rtfRecipt.AppendText("------------------------Thank You---------------------------------------" + "\n");
        }


        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            txtSave.Clear();
            txtMonths.Clear();
            txtInterest.Clear();
            iTotal.Content = "";
            iMontly.Content = "";
            rtfRecipt.Document.Blocks.Clear();
        }

    }
}
