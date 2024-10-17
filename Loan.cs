/*
    Name: Thi Ty Tran
    Date Created: Oct 15, 2024
    Description: Mortgage Calculation  - Inclass Exercise 2
    Last modified: Oct 16, 2024 
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    /// <summary>
    /// Represents a loan with associated details
    /// </summary>
    public class Loan
{
    // Data members (fields)
    private int loanNumber;
    private string customerName;
    private string customerAddress;
    private double loanAmount;
    private double interestRate; // Annual interest rate
    private int loanDuration; // Loan duration in years

    // Constructor
    public Loan(int loanNumber, string customerName, string customerAddress, double loanAmount, double interestRate, int loanDuration)
    {
        this.loanNumber = loanNumber;
        this.customerName = customerName;
        this.customerAddress = customerAddress;
        this.loanAmount = loanAmount;
        this.interestRate = interestRate;
        this.loanDuration = loanDuration;
    }

    // Method to calculate the monthly payment
    public double CalculateMonthlyPayment()
    {
        double monthlyInterestRate = (interestRate / 100) / 12;
        int totalPayments = loanDuration * 12;
        return loanAmount * (monthlyInterestRate * Math.Pow(1 + monthlyInterestRate, totalPayments)) / (Math.Pow(1 + monthlyInterestRate, totalPayments) - 1);
    }

    // Method to generate the loan report
    public string GenerateLoanReport()
    {
        double monthlyPayment = CalculateMonthlyPayment();
        return "Loan Number: " + loanNumber + "\n" +
               "Customer Name: " + customerName + "\n" +
               "Customer Address: " + customerAddress + "\n" +
               "Loan Amount: $" + Math.Round(loanAmount, 2) + "\n" +
               "Interest Rate: " + interestRate + "%\n" +
               "Loan Duration: " + loanDuration + " years\n" +
               "Monthly Payment: $" + Math.Round(monthlyPayment, 2) + "\n";
    }

    // Getter methods for fields (if needed)
    public int GetLoanNumber()
    {
        return loanNumber;
    }

    public string GetCustomerName()
    {
        return customerName;
    }

    public string GetCustomerAddress()
    {
        return customerAddress;
    }

    public double GetLoanAmount()
    {
        return loanAmount;
    }

    public double GetInterestRate()
    {
        return interestRate;
    }

    public int GetLoanDuration()
    {
        return loanDuration;
    }
}
