/*
    Name: Thi Ty Tran
    Date Created: Oct 15, 2024
    Description: Mortgage Calculation  - Inclass Exercise 2
    Last modified: Oct 16, 2024 
 */
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Mortgage
{
    /// <summary>
    /// Interaction logic for MainWindow
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Initializes a new MainWindow class
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            LoanNumberTextBox.Focus();
        }

        /// <summary>
        /// Calculate Button Click Event
        /// Validates user input and performs calculations if valid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CalculateButton_Click(object sender, RoutedEventArgs e)
        {
            // Validation of user input
            if (!IsInputValid())
            {
                OutputTextBox.Text = "Please enter valid values in all fields.";
                return;
            }

            // Retrieve and parse user input
            int loanNumber = int.Parse(LoanNumberTextBox.Text);
            string customerName = CustomerNameTextBox.Text;
            string customerAddress = CustomerAddressTextBox.Text;
            double loanAmount = double.Parse(LoanAmountTextBox.Text);
            double interestRate = double.Parse(InterestRateTextBox.Text);
            int loanDuration = int.Parse(LoanDurationTextBox.Text);

            // Create a Loan instance
            Loan loan = new Loan(loanNumber, customerName, customerAddress, loanAmount, interestRate, loanDuration);

            // Display loan report in the output textbox
            OutputTextBox.Text = loan.GenerateLoanReport();

            // Disable input and Calculate button after calculation
            DisableInputs();
        }

        // Validate inputs
        private bool IsInputValid()
        {
            // Check if all fields are filled
            if (string.IsNullOrWhiteSpace(LoanNumberTextBox.Text) ||
                string.IsNullOrWhiteSpace(CustomerNameTextBox.Text) ||
                string.IsNullOrWhiteSpace(CustomerAddressTextBox.Text) ||
                string.IsNullOrWhiteSpace(LoanAmountTextBox.Text) ||
                string.IsNullOrWhiteSpace(InterestRateTextBox.Text) ||
                string.IsNullOrWhiteSpace(LoanDurationTextBox.Text))
            {
                return false;
            }

            // Check if numeric values are valid
            if (!int.TryParse(LoanNumberTextBox.Text, out _) ||
                !double.TryParse(LoanAmountTextBox.Text, out _) ||
                !double.TryParse(InterestRateTextBox.Text, out _) ||
                !int.TryParse(LoanDurationTextBox.Text, out _))
            {
                return false;
            }

            return true;
        }

        // Reset Button Click Event
        private void ResetButton_Click(object sender, RoutedEventArgs e)
        {
            // Clear all input fields and output textbox
            LoanNumberTextBox.Text = string.Empty;
            CustomerNameTextBox.Text = string.Empty;
            CustomerAddressTextBox.Text = string.Empty;
            LoanAmountTextBox.Text = string.Empty;
            InterestRateTextBox.Text = string.Empty;
            LoanDurationTextBox.Text = string.Empty;
            OutputTextBox.Text = string.Empty;

            // Re-enable inputs and Calculate button
            EnableInputs();
        }

        // Exit Button Click Event
        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            // Close the application
            Close();
        }

        // Disable input fields and Calculate button
        private void DisableInputs()
        {
            LoanNumberTextBox.IsReadOnly = true;
            CustomerNameTextBox.IsReadOnly = true;
            CustomerAddressTextBox.IsReadOnly = true;
            LoanAmountTextBox.IsReadOnly = true;
            InterestRateTextBox.IsReadOnly = true;
            LoanDurationTextBox.IsReadOnly = true;
            CalculateButton.IsEnabled = false;
        }

        // Enable input fields and Calculate button
        private void EnableInputs()
        {
            LoanNumberTextBox.IsReadOnly = false;
            CustomerNameTextBox.IsReadOnly = false;
            CustomerAddressTextBox.IsReadOnly = false;
            LoanAmountTextBox.IsReadOnly = false;
            InterestRateTextBox.IsReadOnly = false;
            LoanDurationTextBox.IsReadOnly = false;
            CalculateButton.IsEnabled = true;
        }
    }
}