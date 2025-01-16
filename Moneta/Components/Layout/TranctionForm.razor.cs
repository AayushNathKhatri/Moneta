using DataModel.Model;
using Moneta.Components.Pages;

namespace Moneta.Components.Layout
{
    public partial class TranctionForm
    {
        protected override async Task OnInitializedAsync()
        {
            Debt = await DebtService.GetDebt();
            Tranction = await TranctionService.GetTranction();
            var result = await Calculate.Calculate(Debt, Tranction);
            totalCurrentBalance = result.TotalCurrentBalance;
        }

        private bool _sucess;
        private string sucessMessages = string.Empty;
        private string errorMessage = string.Empty;
        private string expenditureFail = string.Empty;
        private TransactionType TransactionType { get; set; }
        private TransctionTag TransactionTag { get; set; }
        public List<DebtsModel> Debt = new();
        public List<TransactionModel> Tranction = new();
        public TransactionModel Transaction { get; set; } = new();
        private double totalCurrentBalance;
        private async void HandelForm()
        {
            if (Transaction.TransactionType == TransactionType.Expenditure)
            {
                if (totalCurrentBalance <= Transaction.TransactionAmount)
                {
                    expenditureFail = "Expenditure exceeds current balance";
                    return;
                }
            }

            // Set the current date for the transaction
            Transaction.TransactionDate = DateTime.Now;

            // Try to create the transaction
            if (await TranctionService.CreateTranction(Transaction))
            {
                // Success - Show success message
                _sucess = true;
                sucessMessages = "Transaction successfully added.";
                expenditureFail = string.Empty;  
            }
            else
            {
                // Failure - Show error message
                _sucess = false;
                errorMessage = "Failed to add the transaction. Please try again.";
                expenditureFail = string.Empty;  // Clear any existing failure messages
            }
        }

        // Close the failure alert
        private void CloseMe()
        {
            expenditureFail = string.Empty;
        }
    }
}
